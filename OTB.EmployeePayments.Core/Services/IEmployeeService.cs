using System.Collections.Generic;
using OTB.EmployeePayments.Core.Models;

namespace OTB.EmployeePayments.Core.Services
{
    public interface IEmployeeService
    {
        void InitialiseData();
        List<EmployeeSalary> GetEmployeeSalaries();
        List<EmployeeSalary> GetEmployeeSalariesByName(string name);
        List<EmployeeSalary> GetEmployeeSalariesByRole(int roleId);
    }
}