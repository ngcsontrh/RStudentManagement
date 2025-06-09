using RStudentManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RStudentManagement.Services.Implements
{
    internal class StudentLogService : IStudentService
    {
        public Task<bool> AddStudentAsync(Student student)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteStudentAsync(Student student)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Student>> GetAllStudentsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Student?> GetStudentByIdAsync(Guid studentId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateStudentAsync(Student student)
        {
            throw new NotImplementedException();
        }
    }
}
