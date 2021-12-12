using System.ComponentModel.DataAnnotations;

namespace InimcoBackend.Models.ProfileRetrieval
{
    public abstract class ProfileDto
    {
        [Required]
        [MaxLength(255)]
        public virtual string FirstName { get; set; } = string.Empty;

        [Required]
        [MaxLength(255)]
        public virtual string LastName { get; set; } = string.Empty;

        [Required]
        public IEnumerable<string> SocialSkills { get; set; } = new List<string>();
    }
}
