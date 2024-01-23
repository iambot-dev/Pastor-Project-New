using System.Net.Mail;
using System.Net;
using System;

namespace PASTORALISPROJECTNEW.EmailService
{
    public class ServiceMailer : IServiceMailer
    {
        private static readonly Random random = new Random();
        public string GenerateOTP()
        {
            const int otpLength = 6;
            const string chars = "0123456789";
            return new string(Enumerable.Repeat(chars, otpLength)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public Task SendEmailAsync(string email, string otp)
        {
            var mail = "samarjeet.khanuja@appsphere.in";
            var pw = "EIgVRtBCH3apswyd";
            string subject = "Password Reset";
            string message = $"Please do not share this OTP {otp}\nPlease input this OTP in Pastoralis to reset your password";
            var client = new SmtpClient("smtp-relay.brevo.com", 587)
            {
                EnableSsl = true,
                Credentials = new NetworkCredential(mail, pw)

            };
            return client.SendMailAsync(
                new MailMessage(from: mail,
                                 to: email,
                                 subject,
                                 message));
        }



    }
}

