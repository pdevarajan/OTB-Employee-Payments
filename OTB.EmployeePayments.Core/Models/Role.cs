using System.ComponentModel.DataAnnotations;

namespace OTB.EmployeePayments.Core.Models
{
    public class Role
    {
        [Key]
        public int RoleId { get; set; }

        [StringLength(255), Required]
        public string Name { get; set; }

        public enum RolesList
        {
            Staff = 1,
            Manager = 2,
            Owner = 3
        }
    }
}
