using RStudentManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RStudentManagement.EntityBuilder
{
    public interface IMailBuilder
    {
        MailBuilder WithEmail(string email);
        MailBuilder WithTitle(string title);
        MailBuilder WithBody(string body);
        Mail Build();
    }

    public class MailBuilder : IMailBuilder
    {
        private readonly Mail _mail = new Mail();
        public MailBuilder WithEmail(string email)
        {
            _mail.Email = email;
            return this;
        }
        public MailBuilder WithTitle(string title)
        {
            _mail.Title = title;
            return this;
        }
        public MailBuilder WithBody(string body)
        {
            _mail.Body = body;
            return this;
        }
        public Mail Build()
        {
            return _mail;
        }
    }
}
