using System.Net.Mail;
using System.Net;
using UniTutor.Interface;

namespace UniTutor.Services
{
   
        public class EmailService : IEmailService
        {
            private readonly IConfiguration _config;

            public EmailService(IConfiguration config)
            {
                _config = config;
            }

            public async Task SendVerificationCodeAsync(string email, string verificationCode)
            {
                using (var client = new SmtpClient(_config["Smtp:Host"], int.Parse(_config["Smtp:Port"])))
                {
                    client.Credentials = new NetworkCredential(_config["Smtp:Username"], _config["Smtp:Password"]);
                    client.EnableSsl = true;

                    var mailMessage = new MailMessage
                    {
                        From = new MailAddress(_config["Smtp:From"]),
                        Subject = "Password Reset Verification Code",
                        Body = $"Your verification code is: {verificationCode}",
                        IsBodyHtml = true,
                    };
                    mailMessage.To.Add(email);

                    await client.SendMailAsync(mailMessage);
                }
            }
        }
    
}
