using EmployeeTask.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace EmployeeTask.DatabaseContext
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : base(options) { }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeJobHistory> EmployeeJobHistories { get; set; }
        public DbSet<Position> Positions { get; set; }
    }
}
