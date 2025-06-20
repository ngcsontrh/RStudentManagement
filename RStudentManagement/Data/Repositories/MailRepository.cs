using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RStudentManagement.Data.Repositories
{
    public class MailRepository : IMailRepository
    {
        public MailRepository() { }
        public async Task AddAsync(Entities.Mail mail)
        {
            using var context = DatabaseManager.Instance.GetConnection();
            await context.Mails.AddAsync(mail);
            await context.SaveChangesAsync();
        }
    }
}
