using Distributed_Caching.Models;
using Microsoft.EntityFrameworkCore;

namespace Distributed_Caching.Data
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeId = 1,
                FirstName = "Hassan",
                LastName = "Jalali",
                DateOfBirth = new DateTime(1375, 05, 20),
                Email = "MisterDeveloper@yahoo.com",
                PhoneNumber = "0901615****"
            }, new Employee
            {
                EmployeeId = 2,
                FirstName = "Ali",
                LastName = "Salempanah",
                DateOfBirth = new DateTime(1369, 09, 11),
                Email = "AliSalempanah@yahoo.com",
                PhoneNumber = "0935928****"
            });
        }
        public DbSet<Employee> Employees { get; set; }
    }
}
