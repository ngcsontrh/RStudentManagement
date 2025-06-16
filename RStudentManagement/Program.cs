using RStudentManagement.Core;
using RStudentManagement.Core.Logger;
using System;

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

            LoggerFactory.Instance
                .GetLogger(AppConfig.LoggerType)
                .LogInfo("Application starting...");

            IMainFormBuilder mainFormBuilder = new MainFormBuilder()
                .WithMainForm(() => new LoginForm())
                .OnStart(() =>
                {
                    LoggerFactory.Instance
                        .GetLogger(AppConfig.LoggerType)
                        .LogInfo("Application started.");                    
                })
                .OnLoad(() =>
                {
                    if (!NetworkManager.Instance.IsInternetAvailable())
                    {                        
                        LoggerFactory.Instance
                            .GetLogger(AppConfig.LoggerType)
                            .LogError("No internet connection detected.");

                        MessageBox.Show(
                            "No internet connection detected. Please check your network settings.", 
                            "Network Error", 
                            MessageBoxButtons.OK, 
                            MessageBoxIcon.Error);
                    }
                })
                .OnExit(() =>
                {
                    LoggerFactory.Instance
                        .GetLogger(AppConfig.LoggerType)
                        .LogInfo("Application exited.");
                });

            // Khởi tạo DatabaseManager
            var databaseManager = new DatabaseManager(AppConfig.DbConnectionString);

            // Kiểm tra kết nối đến database
            if (databaseManager.TestConnection())
            {
                Console.WriteLine("Database connection successful.");
                // Gọi phương thức CreateTables để tạo các bảng
                databaseManager.CreateTables();
                databaseManager.InsertSampleStudents();
                databaseManager.InsertSampleAccounts();
            }
            else
            {
                Console.WriteLine("Database connection failed.");
                return;
            }

            Application.Run(mainFormBuilder.Build());
        }
    }
}