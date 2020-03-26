using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.UI.Services;
using SendGrid;
using SendGrid.Helpers.Mail;
using VehicleHistory.Logic.Models.Utility;

namespace VehicleHistory.Logic.Services.Implementations
{
    public class EmailService : IEmailSender
    {
        public AppSettings AppSettings { get; }
        public EmailService(IOptions<AppSettings> settings)
        {
            AppSettings = settings.Value;
        }
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            return Execute(AppSettings.SendGridKey, subject, htmlMessage, email);
        }
        public Task Execute(string apiKey, string subject, string message, string email)
        {
            var client = new SendGridClient(apiKey);
            var msg = new SendGridMessage()
            {
                From = new EmailAddress("235028@student.pwr.edu.pl", "Historia Pojazdów"),
                Subject = subject,
                PlainTextContent = message,
                HtmlContent = message
            };
            msg.AddTo(new EmailAddress(email));
            
            msg.SetClickTracking(false, false);

            return client.SendEmailAsync(msg);
        }
    }
}
