
using MiniORM.App.Data;
using MiniORM.App.Data.Entities;

string connectionString = Environment.GetEnvironmentVariable("ConnectionString", EnvironmentVariableTarget.User);
SoftUniDbContext dbContext = new SoftUniDbContext(connectionString);

SoftUniDbContext context = new SoftUniDbContext(connectionString);

context.Employees.Add(new Employee
{
    FirstName = "Gosho",
    LastName = "Inserted",
    DepartmentId = context.Departments.First().Id,
    IsEmployed = true
});

Employee employee = context.Employees.Last();
employee.FirstName = "Modified";

context.SaveChanges();
