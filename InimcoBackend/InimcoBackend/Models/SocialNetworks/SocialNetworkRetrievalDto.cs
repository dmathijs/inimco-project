using InimcoBackend.Entities.Enums;

namespace InimcoBackend.Models.SocialNetworks
{
    public class SocialNetworkRetrievalDto
    {
        public SocialNetworkRetrievalDto(SocialNetworkEnum key)
        {
            Key = key;
            Name = key.GetName();
        }

        public SocialNetworkEnum Key { get; set; }
        public string Name { get; set; }
    }
}
