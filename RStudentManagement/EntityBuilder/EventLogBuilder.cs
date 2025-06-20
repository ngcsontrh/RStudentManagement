using RStudentManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RStudentManagement.EntityBuilder
{
    /// <summary>
    /// Giao diện định nghĩa các phương thức để xây dựng đối tượng EventLog theo mẫu thiết kế Builder
    /// </summary>
    public interface IEventLogBuilder
    {
        /// <summary>
        /// Thiết lập loại sự kiện
        /// </summary>
        /// <param name="eventType">Loại sự kiện (ví dụ: StudentCreated, StudentUpdated)</param>
        /// <returns>Builder hiện tại để hỗ trợ method chaining</returns>
        EventLogBuilder WithEventType(string eventType);

        /// <summary>
        /// Thiết lập mô tả sự kiện
        /// </summary>
        /// <param name="description">Mô tả chi tiết về sự kiện</param>
        /// <returns>Builder hiện tại để hỗ trợ method chaining</returns>
        EventLogBuilder WithDescription(string description);

        /// <summary>
        /// Tạo và trả về đối tượng EventLog với các thuộc tính đã được thiết lập
        /// </summary>
        /// <returns>Đối tượng EventLog hoàn chỉnh</returns>
        EventLog Build();
    }

    /// <summary>
    /// Lớp triển khai mẫu thiết kế Builder để xây dựng đối tượng EventLog theo cách trực quan và linh hoạt
    /// </summary>
    public class EventLogBuilder
    {
        private readonly EventLog _eventLog = new EventLog();

        /// <summary>
        /// Thiết lập loại sự kiện
        /// </summary>
        /// <param name="eventType">Loại sự kiện (ví dụ: StudentCreated, StudentUpdated)</param>
        /// <returns>Builder hiện tại để hỗ trợ method chaining</returns>
        public EventLogBuilder WithEventType(string eventType)
        {
            _eventLog.EventType = eventType;
            return this;
        }

        /// <summary>
        /// Thiết lập mô tả sự kiện
        /// </summary>
        /// <param name="description">Mô tả chi tiết về sự kiện</param>
        /// <returns>Builder hiện tại để hỗ trợ method chaining</returns>
        public EventLogBuilder WithDescription(string description)
        {
            _eventLog.Description = description;
            return this;
        }

        /// <summary>
        /// Tạo và trả về đối tượng EventLog với các thuộc tính đã được thiết lập
        /// </summary>
        /// <returns>Đối tượng EventLog hoàn chỉnh</returns>
        public EventLog Build()
        {
            return _eventLog;
        }
    }
}
