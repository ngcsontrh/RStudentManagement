using RStudentManagement.Core;
using RStudentManagement.Core.Logger;

namespace RStudentManagement
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            if (AppConfig.LoggerType == LoggerType.Console)
            {
                ConsoleManager.EnableConsole();
            }

            IMainFormBuilder mainFormBuilder = new MainFormBuilder()
                .WithMainForm(() => new StudentForm())
                .OnStart(() =>
                {
                    LoggerFactory.Instance.GetLogger(AppConfig.LoggerType)
                        .LogInfo("Application started");
                })
                .OnExit(() =>
                {
                    LoggerFactory.Instance.GetLogger(AppConfig.LoggerType)
                        .LogInfo("Application exited");
                });

            Application.Run(mainFormBuilder.Build());
        }
    }
}