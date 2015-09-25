using System;
using Autofac;
using OTB.EmployeePayments.Core;
using OTB.EmployeePayments.Core.Models;
using OTB.EmployeePayments.Core.Services;

namespace OTB.EmployeePayments.ConsoleHost
{
    class Program
    {
        private static IContainer Container { get; set; }

        // ReSharper disable once UnusedParameter.Local
        static void Main(string[] args)
        {
            //setup dependencies
            var builder = new ContainerBuilder();
            builder.RegisterType<AppSettings>().As<ISettings>();
            builder.RegisterType<EmployeeService>().As<IEmployeeService>();
            Container = builder.Build();


            using (var scope = Container.BeginLifetimeScope())
            {
                var employeeService = scope.Resolve<IEmployeeService>();
                
                employeeService.InitialiseData();

                while (true)
                {
                    Console.ResetColor();
                    Console.WriteLine(
                        "1. Print SQL query that shows how much to pay employees in GBP (annual) and show the result");
                    Console.WriteLine("2. Search by employee name to show how much to pay in GBP (annual)");
                    Console.WriteLine(
                        "3. Show the list of STAFF level employees in order who is paid the most in GBP (annual)");
                    Console.WriteLine(
                        "4. Exit");
                    Console.WriteLine("Please enter a choice from the above - 1 or 2 or 3 or 4:");

                    int result;
                    var isValidResult = int.TryParse(Console.ReadLine(), out result);

                    if (!isValidResult || result > 4)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Please enter a valid choice - 1 or 2 or 3 or 4:");
                        continue;
                    }

                    switch (result)
                    {
                        case 1:
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("SQL query showing how much to pay employees in GBP (annual) and the results:");
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("..................");
                            Console.WriteLine(
                                @"'SELECT Name AS EmployeeName, ROUND((AnnualAmount / ConversionFactor), 2) AS AnnualSalaryGBP FROM Employees AS E INNER JOIN Salaries AS S ON E.EmployeeId = S.EmployeeId INNER JOIN Currencies AS C ON S.CurrencyId = C.CurrencyId'");
                            Console.WriteLine("..................");
                            Console.WriteLine(string.Join("\n", employeeService.GetEmployeeSalaries()));
                            Console.WriteLine("..................");
                            break;
                        case 2:
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Please enter an employee name to show how much to pay in GBP (annual):");
                            var employeeName = Console.ReadLine();
                            if (!string.IsNullOrWhiteSpace(employeeName))
                            {
                                Console.WriteLine("Matching employees list with employee name containing - '{0}' showing how much to pay in GBP (annual):", employeeName.ToUpper());
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("..................");
                                Console.WriteLine(string.Join("\n", employeeService.GetEmployeeSalariesByName(employeeName)));
                                Console.WriteLine("..................");
                            }
                            break;
                        case 3:
                            Console.WriteLine();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("List of STAFF level employees in order who is paid the most in GBP (annual):");
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("..................");
                            Console.WriteLine(string.Join("\n", employeeService.GetEmployeeSalariesByRole(Role.RolesList.Staff.GetHashCode())));
                            Console.WriteLine("..................");
                            break;
                        case 4:
                            Environment.Exit(0);
                            break;
                    }

                    Console.ResetColor();

                }
            }

        }
    }
}
