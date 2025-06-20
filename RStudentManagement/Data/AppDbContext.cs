using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RStudentManagement.Data
{
    /// <summary>
    /// Không sử dụng trực tiếp, sử dụng thông qua DatabaseManager
    /// </summary>
    public class AppDbContext : DbContext
    {
        public DbSet<Entities.Student> Students { get; set; } = null!;
        public DbSet<Entities.Mail> Mails { get; set; } = null!;
        public DbSet<Entities.EventLog> EventLogs { get; set; } = null!;
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Entities.Student>().ToTable("Student");
            modelBuilder.Entity<Entities.Mail>().ToTable("Mail");
            modelBuilder.Entity<Entities.EventLog>().ToTable("EventLog");
        }
    }
}
