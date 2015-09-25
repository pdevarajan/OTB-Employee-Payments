# OTB-Employee-Payments
OTB Employee Payments<br /><br />
•	Please update the connection string “SQLServerConnectionString” in the ConsoleHost and UnitTests projects’ app.config file to point at the correct SQL Server.<br />
•	The solution consists of three projects the OTB.EmployeePayments.ConsoleHost(Console App), OTB.EmployeePayments.Core(Core Library), OTB.EmployeePayments.UnitTests(Unit Tests)<br />
•	Entity Framework with code first approach is used in the project. The database is currently always recreated and repopulated with data every time the app is run. This can be altered to support database changes using migrations.<br />
•	Autofac is used for Inversion of Control(IoC)/Dependency Injection(DI)<br />
•	NUnit for unit testing.<br />
•	The console app provides three options for the three tasks in the tech test as shown below - please refer to the read-me document in the soultion root for images<br />
•	The unit tests ran successfully as shown below -  - please refer to the read-me document in the soultion root for images<br />
 
