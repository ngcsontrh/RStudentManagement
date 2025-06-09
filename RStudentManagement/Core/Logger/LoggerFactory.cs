using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RStudentManagement.Core.Logger
{
    public enum LoggerType
    {
        Console,
        File
    }

    public class LoggerFactory
    {
        private LoggerFactory() { }

        public static LoggerFactory Instance { get; } = new LoggerFactory();

        public ILogger GetLogger(LoggerType loggerType)
        {
            return loggerType switch
            {
                LoggerType.Console => new Implements.ConsoleLogger(),
                LoggerType.File => new Implements.FileLogger(),
                _ => throw new ArgumentException("Invalid logger type", nameof(loggerType)),
            };
        }
    }
}
