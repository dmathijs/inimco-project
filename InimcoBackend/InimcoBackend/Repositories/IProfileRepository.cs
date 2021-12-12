using InimcoBackend.Entities;

namespace InimcoBackend.Repositories
{
    public interface IProfileRepository
    {
        public Task<Profile?> StoreAsync(Profile profile);
        public Profile? Retrieve(Guid profileId);
    }
}
