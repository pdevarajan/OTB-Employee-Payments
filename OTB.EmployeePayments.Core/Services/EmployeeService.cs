using System;
using System.Collections.Generic;
using System.Linq;
using OTB.EmployeePayments.Core.Models;

namespace OTB.EmployeePayments.Core.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ISettings _settings;

        public EmployeeService(ISettings settings)
        {
            if (settings == null) throw new ArgumentNullException("settings");
            _settings = settings;
        }

        public void InitialiseData()
        {
            using (var context = new DataContext(_settings))
            {
                var roles = new List<Role>
                {
                    new Role {RoleId = 1, Name = "Staff"},
                    new Role {RoleId = 2, Name = "Manager"},
                    new Role {RoleId = 3, Name = "Owner"}
                };

                var employees = new List<Employee>
                {
                    new Employee {EmployeeId = 1, Name = "Homer Simpson", RoleId = 1},
                    new Employee {EmployeeId = 2, Name = "Sterling Archer", RoleId = 1},
                    new Employee {EmployeeId = 3, Name = "Eric Cartman", RoleId = 1},
                    new Employee {EmployeeId = 4, Name = "Fred Flintstone", RoleId = 2},
                    new Employee {EmployeeId = 5, Name = "Professor Farnsworth", RoleId = 3}
                };

                var currencies = new List<Currency>
                {
                    new Currency {CurrencyId = 1, Unit = "GBP", ConversionFactor = 1},
                    new Currency {CurrencyId = 2, Unit = "USD", ConversionFactor = (decimal) 1.54},
                    new Currency {CurrencyId = 3, Unit = "Rocks", ConversionFactor = 10},
                    new Currency {CurrencyId = 4, Unit = "Sweets", ConversionFactor = 12},
                    new Currency {CurrencyId = 5, Unit = "Credits", ConversionFactor = 8000}
                };

                var salaries = new List<Salary>
                {
                    new Salary {SalaryId = 1, EmployeeId = 1, CurrencyId = 2, AnnualAmount = 22000},
                    new Salary {SalaryId = 2, EmployeeId = 2, CurrencyId = 2, AnnualAmount = 150000},
                    new Salary {SalaryId = 3, EmployeeId = 3, CurrencyId = 4, AnnualAmount = 60000},
                    new Salary {SalaryId = 4, EmployeeId = 4, CurrencyId = 3, AnnualAmount = 900000},
                    new Salary {SalaryId = 5, EmployeeId = 5, CurrencyId = 5, AnnualAmount = 5000000000}
                };

                foreach (var role in roles)
                {
                    context.Roles.Add(role);
                }

                foreach (var employee in employees)
                {
                    context.Employees.Add(employee);
                }

                foreach (var currency in currencies)
                {
                    context.Currencies.Add(currency);
                }

                foreach (var salary in salaries)
                {
                    context.Salaries.Add(salary);
                }

                context.SaveChanges();

            }
        }

        public List<EmployeeSalary> GetEmployeeSalaries()
        {
            using (var context = new DataContext(_settings))
            {
                var employeeSalaries = from employee in context.Employees
                                       join salary in context.Salaries on employee.EmployeeId equals salary.EmployeeId
                                       join currency in context.Currencies on salary.CurrencyId equals currency.CurrencyId
                                       select
                                           new EmployeeSalary()
                                           {
                                               EmployeeName = employee.Name,
                                               AnnualSalaryGBP = Math.Round(salary.AnnualAmount / currency.ConversionFactor, 2)
                                           };

                return employeeSalaries.ToList();
            }
        }

        public List<EmployeeSalary> GetEmployeeSalariesByName(string name)
        {
            using (var context = new DataContext(_settings))
            {
                var employeeSalaries = from employee in context.Employees
                                       join salary in context.Salaries on employee.EmployeeId equals salary.EmployeeId
                                       join currency in context.Currencies on salary.CurrencyId equals currency.CurrencyId
                                       where employee.Name.Contains(name)
                                       orderby Math.Round(salary.AnnualAmount / currency.ConversionFactor, 2) descending
                                       select
                                           new EmployeeSalary()
                                           {
                                               EmployeeName = employee.Name,
                                               AnnualSalaryGBP = Math.Round(salary.AnnualAmount / currency.ConversionFactor, 2)
                                           };

                return employeeSalaries.ToList();
            }
        }

        public List<EmployeeSalary> GetEmployeeSalariesByRole(int roleId)
        {
            using (var context = new DataContext(_settings))
            {
                var employeeSalaries = from employee in context.Employees
                                       join salary in context.Salaries on employee.EmployeeId equals salary.EmployeeId
                                       join currency in context.Currencies on salary.CurrencyId equals currency.CurrencyId
                                       where employee.RoleId == roleId
                                       orderby Math.Round(salary.AnnualAmount / currency.ConversionFactor, 2) descending
                                       select
                                           new EmployeeSalary()
                                           {
                                               EmployeeName = employee.Name,
                                               AnnualSalaryGBP = Math.Round(salary.AnnualAmount / currency.ConversionFactor, 2)
                                           };

                return employeeSalaries.ToList();
            }
        }
    }
}
