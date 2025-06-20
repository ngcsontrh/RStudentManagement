using RStudentManagement.Data;
using RStudentManagement.Data.Repositories;
using RStudentManagement.Entities;
using RStudentManagement.EntityBuilder;
using RStudentManagement.ExternalServices;
using RStudentManagement.Loggers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RStudentManagement.Facades
{
    public class StudentFacade : IStudentFacade
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IEventLogRepository _eventLogRepository;
        private readonly IMailRepository _mailRepository;
        private readonly IMailService _mailService;

        public StudentFacade()
        {
            _studentRepository = new StudentRepository();
            _eventLogRepository = new EventLogRepository();
            _mailRepository = new MailRepository();
            _mailService = new MailService();
        }

        public async Task AddStudentAsync(Student student)
        {
            if (student == null)
            {
                throw new ArgumentNullException(nameof(student), "Student cannot be null");
            }
            try
            {
                await _studentRepository.AddAsync(student);
                await _mailService.SendEmailAsync(student.Email, "Welcome to RStudentManagement", $"Student {student.FullName} has been created");
                await _mailRepository.AddAsync(new MailBuilder()
                    .WithEmail(student.Email)
                    .WithTitle("Welcome to RStudentManagement")
                    .WithBody($"Student {student.FullName} has been created")
                    .Build());
                await _eventLogRepository.AddAsync(new EventLogBuilder()
                    .WithEventType("StudentCreated")
                    .WithDescription($"Student {student.FullName} has been created")
                    .Build());
                FileLogger.Instance.LogInfo($"Student {student.FullName} has been added successfully.");
            }
            catch (Exception ex)
            {
                FileLogger.Instance.LogError($"Failed to add student {student.FullName}. Error: {ex.Message}");
                throw;
            }            
        }

        public async Task DeleteStudentAsync(Guid studentId)
        {
            if (studentId == Guid.Empty)
            {
                throw new ArgumentException("Student ID cannot be empty", nameof(studentId));
            }
            try
            {
                var student = await _studentRepository.GetByIdAsync(studentId);
                if (student == null)
                {
                    throw new KeyNotFoundException($"Student with ID {studentId} not found.");
                }
                await _studentRepository.DeleteAsync(student);
                await _mailService.SendEmailAsync(student.Email, "Account Deletion", $"Your account with ID {studentId} has been deleted.");
                await _mailRepository.AddAsync(new MailBuilder()
                    .WithEmail(student.Email)
                    .WithTitle("Account Deletion")
                    .WithBody($"Your account with ID {studentId} has been deleted.")
                    .Build());
                await _eventLogRepository.AddAsync(new EventLogBuilder()
                    .WithEventType("StudentDeleted")
                    .WithDescription($"Student with ID {studentId} has been deleted.")
                    .Build());
                FileLogger.Instance.LogInfo($"Student with ID {studentId} has been deleted successfully.");
            }
            catch (Exception ex)
            {
                FileLogger.Instance.LogError($"Failed to delete student with ID {studentId}. Error: {ex.Message}");
                throw;
            }
        }

        public Task<IEnumerable<Student>> GetAlStudentsAsync()
        {
            return _studentRepository.GetAllAsync();
        }

        public async Task UpdateStudentAsync(Student student)
        {
            try
            {
                if (student == null)
                {
                    throw new ArgumentNullException(nameof(student), "Student cannot be null");
                }
                await _studentRepository.UpdateAsync(student);
                await _mailService.SendEmailAsync(student.Email, "Account Update", $"Your account with ID {student.Id} has been updated.");
                await _mailRepository.AddAsync(new MailBuilder()
                    .WithEmail(student.Email)
                    .WithTitle("Account Update")
                    .WithBody($"Your account with ID {student.Id} has been updated.")
                    .Build());
                await _eventLogRepository.AddAsync(new EventLogBuilder()
                    .WithEventType("StudentUpdated")
                    .WithDescription($"Student {student.FullName} has been updated.")
                    .Build());
            }
            catch (Exception ex)
            {
                FileLogger.Instance.LogError($"Failed to update student {student.FullName}. Error: {ex.Message}");
                throw;
            }
        }
    }
}
