using System.Runtime.InteropServices;

namespace RStudentManagement.Core
{
    public static class ConsoleManager
    {
        [DllImport("kernel32.dll")]
        private static extern bool AllocConsole();

        [DllImport("kernel32.dll")]
        private static extern bool FreeConsole();

        public static void EnableConsole()
        {
            if (!AllocConsole())
            {
                throw new InvalidOperationException("Failed to allocate console.");
            }
        }

        public static void DisableConsole()
        {
            if (!FreeConsole())
            {
                throw new InvalidOperationException("Failed to free console.");
            }
        }
    }
}
