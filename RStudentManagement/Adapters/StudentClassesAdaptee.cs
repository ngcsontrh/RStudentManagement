using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RStudentManagement.Adapters
{
    /// <summary>
    /// Lớp Adaptee trong mẫu thiết kế Adapter, cung cấp dữ liệu lớp học ở định dạng gốc không phù hợp trực tiếp với nhu cầu của client
    /// Đây là lớp mà chúng ta cần thích ứng thông qua Adapter
    /// </summary>
    public class StudentClassesAdaptee
    {
        /// <summary>
        /// Lấy danh sách các lớp học có sẵn trong hệ thống ở định dạng chuỗi
        /// Mỗi chuỗi chứa cả mã lớp và tên lớp, được phân cách bằng " - "
        /// </summary>
        /// <returns>Danh sách chuỗi chứa thông tin lớp học ở định dạng "Mã - Tên"</returns>
        public List<string> GetAvailableClasses()
        {
            return new List<string>
            {
                "M101 - Mathematics 101",
                "CS102 - Computer Science 102",
                "M103 - Mathematics 103",
                "CS104 - Computer Science 104",
                "PHY105 - Physics 105"
            };
        }
    }
}
