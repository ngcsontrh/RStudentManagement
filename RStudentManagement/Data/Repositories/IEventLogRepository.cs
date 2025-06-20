using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RStudentManagement.Data.Repositories
{
    public interface IEventLogRepository
    {
        Task AddAsync(Entities.EventLog eventLog);
    }
}
