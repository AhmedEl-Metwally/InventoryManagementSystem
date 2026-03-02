using InventoryManagementSystem.Application.Common.Settings;
using InventoryManagementSystem.Domain.Exceptions;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
namespace InventoryManagementSystem.Infrastructure.Services
{
    public class EmailService(IOptions<EmailSettings> emailSettings) : IEmailService
    {
        private readonly EmailSettings _settings = emailSettings.Value;
        public async Task<bool> SendEmailAsync(string To, string Subject, string Body)
        {
            var email = new MimeMessage();
            email.From.Add(new MailboxAddress(_settings.SenderName, _settings.SenderEmail));
            email.To.Add(MailboxAddress.Parse(To));
            email.Subject = Subject;

            var builder = new BodyBuilder { HtmlBody = Body };
            email.Body = builder.ToMessageBody();   
            using var smtpClient = new SmtpClient();
            try
            {
                await smtpClient.ConnectAsync(_settings.SmtpServer, _settings.SmtpPort, SecureSocketOptions.StartTls);
                await smtpClient.AuthenticateAsync(_settings.SmtpUsername, _settings.SmtpPassword);
                await smtpClient.SendAsync(email);
                return true;
            }
            catch (Exception ex)
            {
                throw new EmailDeliveryException($"Failed to send email to {To}", ex);
            }
            finally 
            {
                if(smtpClient.IsConnected)
                await smtpClient.DisconnectAsync(true);
            }
        }
    }
}
