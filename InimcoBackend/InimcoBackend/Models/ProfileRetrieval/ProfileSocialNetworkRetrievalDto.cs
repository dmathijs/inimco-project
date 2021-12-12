using System.ComponentModel.DataAnnotations;

namespace InimcoBackend.Models.ProfileRetrieval
{
    public class ProfileSocialNetworkRetrievalDto : ProfileSocialMediaDto
    {
        public string? Type { get; set; }
    }
}
