using Demo.DomainModels.Entities;
using Microsoft.EntityFrameworkCore;

namespace Demo.DAL
{
    public class DemoDbContext : DbContext
    {
        #region Ctor
        public DemoDbContext(DbContextOptions<DemoDbContext> options) : base(options)
        {

        }
        #endregion

        #region Db Tables

        public DbSet<Task> Tasks { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<EmploymentType> EmploymentTypes { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeTask> EmployeeTasks { get; set; }

        #endregion
    }
}
