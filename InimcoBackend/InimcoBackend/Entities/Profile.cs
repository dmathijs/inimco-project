namespace InimcoBackend.Entities
{
    public class Profile
    {
        // Use GUID as primary key in storage
        public Guid Guid { get; set; } = Guid.NewGuid();

        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        public IEnumerable<string> SocialSkills { get; set; } = new List<string>();
        public IEnumerable<ProfileSocialNetwork> SocialAccounts { get; set; } = new List<ProfileSocialNetwork>();
    }
}
