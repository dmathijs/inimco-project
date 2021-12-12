using InimcoBackend.Entities.Enums;
using InimcoBackend.Models.ProfileRetrieval;
using InimcoBackend.Validation.Attributes;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace InimcoBackend.Models
{
    public class ProfileSocialMediaCreateDto : ProfileSocialMediaDto, IValidatableObject 
    {
      
        [Required, SocialNetworkEnumValidation]
        public SocialNetworkEnum? Type { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var invariantAddress = Address.ToLowerInvariant();

            // Validation close to the Dto, can be moved to separate extension method if re-use is 
            // required in the future.
            switch (Type)
            {
                case SocialNetworkEnum.Facebook:
                    if (!invariantAddress.Contains("facebook.com"))
                        yield return new ValidationResult("Your facebook address seems to be invalid");
                    break;
                case SocialNetworkEnum.Twitter:
                    if (!invariantAddress.Contains("@"))
                        yield return new ValidationResult("Ensure you use a correct twitter handle");
                    break;
                case SocialNetworkEnum.Medium:
                    if (!invariantAddress.Contains("medium.com"))
                        yield return new ValidationResult("Your medium address seems to be invalid");
                    break;
                case SocialNetworkEnum.Linkedin:
                    if (!invariantAddress.Contains("linkedin.com"))
                        yield return new ValidationResult("Your linkedin address seems to be invalid");
                    break;
            }
        }
    }
}
