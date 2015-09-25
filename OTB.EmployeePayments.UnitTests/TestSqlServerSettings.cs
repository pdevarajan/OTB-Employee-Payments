using System.Configuration;
using OTB.EmployeePayments.Core;

namespace OTB.EmployeePayments.UnitTests
{
    public class TestSqlServerSettings : ISettings
    {
        public string DatabaseConnectionString
        {
            get { return ConfigurationManager.ConnectionStrings["SQLServerConnectionString"].ConnectionString; } 
        }
    }
}