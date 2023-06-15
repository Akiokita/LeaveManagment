using HR.LeaveManagement.Application.Contracts.Email;
using HR.LeaveManagement.Application.Model.Email;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Infrastructure.EmailService
{
    public class EmailSender : IEmailSender
    {
        public EmailSettings _emailSettings { get; }
        public EmailSender(IOptions<EmailSettings> emailSettings)
        {
            _emailSettings = emailSettings.Value;
        }
        public async Task<bool> SendEmail(EmailMessage email)
        {
            var client = new SendGridClient(_emailSettings.ApiKey);
            var to = new EmailAddress(email.To);
            var from = new EmailAddress
            {
                Email = _emailSettings.FromAddress,
                Name = _emailSettings.FromName
            };

            var message =   CreateSingleEmail(from, to, email.Subject, email.Body, email.Body);
            var response = await client.SendEmailAsync(message);

            return response.IsSuccessStatusCode;
        }

        public SendGridMessage CreateSingleEmail(EmailAddress from, EmailAddress to, string subject, string plainTextContent, string htmlContent)
        {
            SendGridMessage sendGridMessage = new SendGridMessage();
            sendGridMessage.SetFrom(from);
            sendGridMessage.SetSubject(subject);
            if (!string.IsNullOrEmpty(plainTextContent))
            {
                sendGridMessage.AddContent(MimeType.Text, plainTextContent);
            }

            if (!string.IsNullOrEmpty(htmlContent))
            {
                sendGridMessage.AddContent(MimeType.Html, htmlContent);
            }

            sendGridMessage.AddTo(to);
            return sendGridMessage;
        }
    }
}
