using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RStudentManagement.Mementos
{
    /// <summary>
    /// Lớp Memento trong mẫu thiết kế Memento, lưu trữ trạng thái của form sinh viên tại một thời điểm cụ thể
    /// Các thuộc tính đều là read-only để đảm bảo đối tượng Memento là bất biến (immutable)
    /// </summary>
    public class StudentFormMemento
    {
        /// <summary>
        /// Mã sinh viên được lưu trong trạng thái
        /// </summary>
        public string Code { get; }

        /// <summary>
        /// Họ tên sinh viên được lưu trong trạng thái
        /// </summary>
        public string FullName { get; }

        /// <summary>
        /// Ngày sinh được lưu trong trạng thái
        /// </summary>
        public DateTime DateOfBirth { get; }

        /// <summary>
        /// Email được lưu trong trạng thái
        /// </summary>
        public string Email { get; }

        /// <summary>
        /// Địa chỉ được lưu trong trạng thái
        /// </summary>
        public string Address { get; }

        /// <summary>
        /// Mã lớp được lưu trong trạng thái
        /// </summary>
        public string ClassCode { get; }

        /// <summary>
        /// Khởi tạo một đối tượng Memento mới với các thông tin trạng thái của form
        /// </summary>
        /// <param name="code">Mã sinh viên</param>
        /// <param name="fullName">Họ tên sinh viên</param>
        /// <param name="dob">Ngày sinh</param>
        /// <param name="email">Email</param>
        /// <param name="address">Địa chỉ</param>
        /// <param name="classCode">Mã lớp</param>
        public StudentFormMemento(string code, string fullName, DateTime dob, string email, string address, string classCode)
        {
            Code = code;
            FullName = fullName;
            DateOfBirth = dob;
            Email = email;
            Address = address;
            ClassCode = classCode;
        }
    }

}
