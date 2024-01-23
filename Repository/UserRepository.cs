using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PASTORALISPROJECTNEW.DBContext;
using PASTORALISPROJECTNEW.Models;
using PASTORALISPROJECTNEW.RequestModels;

namespace PASTORALISPROJECTNEW.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly PastoralisDBContext _context;
        private readonly ITokenService _service;

        public UserRepository(PastoralisDBContext context , ITokenService service)
        {
            this._context = context;
            this._service = service;
        }
        public IActionResult LoginUser(LoginModel model)
        {

            var user = _context.Users.FirstOrDefault(u => u.UserEmail == model.UserEmail);
            if (user == null || new PasswordHasher<User>().VerifyHashedPassword(user, user.Password, model.Password) != PasswordVerificationResult.Success)
            {
                user.LoginAttempt = +1;
                // User not found or invalid password
                return new BadRequestObjectResult("Invalid email or password");
                
            }
            var token = _service.GenerateToken(user);
            if (token == null)
            {
                // Token generation failed
                return new StatusCodeResult(500); // Internal Server Error
            }
            // Successful login
            return new OkObjectResult(token);
        }

        public IActionResult RegisterUser(RegistrationModel model)
        {
            // Checking  if the email  is already exists or not 
            if (_context.Users.Any(u => u.UserEmail == model.UserEmail))
            {
                return new BadRequestObjectResult("Email already exists");
            }
            var user = new User
            {
                UserName = model.UserName,
                UserEmail = model.UserEmail,
                CreatedDate = DateTime.UtcNow,
                EntityType = model.EntityType,
                TermsAndConditionsAccepted = model.TermsAndConditionsAccepted
            };
            user.Password = new PasswordHasher<User>().HashPassword(user, model.Password);
            _context.Users.Add(user);
            switch (model.EntityType)
            {
                case 1:
                    var counselee = new Counselee
                    {
                        SurveyAttempted = false,
                        SubscriptionType = "Free",
                        EndDate = DateTime.UtcNow.AddMonths(0)
                    };
                    _context.Counselees.Add(counselee);
                    _context.SaveChanges();

                    var counseleeEntityAccess = new Userentityaccess
                    {
                        User = user,
                        EntityId = counselee.Id,
                        EntityType = 1,
                        CreatedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow
                    };
                    _context.Userentityaccesses.Add(counseleeEntityAccess);
                    break;

                case 2:
                    var pastor = new Pastor
                    {
                        PastorDescription = model.UserName
                    };
                    _context.Pastors.Add(pastor);
                    _context.SaveChanges();

                    var pastorEntityAccess = new Userentityaccess
                    {
                        User = user,
                        EntityId = pastor.Id,
                        EntityType = 2,
                        CreatedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow
                    };
                    _context.Userentityaccesses.Add(pastorEntityAccess);
                    break;

                default:
                    return new BadRequestObjectResult("Invalid entity type");
            }
            try
            {
                // checking weather EntityType is 1 or 2 

                _context.SaveChanges();
                return new OkObjectResult("User registered successfully");
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult($"Registration failed. Error: {ex.Message}");
            }
        }
    }
}
