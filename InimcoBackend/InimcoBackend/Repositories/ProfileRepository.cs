using InimcoBackend.Configuration.Options;
using InimcoBackend.Entities;
using Microsoft.Extensions.Options;
using System.Collections.Concurrent;
using System.Text.Json;

namespace InimcoBackend.Repositories
{
    public class ProfileRepository : IProfileRepository
    {
        private readonly ILogger<ProfileRepository> _logger;
        private readonly string _storageLocation;

        private readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1,1);
        // No expiration necessary so using a concurrent dictionary is fine,
        // in more complex scenario's (e.g. with expiration) consider migrating to memorycache
        private IDictionary<Guid, Profile> _cache = new ConcurrentDictionary<Guid, Profile>();

        public ProfileRepository(ILogger<ProfileRepository> logger, IOptions<ConnectionStringOptions> options)
        {
            // If our storage is null, startup should fail.
            _ = options?.Value?.Storage ?? throw new ArgumentNullException(nameof(options));

            _logger = logger;
            _storageLocation = options.Value.Storage;

            InitializeCache();
        }

        public Profile? Retrieve(Guid profileId)
        {
            if (_cache.TryGetValue(profileId, out var profile))
                return profile;

            return null;
        }
        public async Task<Profile?> StoreAsync(Profile profile)
        {
            // When storing, only 1 thread should be able to write at the same time
            await _semaphore.WaitAsync();
            try
            {
                // Re-read all data, when writing, something may have changed 
                // & we don't want to overwrite external changes.
                var currentProfiles = await GetCurrentDataAsync();

                if (currentProfiles == null) return null;
                    
                currentProfiles.Add(profile);

                await WriteToFileAsync(currentProfiles);

                // After writing to the file, upon success, we re-initialize our cache.
                ReInitializeCache(currentProfiles);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Couldn't add new profile to cache/file");
                _semaphore.Release();
                // If storage has failed, we don't return anything.
                return null;
            }

            _semaphore.Release();

            return profile;
        }


        private void InitializeCache()
        {
            if (!File.Exists(_storageLocation))
            {
                File.Create(_storageLocation);
                _logger.LogInformation("Created new data file!");
                return;
            }

            if (new FileInfo(_storageLocation).Length == 0)
            {
                _logger.LogInformation("File existed but no content found");
                return;
            }

            // Initialize the cache, don't catch the exception because
            // if startup fails, cache is incorrectly initialized
            using (var stream = File.OpenRead(_storageLocation))
            {
                var storedProfiles = JsonSerializer.Deserialize<IList<Profile>>(stream);

                if (storedProfiles == null) return;

                ReInitializeCache(storedProfiles);
            }

            _logger.LogInformation("Initialize cache from existing file.");
        }               

        private void ReInitializeCache(IList<Profile> profiles)
        {
            if(profiles == null) return;

            _cache.Clear();


            foreach(var profile in profiles)
            {
                if (profile == null) continue;

                _cache.Add(profile.Guid, profile);
            }
        }

        private async Task<IList<Profile>?> GetCurrentDataAsync()
        {
            var info = new FileInfo(_storageLocation);

            // If the file is empty, just return an empty list that can be manipulated.
            if (info.Length == 0)
                return new List<Profile>();

            try
            {
                using(var stream = File.OpenRead(_storageLocation))
                {
                    return await JsonSerializer.DeserializeAsync<IList<Profile>>(stream);
                }
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong while trying to read the file at {_storageLocation}");
                return null;
            }
        }

        private async Task WriteToFileAsync(IList<Profile> profiles)
        {
            try
            {
                using(var stream = File.OpenWrite(_storageLocation))
                {
                    await JsonSerializer.SerializeAsync(stream, profiles);
                }
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong while trying to consolidate profiles!");
            }
        }
    }
}
