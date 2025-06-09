using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Logger.Implements
{
    public sealed class ConsoleLogger : ILogger
    {
        public void LogInfo(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"{DateTime.Now:yyyy-MM-dd HH:mm:ss} [INFO] ");
            Console.ResetColor();
            Console.Write($"{message}\n");
        }
        public void LogError(string message, Exception? ex = null)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            if (ex != null)
            {
                message += Environment.NewLine + ex.ToString();
            }
            Console.Write($"{DateTime.Now:yyyy-MM-dd HH:mm:ss} [ERROR] ");
            Console.ResetColor();
            Console.Write($"{message}\n");
        }
    }
}
