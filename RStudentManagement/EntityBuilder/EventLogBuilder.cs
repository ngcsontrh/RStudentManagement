using RStudentManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RStudentManagement.EntityBuilder
{
    public interface IEventLogBuilder
    {
        EventLogBuilder WithEventType(string eventType);
        EventLogBuilder WithDescription(string description);
        EventLog Build();
    }

    public class EventLogBuilder
    {
        private readonly EventLog _eventLog = new EventLog();
        public EventLogBuilder WithEventType(string eventType)
        {
            _eventLog.EventType = eventType;
            return this;
        }
        public EventLogBuilder WithDescription(string description)
        {
            _eventLog.Description = description;
            return this;
        }
        public EventLog Build()
        {
            return _eventLog;
        }
    }
}
