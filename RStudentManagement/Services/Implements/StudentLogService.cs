using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Threading.Tasks;
using RStudentManagement.Core;
using RStudentManagement.Entities;

namespace RStudentManagement.Services.Implements
{
    public class StudentLogService : IStudentService
    {
        private readonly DatabaseManager _databaseManager;

        public StudentLogService(DatabaseManager databaseManager)
        {
            _databaseManager = databaseManager;
        }

        public async Task<bool> AddStudentAsync(Student student)
        {
            string query = "INSERT INTO Students (Id, Code, FirstName, LastName, DateOfBirth, PlaceOfBirth, Gender, Email, PhoneNumber, CreatedAt) VALUES (@Id, @Code, @FirstName, @LastName, @DateOfBirth, @PlaceOfBirth, @Gender, @Email, @PhoneNumber, @CreatedAt)";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Id", student.Id),
                new SqlParameter("@Code", student.Code),
                new SqlParameter("@FirstName", student.FirstName),
                new SqlParameter("@LastName", student.LastName),
                new SqlParameter("@DateOfBirth", student.DateOfBirth),
                new SqlParameter("@PlaceOfBirth", student.PlaceOfBirth),
                new SqlParameter("@Gender", student.Gender),
                new SqlParameter("@Email", student.Email),
                new SqlParameter("@PhoneNumber", student.PhoneNumber),
                new SqlParameter("@CreatedAt", student.CreatedAt)
            };

            int result = _databaseManager.ExecuteNonQuery(query, parameters);
            return result > 0;
        }

        public async Task<bool> DeleteStudentAsync(Student student)
        {
            string query = "DELETE FROM Students WHERE Id = @Id";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Id", student.Id)
            };

            int result = _databaseManager.ExecuteNonQuery(query, parameters);
            return result > 0;
        }

        public async Task<IEnumerable<Student>> GetAllStudentsAsync()
        {
            string query = "SELECT * FROM Students";
            DataTable dataTable = _databaseManager.ExecuteQuery(query);

            List<Student> students = new List<Student>();
            foreach (DataRow row in dataTable.Rows)
            {
                students.Add(new Student
                {
                    Id = (Guid)row["Id"],
                    Code = row["Code"].ToString(),
                    FirstName = row["FirstName"].ToString(),
                    LastName = row["LastName"].ToString(),
                    DateOfBirth = (DateTime)row["DateOfBirth"],
                    PlaceOfBirth = row["PlaceOfBirth"].ToString(),
                    Gender = row["Gender"].ToString(),
                    Email = row["Email"].ToString(),
                    PhoneNumber = row["PhoneNumber"].ToString(),
                    CreatedAt = (DateTime)row["CreatedAt"]
                });
            }

            return students;
        }

        public async Task<Student?> GetStudentByIdAsync(Guid studentId)
        {
            string query = "SELECT * FROM Students WHERE Id = @Id";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Id", studentId)
            };

            DataTable dataTable = _databaseManager.ExecuteQuery(query, parameters);
            if (dataTable.Rows.Count > 0)
            {
                DataRow row = dataTable.Rows[0];
                return new Student
                {
                    Id = (Guid)row["Id"],
                    Code = row["Code"].ToString(),
                    FirstName = row["FirstName"].ToString(),
                    LastName = row["LastName"].ToString(),
                    DateOfBirth = (DateTime)row["DateOfBirth"],
                    PlaceOfBirth = row["PlaceOfBirth"].ToString(),
                    Gender = row["Gender"].ToString(),
                    Email = row["Email"].ToString(),
                    PhoneNumber = row["PhoneNumber"].ToString(),
                    CreatedAt = (DateTime)row["CreatedAt"]
                };
            }

            return null;
        }

        public async Task<bool> UpdateStudentAsync(Student student)
        {
            string query = "UPDATE Students SET Code = @Code, FirstName = @FirstName, LastName = @LastName, DateOfBirth = @DateOfBirth, PlaceOfBirth = @PlaceOfBirth, Gender = @Gender, Email = @Email, PhoneNumber = @PhoneNumber WHERE Id = @Id";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Id", student.Id),
                new SqlParameter("@Code", student.Code),
                new SqlParameter("@FirstName", student.FirstName),
                new SqlParameter("@LastName", student.LastName),
                new SqlParameter("@DateOfBirth", student.DateOfBirth),
                new SqlParameter("@PlaceOfBirth", student.PlaceOfBirth),
                new SqlParameter("@Gender", student.Gender),
                new SqlParameter("@Email", student.Email),
                new SqlParameter("@PhoneNumber", student.PhoneNumber)
            };

            int result = _databaseManager.ExecuteNonQuery(query, parameters);
            return result > 0;
        }

        public void LogStudentActivity(Student student, string activity)
        {
            string query = "INSERT INTO StudentLogs (StudentId, Activity, LogDate) VALUES (@StudentId, @Activity, @LogDate)";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@StudentId", student.Id),
                new SqlParameter("@Activity", activity),
                new SqlParameter("@LogDate", DateTime.Now)
            };

            _databaseManager.ExecuteNonQuery(query, parameters);
        }

        public DataTable GetStudentLogs(int studentId)
        {
            string query = "SELECT * FROM StudentLogs WHERE StudentId = @StudentId";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@StudentId", studentId)
            };

            return _databaseManager.ExecuteQuery(query, parameters);
        }
    }
}
