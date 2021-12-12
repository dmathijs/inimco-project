using InimcoBackend.Entities.Enums;

namespace InimcoBackend.Entities
{
    public class ProfileSocialNetwork
    {
        public SocialNetworkEnum Type { get; set; }
        public string Address { get; set; } = string.Empty;
    }
}
