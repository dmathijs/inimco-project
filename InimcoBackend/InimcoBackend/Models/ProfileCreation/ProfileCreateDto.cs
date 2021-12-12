using InimcoBackend.Entities.Enums;
using InimcoBackend.Models.ProfileRetrieval;
using System.ComponentModel.DataAnnotations;

namespace InimcoBackend.Models
{
    public class ProfileCreateDto : ProfileDto
    {
        [Required]
        public IEnumerable<ProfileSocialMediaCreateDto> SocialAccounts { get; set; } = new List<ProfileSocialMediaCreateDto>();
    }
}
