using System.Linq;
using NUnit.Framework;
using OTB.EmployeePayments.Core.Models;
using OTB.EmployeePayments.Core.Services;

namespace OTB.EmployeePayments.UnitTests
{
    [TestFixture]
    public class EmployeeServiceTests
    {
        private IEmployeeService _employeeService;

        [TestFixtureSetUp]
        public void Init()
        {
            // ARRANGE
            _employeeService = new EmployeeService(new TestSqlServerSettings());
            _employeeService.InitialiseData();
        }


        [TestCase]
        public void GetEmployeeSalaries_Test()
        {
            // ACT
            var list = _employeeService.GetEmployeeSalaries();

            // ASSERT
            //Make sure there are 5 employess setup
            Assert.IsTrue(list.Count == 5);
            
            const string homerSimpson = "Homer Simpson";
            var employee = list.FirstOrDefault(e => e.EmployeeName.Equals(homerSimpson));
            //make sure an employee exists
            Assert.IsTrue(employee != null);
            Assert.IsTrue(employee.EmployeeName.Equals(homerSimpson));
        }

        [TestCase]
        public void GetEmployeeSalariesByName_Test()
        {
            // ARRANGE
            const string homerSimpson = "Homer Simpson";

            // ACT
            var list = _employeeService.GetEmployeeSalariesByName(homerSimpson);

            // ASSERT
            //Make sure the employee is returned.
            Assert.IsTrue(list.Count == 1);
           
            var employee = list.FirstOrDefault(e => e.EmployeeName.Equals(homerSimpson));
            //make sure the employee exists
            Assert.IsTrue(employee != null);
            Assert.IsTrue(employee.EmployeeName.Equals(homerSimpson));
        }

        [TestCase]
        public void GetEmployeeSalariesByRole_Test()
        {
            // ARRANGE
            const string homerSimpson = "Homer Simpson";

            // ACT
            var list = _employeeService.GetEmployeeSalariesByRole(Role.RolesList.Staff.GetHashCode());

            // ASSERT
            //Make sure all the employees with STAFF are returned.
            Assert.IsTrue(list.Count == 3);

            var employee = list.FirstOrDefault(e => e.EmployeeName.Equals(homerSimpson));
            //make sure an employee with STAFF role exists
            Assert.IsTrue(employee != null);
            Assert.IsTrue(employee.EmployeeName.Equals(homerSimpson));
        }
    }
}
