﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RStudentManagement.Loggers
{
    public sealed class FileLogger
    {
        private readonly string _filePath;
        private readonly object _lock;

        private FileLogger()
        {
            var logDir = Path.Combine(AppContext.BaseDirectory, "Logs");
            if (!Directory.Exists(logDir))
            {
                Directory.CreateDirectory(logDir);
            }

            _filePath = Path.Combine(logDir, $"{DateTime.UtcNow:yyyyMMdd}.txt");
            _lock = new object();
        }

        public static FileLogger Instance { get; } = new FileLogger();

        public void LogInfo(string message)
        {
            lock (_lock)
            {
                var logMessage = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} [INFO] {message}";
                File.AppendAllText(_filePath, logMessage + Environment.NewLine);
            }
        }

        public void LogError(string message, Exception? ex = null)
        {
            lock (_lock)
            {
                var logMessage = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} [ERROR] {message}";
                if (ex != null)
                {
                    logMessage += Environment.NewLine + ex.ToString();
                }
                File.AppendAllText(_filePath, logMessage + Environment.NewLine);
            }
        }
    }
}
