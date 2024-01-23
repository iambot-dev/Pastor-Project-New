using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PASTORALISPROJECTNEW.DBContext;
using PASTORALISPROJECTNEW.EmailService;
using PASTORALISPROJECTNEW.Repository;
using PASTORALISPROJECTNEW.RequestModels;
using System.IdentityModel.Tokens.Jwt;
using System.Text;



namespace PASTORALISPROJECTNEW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class RegistrationController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _config;
        private readonly PastoralisDBContext _context;
        private readonly IServiceMailer mailer;

        public RegistrationController(IUserRepository repository, IConfiguration configuration, PastoralisDBContext context, IServiceMailer mailer)
        {
            this._userRepository = repository;
            this._config = configuration;
          
            this._context = context;
            this.mailer = mailer;
        }

        [HttpPost("RegisterUser")]
        public IActionResult Register([FromBody] RegistrationModel model)
        {
            if (ModelState.IsValid)
            {
                _userRepository.RegisterUser(model);
                return Ok();
            }

            return BadRequest(ModelState);
        }

        [HttpPost("LoginUser")]
        public IActionResult Login([FromBody] LoginModel model)
        {
            var result = _userRepository.LoginUser(model);
            return result;
        }

        [Route("forgot-password-otp")]
        [HttpPost]
        public async Task<IActionResult> ForgetPassword([FromBody] EmailViewModel email)
        {
            var users = _context.Users.Where(u => u.UserEmail == email.Email).Select(u => u.UserEmail);
            if (users == null)
            {
                return BadRequest($"User not found for this email");
            }
            string otp = mailer.GenerateOTP();


            var res = mailer.SendEmailAsync(email.Email, otp);

            return Ok(new { Message = "OTP sent successfully" });

        }


    }
}

