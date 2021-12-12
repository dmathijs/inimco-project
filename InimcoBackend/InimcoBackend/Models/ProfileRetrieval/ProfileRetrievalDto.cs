using System.ComponentModel.DataAnnotations;

namespace InimcoBackend.Models.ProfileRetrieval
{
    public class ProfileRetrievalDto : ProfileDto
    {
        public Guid Guid { get; set; }

        [Required]
        public IEnumerable<ProfileSocialNetworkRetrievalDto> SocialAccounts { get; set; } = new List<ProfileSocialNetworkRetrievalDto>();
    }
}
