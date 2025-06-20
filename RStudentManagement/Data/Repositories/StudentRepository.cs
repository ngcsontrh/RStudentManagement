using Mapster;
using Microsoft.EntityFrameworkCore;
using RStudentManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RStudentManagement.Data.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        public StudentRepository()
        {
        }
        public async Task<IEnumerable<Entities.Student>> GetAllAsync()
        {
            using var context = DatabaseManager.Instance.GetConnection();
            return await context.Students.ToListAsync();
        }
        public async Task AddAsync(Entities.Student student)
        {
            using var context = DatabaseManager.Instance.GetConnection();
            await context.Students.AddAsync(student);
            await context.SaveChangesAsync();
        }
        public async Task DeleteAsync(Student student)
        {
            using var context = DatabaseManager.Instance.GetConnection();
            context.Students.Remove(student);
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Student student)
        {
            using var context = DatabaseManager.Instance.GetConnection();
            var existingStudent = await context.Students.FindAsync(student.Id);
            if (existingStudent is null)
            {
                throw new KeyNotFoundException($"Student with ID {student.Id} not found.");
            }
            existingStudent = student.Adapt(existingStudent);
            await context.SaveChangesAsync();
        }

        public async Task<Student?> GetByIdAsync(Guid studentId)
        {
            if (studentId == Guid.Empty)
            {
                throw new ArgumentException("Student ID cannot be empty.", nameof(studentId));
            }
            using var context = DatabaseManager.Instance.GetConnection();
            return await context.Students
                .FirstOrDefaultAsync(s => s.Id == studentId);
        }
    }
}
