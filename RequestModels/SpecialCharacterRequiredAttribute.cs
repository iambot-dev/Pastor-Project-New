using System.ComponentModel.DataAnnotations;

namespace PASTORALISPROJECTNEW.RequestModels
{
    public class SpecialCharacterRequiredAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var password = value as string;

            if (!string.IsNullOrEmpty(password) && !HasSpecialChar(password))
            {
                return new ValidationResult("The password must contain at least one special character.");
            }

            return ValidationResult.Success;
        }

        private bool HasSpecialChar(string input)
        {
            foreach (var ch in input)
            {
                if (!char.IsLetterOrDigit(ch))
                {
                    return true;
                }
            }

            return false;
        }
    }

}
