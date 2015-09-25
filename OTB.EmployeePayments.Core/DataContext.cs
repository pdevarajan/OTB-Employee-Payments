using System.Data.Entity;
using OTB.EmployeePayments.Core.Models;

namespace OTB.EmployeePayments.Core
{
    public class DataContext : DbContext
    {
        public DataContext(ISettings settings)
            : base(settings.DatabaseConnectionString)
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<DataContext>());
        }

        public DbSet<Role> Roles { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Salary> Salaries { get; set; }
    }
}
