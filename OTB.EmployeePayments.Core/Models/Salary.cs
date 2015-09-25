using System.ComponentModel.DataAnnotations;

namespace OTB.EmployeePayments.Core.Models
{
    public class Salary
    {
        [Key]
        public int SalaryId { get; set; }

        public int EmployeeId { get; set; }

        public int CurrencyId { get; set; }

        public long AnnualAmount { get; set; }

        public Employee Employee { get; set; }
        public Currency Currency { get; set; }
    }
}
