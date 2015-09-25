using System.Globalization;

namespace OTB.EmployeePayments.Core.Models
{
    public class EmployeeSalary
    {
        public string EmployeeName { get; set; }
        // ReSharper disable once InconsistentNaming
        public decimal AnnualSalaryGBP { get; set; }

        public override string ToString()
        {
            return string.Format("Employee: {0, -20} | Annual Salary: {1, 15}", EmployeeName, AnnualSalaryGBP.ToString("C", new CultureInfo("en-GB")));
        }
    }
}