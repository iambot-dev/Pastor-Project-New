using System.ComponentModel.DataAnnotations;
using System.Net.Security;

namespace PASTORALISPROJECTNEW.RequestModels
{
    public class RegistrationModel
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required , EmailAddress]
        public string UserEmail { get; set; }
        [Required]
        [StringLength(int.MaxValue, MinimumLength = 6, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public string Password { get; set; }
        public int EntityType { get; set; }
        public bool? TermsAndConditionsAccepted { get; set; }
        public string UserName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }
    }
}
