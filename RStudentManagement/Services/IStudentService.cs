using RStudentManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RStudentManagement.Services
{
    internal interface IStudentService
    {
        Task<bool> AddStudentAsync(Student student);
        Task<bool> UpdateStudentAsync(Student student);
        Task<bool> DeleteStudentAsync(Student student);
        Task<Student?> GetStudentByIdAsync(Guid studentId);
        Task<IEnumerable<Student>> GetAllStudentsAsync();
    }
}
