using RStudentManagement.Loggers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RStudentManagement.ExternalServices
{
    public class MailService : IMailService
    {
        private readonly string _appMailAddress;
        private readonly string _appMailPassword;
        private readonly string _smtpServer;
        private readonly int _smtpPort;

        public MailService()
        {
            _appMailAddress = AppConfig.MailAddress;
            _appMailPassword = AppConfig.MailPassword;
            _smtpServer = AppConfig.SmtpServer;
            _smtpPort = AppConfig.SmtpPort;
        }

        public async Task SendEmailAsync(string to, string subject, string body)
        {
            if (string.IsNullOrEmpty(to))
            {
                throw new ArgumentException("Recipient email cannot be null or empty", nameof(to));
            }
            if (string.IsNullOrEmpty(subject))
            {
                throw new ArgumentException("Email subject cannot be null or empty", nameof(subject));
            }
            if (string.IsNullOrEmpty(body))
            {
                throw new ArgumentException("Email body cannot be null or empty", nameof(body));
            }
            try
            {
                var message = new MimeKit.MimeMessage();
                message.From.Add(new MimeKit.MailboxAddress("RStudentManagement", _appMailAddress));
                message.To.Add(new MimeKit.MailboxAddress(to, to));
                message.Subject = subject;
                message.Body = new MimeKit.TextPart("plain") { Text = body };

                using (var client = new MailKit.Net.Smtp.SmtpClient())
                {
                    await client.ConnectAsync(_smtpServer, _smtpPort, MailKit.Security.SecureSocketOptions.StartTls);
                    await client.AuthenticateAsync(_appMailAddress, _appMailPassword);
                    await client.SendAsync(message);
                    await client.DisconnectAsync(true);
                }

                FileLogger.Instance.LogInfo($"Sending email to {to}. Subject: {subject}");
            }
            catch (Exception ex)
            {
                FileLogger.Instance.LogError($"Failed to send email to {to}. Subject: {subject}. Error: {ex.Message}");
                throw;
            }
        }
    }
}
