using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RStudentManagement.Entities
{
    public class Mail
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Email { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string Body { get; set; } = null!;
        public string Status { get; set; } = MailStatus.Sending.ToString();
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }

    public enum MailStatus
    {
        Sending,
        Success,
        Failed
    }
}
