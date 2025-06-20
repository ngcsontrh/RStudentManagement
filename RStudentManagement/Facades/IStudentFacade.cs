using RStudentManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RStudentManagement.Facades
{
    /// <summary>
    /// Interface cho mẫu thiết kế Facade cung cấp một giao diện đơn giản hóa để làm việc với hệ thống quản lý sinh viên
    /// Interface này che giấu sự phức tạp của các tương tác với nhiều hệ thống con như repository, service gửi email, và hệ thống ghi log
    /// </summary>
    public interface IStudentFacade
    {
        /// <summary>
        /// Thêm một sinh viên mới vào hệ thống, bao gồm lưu thông tin, ghi log, và gửi email thông báo
        /// </summary>
        /// <param name="student">Đối tượng sinh viên cần thêm vào hệ thống</param>
        /// <returns>Task đại diện cho hoạt động bất đồng bộ</returns>
        Task AddStudentAsync(Student student);

        /// <summary>
        /// Cập nhật thông tin của một sinh viên đã tồn tại, bao gồm cập nhật dữ liệu, ghi log và gửi email thông báo
        /// </summary>
        /// <param name="student">Đối tượng sinh viên với thông tin đã được cập nhật</param>
        /// <returns>Task đại diện cho hoạt động bất đồng bộ</returns>
        Task UpdateStudentAsync(Student student);

        /// <summary>
        /// Xóa một sinh viên khỏi hệ thống dựa vào ID, bao gồm xóa dữ liệu, ghi log và gửi email thông báo
        /// </summary>
        /// <param name="studentId">ID của sinh viên cần xóa</param>
        /// <returns>Task đại diện cho hoạt động bất đồng bộ</returns>
        Task DeleteStudentAsync(Guid studentId);

        /// <summary>
        /// Lấy danh sách tất cả sinh viên từ hệ thống
        /// </summary>
        /// <returns>Task chứa danh sách các đối tượng sinh viên</returns>
        Task<IEnumerable<Student>> GetAlStudentsAsync();
    }
}
