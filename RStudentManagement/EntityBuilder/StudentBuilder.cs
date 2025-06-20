using RStudentManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RStudentManagement.EntityBuilder
{
    /// <summary>
    /// Giao diện định nghĩa các phương thức để xây dựng đối tượng Student theo mẫu thiết kế Builder
    /// </summary>
    public interface IStudentBuilder
    {
        /// <summary>
        /// Thiết lập mã sinh viên
        /// </summary>
        /// <param name="code">Mã sinh viên</param>
        /// <returns>Builder hiện tại để hỗ trợ method chaining</returns>
        StudentBuilder WithCode(string code);

        /// <summary>
        /// Thiết lập họ tên sinh viên
        /// </summary>
        /// <param name="fullName">Họ tên đầy đủ của sinh viên</param>
        /// <returns>Builder hiện tại để hỗ trợ method chaining</returns>
        StudentBuilder WithFullName(string fullName);

        /// <summary>
        /// Thiết lập ngày sinh của sinh viên
        /// </summary>
        /// <param name="dateOfBirth">Ngày sinh của sinh viên</param>
        /// <returns>Builder hiện tại để hỗ trợ method chaining</returns>
        StudentBuilder WithDateOfBirth(DateTime dateOfBirth);

        /// <summary>
        /// Thiết lập địa chỉ của sinh viên
        /// </summary>
        /// <param name="address">Địa chỉ của sinh viên</param>
        /// <returns>Builder hiện tại để hỗ trợ method chaining</returns>
        StudentBuilder WithAddress(string address);

        /// <summary>
        /// Thiết lập email của sinh viên
        /// </summary>
        /// <param name="email">Địa chỉ email của sinh viên</param>
        /// <returns>Builder hiện tại để hỗ trợ method chaining</returns>
        StudentBuilder WithEmail(string email);

        /// <summary>
        /// Thiết lập lớp của sinh viên
        /// </summary>
        /// <param name="clazz">Tên lớp của sinh viên</param>
        /// <returns>Builder hiện tại để hỗ trợ method chaining</returns>
        StudentBuilder WithClass(string clazz);

        /// <summary>
        /// Tạo và trả về đối tượng Student với các thuộc tính đã được thiết lập
        /// </summary>
        /// <returns>Đối tượng Student hoàn chỉnh</returns>
        Student Build();
    }

    /// <summary>
    /// Lớp triển khai mẫu thiết kế Builder để xây dựng đối tượng Student theo cách trực quan và linh hoạt
    /// </summary>
    public class StudentBuilder : IStudentBuilder
    {
        private readonly Student _student = new Student();

        /// <summary>
        /// Thiết lập mã sinh viên
        /// </summary>
        /// <param name="code">Mã sinh viên</param>
        /// <returns>Builder hiện tại để hỗ trợ method chaining</returns>
        public StudentBuilder WithCode(string code)
        {
            _student.Code = code;
            return this;
        }

        /// <summary>
        /// Thiết lập họ tên sinh viên
        /// </summary>
        /// <param name="fullName">Họ tên đầy đủ của sinh viên</param>
        /// <returns>Builder hiện tại để hỗ trợ method chaining</returns>
        public StudentBuilder WithFullName(string fullName)
        {
            _student.FullName = fullName;
            return this;
        }

        /// <summary>
        /// Thiết lập ngày sinh của sinh viên
        /// </summary>
        /// <param name="dateOfBirth">Ngày sinh của sinh viên</param>
        /// <returns>Builder hiện tại để hỗ trợ method chaining</returns>
        public StudentBuilder WithDateOfBirth(DateTime dateOfBirth)
        {
            _student.DateOfBirth = dateOfBirth;
            return this;
        }

        /// <summary>
        /// Thiết lập địa chỉ của sinh viên
        /// </summary>
        /// <param name="address">Địa chỉ của sinh viên</param>
        /// <returns>Builder hiện tại để hỗ trợ method chaining</returns>
        public StudentBuilder WithAddress(string address)
        {
            _student.Address = address;
            return this;
        }

        /// <summary>
        /// Thiết lập email của sinh viên
        /// </summary>
        /// <param name="email">Địa chỉ email của sinh viên</param>
        /// <returns>Builder hiện tại để hỗ trợ method chaining</returns>
        public StudentBuilder WithEmail(string email)
        {
            _student.Email = email;
            return this;
        }

        /// <summary>
        /// Thiết lập lớp của sinh viên
        /// </summary>
        /// <param name="clazz">Tên lớp của sinh viên</param>
        /// <returns>Builder hiện tại để hỗ trợ method chaining</returns>
        public StudentBuilder WithClass(string clazz)
        {
            _student.Class = clazz;
            return this;
        }

        /// <summary>
        /// Tạo và trả về đối tượng Student với các thuộc tính đã được thiết lập
        /// </summary>
        /// <returns>Đối tượng Student hoàn chỉnh</returns>
        public Student Build()
        {
            return _student;
        }        
    }
}
