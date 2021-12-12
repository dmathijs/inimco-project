using InimcoBackend.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace InimcoBackend.Models.ProfileRetrieval
{
    public abstract class ProfileSocialMediaDto
    {
        [Required]
        [MaxLength(512)]
        public virtual string Address { get; set; } = string.Empty;
    }
}
