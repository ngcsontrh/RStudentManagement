using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RStudentManagement.Data.Repositories
{
    public class EventLogRepository : IEventLogRepository
    {
        public EventLogRepository() { }
        public async Task AddAsync(Entities.EventLog eventLog)
        {
            using var context = DatabaseManager.Instance.GetConnection();
            await context.EventLogs.AddAsync(eventLog);
            await context.SaveChangesAsync();
        }
    }
}
