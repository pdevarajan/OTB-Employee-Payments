using System.Configuration;
using OTB.EmployeePayments.Core;

namespace OTB.EmployeePayments.ConsoleHost
{
    public class AppSettings: ISettings
    {
        public string DatabaseConnectionString
        {
            get 
            {
                return ConfigurationManager.ConnectionStrings["SQLServerConnectionString"].ConnectionString;
            }
        }
    }
}
