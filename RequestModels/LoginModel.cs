using System.ComponentModel.DataAnnotations;

namespace PASTORALISPROJECTNEW.RequestModels
{

    public class LoginModel
    {
        [Required, EmailAddress]
        public string UserEmail { get; set; }
        /*[Required]*/
        public string? Password { get; set; }

        /* public String AccessToken { get; set; }*/

    }
}
