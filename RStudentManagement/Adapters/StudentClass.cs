using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RStudentManagement.Adapters
{
    /// <summary>
    /// Lớp đại diện cho thông tin lớp học trong định dạng mà client mong muốn sử dụng
    /// Được sử dụng làm kết quả của quá trình chuyển đổi trong mẫu thiết kế Adapter
    /// </summary>
    public class StudentClass
    {
        /// <summary>
        /// Mã lớp học (ví dụ: CS102, M101)
        /// </summary>
        public string Code { get; set; } = string.Empty;

        /// <summary>
        /// Tên đầy đủ của lớp học (ví dụ: Computer Science 102, Mathematics 101)
        /// </summary>
        public string Name { get; set; } = string.Empty;
    }

}
