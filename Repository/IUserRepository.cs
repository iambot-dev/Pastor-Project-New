using Microsoft.AspNetCore.Mvc;
using PASTORALISPROJECTNEW.RequestModels;


namespace PASTORALISPROJECTNEW.Repository
{
    public interface IUserRepository
    {
         IActionResult RegisterUser(RegistrationModel model);
        IActionResult LoginUser(LoginModel model);
    }
}
