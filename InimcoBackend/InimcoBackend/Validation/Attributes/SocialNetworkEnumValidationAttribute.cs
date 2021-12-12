using InimcoBackend.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace InimcoBackend.Validation.Attributes
{
    public class SocialNetworkEnumValidationAttribute : ValidationAttribute 
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if(value == null || !Enum.IsDefined(typeof(SocialNetworkEnum), value))
            {
                return new ValidationResult("Ensure you select a valid social network!");
            }

            return null;
        }
    }
}
