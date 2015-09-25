using System.ComponentModel.DataAnnotations;

namespace OTB.EmployeePayments.Core.Models
{
    public class Currency
    {
        public int CurrencyId { get; set; }

        [StringLength(255), Required]
        public string Unit { get; set; }

        public decimal ConversionFactor { get; set; }
    }
}
