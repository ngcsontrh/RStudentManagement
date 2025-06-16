using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace RStudentManagement.Core
{
    public class DatabaseManager
    {
        private readonly string _connectionString;

        public DatabaseManager(string connectionString)
        {
            _connectionString = connectionString;
        }

        public SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }

        public void OpenConnection(SqlConnection connection)
        {
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
        }

        public void CloseConnection(SqlConnection connection)
        {
            if (connection.State != ConnectionState.Closed)
            {
                connection.Close();
            }
        }

        public DataTable ExecuteQuery(string query, SqlParameter[] parameters = null)
        {
            using (SqlConnection connection = GetConnection())
            {
                OpenConnection(connection);
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        return dataTable;
                    }
                }
            }
        }

        public int ExecuteNonQuery(string query, SqlParameter[] parameters = null)
        {
            using (SqlConnection connection = GetConnection())
            {
                OpenConnection(connection);
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }
                    return command.ExecuteNonQuery();
                }
            }
        }

        public bool TestConnection()
        {
            SqlConnection connection = null;
            try
            {
                connection = GetConnection();
                OpenConnection(connection);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi kết nối: " + ex.Message);
                return false;
            }
            finally
            {
                if (connection != null)
                {
                    CloseConnection(connection);
                }
            }
        }

        public void CreateTables()
        {
            // Bảng Accounts
            string createAccountsTable = @"
        IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Accounts')
        BEGIN
            CREATE TABLE Accounts (
                Id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
                UserName NVARCHAR(100) NOT NULL UNIQUE,
                Email NVARCHAR(100) NOT NULL,
                PasswordHash NVARCHAR(200) NOT NULL,
                Status NVARCHAR(20) NULL,
                CreatedAt DATETIME NOT NULL DEFAULT GETDATE()
            )
        END";

            // Bảng Students
            string createStudentsTable = @"
        IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Students')
        BEGIN
            CREATE TABLE Students (
                Id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
                Code NVARCHAR(20) NOT NULL UNIQUE,
                FirstName NVARCHAR(50) NOT NULL,
                LastName NVARCHAR(50) NOT NULL,
                DateOfBirth DATE NOT NULL,
                PlaceOfBirth NVARCHAR(100) NOT NULL,
                Gender NVARCHAR(10) NOT NULL,
                PhoneNumber NVARCHAR(20) NULL,
                Email NVARCHAR(100) NULL,
                CreatedAt DATETIME NOT NULL DEFAULT GETDATE()
            )
        END";

            // Bảng AuditLogs
            string createAuditLogsTable = @"
        IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'AuditLogs')
        BEGIN
            CREATE TABLE AuditLogs (
                Id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
                Action NVARCHAR(20) NOT NULL,
                EntityName NVARCHAR(100) NOT NULL,
                EntityId NVARCHAR(100) NOT NULL,
                Changes NVARCHAR(MAX) NOT NULL,
                Timestamp DATETIME NOT NULL DEFAULT GETDATE(),
                UserId UNIQUEIDENTIFIER NULL
            )
        END";

            // Bảng EventLogs
            string createEventLogsTable = @"
        IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'EventLogs')
        BEGIN
            CREATE TABLE EventLogs (
                Id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
                EventType NVARCHAR(20) NOT NULL,
                Description NVARCHAR(500) NOT NULL,
                Timestamp DATETIME NOT NULL DEFAULT GETDATE(),
                UserId UNIQUEIDENTIFIER NULL
            )
        END";

            ExecuteNonQuery(createAccountsTable);
            ExecuteNonQuery(createStudentsTable);
            ExecuteNonQuery(createAuditLogsTable);
            ExecuteNonQuery(createEventLogsTable);
        }

      

        public void InsertSampleStudents()
        {
            string query = @"
        IF NOT EXISTS (SELECT * FROM Students WHERE Code = 'SV001')
        BEGIN
            INSERT INTO Students (Code, FirstName, LastName, DateOfBirth, PlaceOfBirth, Gender, Email, PhoneNumber)
            VALUES 
            ('SV001', N'Nguyễn Văn', N'A', '2000-01-15', N'Hà Nội', N'Nam', 'nguyenvana@email.com', '0123456789'),
            ('SV002', N'Trần Thị', N'B', '2001-03-20', N'Hồ Chí Minh', N'Nữ', 'tranthib@email.com', '0987654321')
        END";

            ExecuteNonQuery(query);
        }

            public void InsertSampleAccounts()
        {
            string query = @"
                IF NOT EXISTS (SELECT * FROM Accounts WHERE UserName = 'admin')
                BEGIN
                    INSERT INTO Accounts (UserName, Email, PasswordHash, Status, CreatedAt)
                    VALUES ('admin', 'admin@email.com', 'admin123', 'Active', GETDATE())
                END
                IF NOT EXISTS (SELECT * FROM Accounts WHERE UserName = 'user1')
                BEGIN
                    INSERT INTO Accounts (UserName, Email, PasswordHash, Status, CreatedAt)
                    VALUES ('user1', 'user1@email.com', 'user123', 'Active', GETDATE())
                END
            ";
            ExecuteNonQuery(query);
        }
    }
} 