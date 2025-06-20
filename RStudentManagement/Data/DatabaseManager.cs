using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RStudentManagement.Data
{
    public class DatabaseManager
    {

        private readonly string _connectionString;
        private readonly DbContextOptions<AppDbContext> _options;

        private DatabaseManager()
        {
            _connectionString = "Server=localhost;Database=RStudentManagement;User Id=sa;Password=password;TrustServerCertificate=True;";
            _options = new DbContextOptionsBuilder<AppDbContext>()
                .UseSqlServer(_connectionString)
                .Options;
        }

        public static DatabaseManager Instance { get; } = new DatabaseManager();

        public AppDbContext GetConnection()
        {
            return new AppDbContext(_options);
        }
    }
}
