using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RStudentManagement.Data.Repositories
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Entities.Student>> GetAllAsync();
        Task UpdateAsync(Entities.Student student);
        Task AddAsync(Entities.Student student);
        Task DeleteAsync(Entities.Student student);
        Task<Entities.Student?> GetByIdAsync(Guid studentId);
    }
}
