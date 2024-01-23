using PASTORALISPROJECTNEW.Models;
using System.Security.Claims;

namespace PASTORALISPROJECTNEW.Repository
{
    public interface ITokenService
    {
        string GenerateToken(User user);
        bool ValidateToken(string token);
        void RevokeToken(string token);
    }
}
