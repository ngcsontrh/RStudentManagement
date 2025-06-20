using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RStudentManagement.Adapters
{
    /// <summary>
    /// Lớp Adapter trong mẫu thiết kế Adapter, chuyển đổi dữ liệu từ StudentClassesAdaptee sang định dạng mà client mong muốn
    /// Triển khai Object Adapter Pattern bằng cách sử dụng composition với đối tượng StudentClassesAdaptee
    /// </summary>
    public class StudentClassAdapter : IStudentClassAdapter
    {
        private readonly StudentClassesAdaptee _studentClassesAdaptee;

        /// <summary>
        /// Khởi tạo một thể hiện mới của StudentClassAdapter với adaptee được chỉ định
        /// </summary>
        /// <param name="studentClassesAdaptee">Đối tượng cung cấp dữ liệu lớp học ở định dạng gốc</param>
        public StudentClassAdapter(StudentClassesAdaptee studentClassesAdaptee)
        {
            _studentClassesAdaptee = studentClassesAdaptee;
        }

        /// <summary>
        /// Chuyển đổi danh sách lớp học từ định dạng chuỗi sang đối tượng StudentClass
        /// </summary>
        /// <returns>Danh sách các đối tượng StudentClass với thông tin Code và Name đã được trích xuất</returns>
        public List<StudentClass> GetStudentClasses()
        {
            var studentClasses = _studentClassesAdaptee.GetAvailableClasses();
            var adaptedClasses = new List<StudentClass>();
            foreach (var studentClass in studentClasses)
            {
                var classParts = studentClass.Split(" - ");
                if (classParts.Length == 2)
                {
                    adaptedClasses.Add(new StudentClass
                    {
                        Code = classParts[0],
                        Name = classParts[1]
                    });
                }
            }
            return adaptedClasses;
        }
    }
}
