using System.ComponentModel.DataAnnotations;

namespace OTB.EmployeePayments.Core.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }

        [StringLength(255), Required]
        public string Name { get; set; }
        
        public int RoleId { get; set; }

        public Role Role { get; set; }
    }
}
