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
    /// <summary>
    /// Lớp triển khai mẫu thiết kế Facade để đơn giản hóa việc tương tác với hệ thống quản lý sinh viên
    /// Lớp này phối hợp làm việc với các hệ thống con như repository sinh viên, repository sự kiện,
    /// repository email, dịch vụ gửi email và hệ thống ghi log để thực hiện các thao tác quản lý sinh viên
    /// </summary>
    public class StudentFacade : IStudentFacade
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IEventLogRepository _eventLogRepository;
        private readonly IMailRepository _mailRepository;
        private readonly IMailService _mailService;

        /// <summary>
        /// Khởi tạo một thể hiện mới của StudentFacade với các hệ thống con mặc định
        /// </summary>
        public StudentFacade()
        {
            _studentRepository = new StudentRepository();
            _eventLogRepository = new EventLogRepository();
            _mailRepository = new MailRepository();
            _mailService = new MailService();
        }

        /// <summary>
        /// Thêm một sinh viên mới vào hệ thống, đồng thời xử lý các tác vụ phụ như ghi log và gửi email
        /// </summary>
        /// <param name="student">Đối tượng sinh viên cần thêm</param>
        /// <returns>Task đại diện cho hoạt động bất đồng bộ</returns>
        /// <exception cref="ArgumentNullException">Được ném ra khi đối tượng sinh viên là null</exception>
        public async Task AddStudentAsync(Student student)
        {
            if (student == null)
            {
                throw new ArgumentNullException(nameof(student), "Student cannot be null");
            }
            try
            {
                await _studentRepository.AddAsync(student);
                await _eventLogRepository.AddAsync(new EventLogBuilder()
                    .WithEventType("StudentCreated")
                    .WithDescription($"Student {student.FullName} has been created")
                    .Build());
                await _mailService.SendEmailAsync(student.Email, "Welcome to RStudentManagement", $"Student {student.FullName} has been created");
                await _mailRepository.AddAsync(new MailBuilder()
                    .WithEmail(student.Email)
                    .WithTitle("Welcome to RStudentManagement")
                    .WithBody($"Student {student.FullName} has been created")
                    .Build());                
                FileLogger.Instance.LogInfo($"Student {student.FullName} has been added successfully.");
            }
            catch (Exception ex)
            {
                FileLogger.Instance.LogError($"Failed to add student {student.FullName}. Error: {ex.Message}");
                throw;
            }            
        }

        /// <summary>
        /// Xóa một sinh viên khỏi hệ thống dựa vào ID, đồng thời xử lý các tác vụ phụ như ghi log và gửi email
        /// </summary>
        /// <param name="studentId">ID của sinh viên cần xóa</param>
        /// <returns>Task đại diện cho hoạt động bất đồng bộ</returns>
        /// <exception cref="ArgumentException">Được ném ra khi ID sinh viên trống (empty GUID)</exception>
        /// <exception cref="KeyNotFoundException">Được ném ra khi không tìm thấy sinh viên với ID chỉ định</exception>
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
                await _eventLogRepository.AddAsync(new EventLogBuilder()
                    .WithEventType("StudentDeleted")
                    .WithDescription($"Student with ID {studentId} has been deleted.")
                    .Build());
                await _mailService.SendEmailAsync(student.Email, "Account Deletion", $"Your account with ID {studentId} has been deleted.");
                await _mailRepository.AddAsync(new MailBuilder()
                    .WithEmail(student.Email)
                    .WithTitle("Account Deletion")
                    .WithBody($"Your account with ID {studentId} has been deleted.")
                    .Build());                
                FileLogger.Instance.LogInfo($"Student with ID {studentId} has been deleted successfully.");
            }
            catch (Exception ex)
            {
                FileLogger.Instance.LogError($"Failed to delete student with ID {studentId}. Error: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Lấy danh sách tất cả sinh viên từ hệ thống
        /// </summary>
        /// <returns>Task chứa danh sách các đối tượng sinh viên</returns>
        public Task<IEnumerable<Student>> GetAlStudentsAsync()
        {
            return _studentRepository.GetAllAsync();
        }

        /// <summary>
        /// Cập nhật thông tin của một sinh viên đã tồn tại, đồng thời xử lý các tác vụ phụ như ghi log và gửi email
        /// </summary>
        /// <param name="student">Đối tượng sinh viên với thông tin đã được cập nhật</param>
        /// <returns>Task đại diện cho hoạt động bất đồng bộ</returns>
        /// <exception cref="ArgumentNullException">Được ném ra khi đối tượng sinh viên là null</exception>
        public async Task UpdateStudentAsync(Student student)
        {
            try
            {
                if (student == null)
                {
                    throw new ArgumentNullException(nameof(student), "Student cannot be null");
                }
                await _studentRepository.UpdateAsync(student);
                await _eventLogRepository.AddAsync(new EventLogBuilder()
                    .WithEventType("StudentUpdated")
                    .WithDescription($"Student {student.FullName} has been updated.")
                    .Build());
                await _mailService.SendEmailAsync(student.Email, "Account Update", $"Your account with ID {student.Id} has been updated.");
                await _mailRepository.AddAsync(new MailBuilder()
                    .WithEmail(student.Email)
                    .WithTitle("Account Update")
                    .WithBody($"Your account with ID {student.Id} has been updated.")
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
