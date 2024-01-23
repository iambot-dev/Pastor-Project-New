namespace PASTORALISPROJECTNEW.EmailService
{
    public interface IServiceMailer
    {
        Task SendEmailAsync(string email, string otp);
        string GenerateOTP();
    }
}
