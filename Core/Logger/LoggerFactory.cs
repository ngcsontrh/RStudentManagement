using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Logger
{
    public enum LoggerType
    {
        Console,
        File
    }

    public class LoggerFactory
    {
        private static LoggerFactory? _instance;
        private static readonly object _lock = new object();

        private LoggerFactory() { }

        public static LoggerFactory Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new LoggerFactory();
                        }
                    }
                }
                return _instance;
            }
        }

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
