using System.ComponentModel.DataAnnotations;

namespace PASTORALISPROJECTNEW.RequestModels
{
    public class ChangePassword
    {
        [Required]
        public string CurrentPassword { get; set;}
        [Required]
        public string NewPassword { get; set;}
        [Required]
        [Compare("NewPassword", ErrorMessage ="Passwords do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
