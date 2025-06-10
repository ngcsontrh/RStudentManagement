using RStudentManagement.Core;
using RStudentManagement.Core.Logger;
using RStudentManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RStudentManagement.ExternalServices.Implements
{
    internal class MailService : IMailService
    {
        private readonly ILogger _logger;

        public MailService()
        {
            _logger = LoggerFactory.Instance.GetLogger(AppConfig.LoggerType);
        }

        public Task<bool> SendAsync(Mail mail)
        {
            try
            {
                _logger.LogInfo($"Email was sent to {mail.Email}.");
                return Task.FromResult(true);
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred while sending email.", ex);
                return Task.FromResult(false);
            }
        }
    }
}
