﻿using Microsoft.EntityFrameworkCore;
using SoftUni.Data;
using SoftUni.Models;
using System.Globalization;
using System.Text;

namespace SoftUni;

public static class StartUp
{
    //for the sake of Judge there is no async
    static void Main()
    {
        SoftUniContext context = new SoftUniContext();
        //Console.WriteLine(GetEmployeesFullInformation(context));
        //Console.WriteLine(GetEmployeesWithSalaryOver50000(context));
        //Console.WriteLine(GetEmployeesFromResearchAndDevelopment(context));
        //Console.WriteLine(AddNewAddressToEmployee(context));
        //Console.WriteLine(GetEmployeesInPeriod(context));
        //Console.WriteLine(GetAddressesByTown(context));
        //Console.WriteLine(GetEmployee147(context));
        //Console.WriteLine(GetDepartmentsWithMoreThan5Employees(context));
        //Console.WriteLine(GetLatestProjects(context));
        //Console.WriteLine(IncreaseSalaries(context));
        //Console.WriteLine(GetEmployeesByFirstNameStartingWithSa(context));
        //Console.WriteLine(DeleteProjectById(context));
        //Console.WriteLine(RemoveTown(context));
    }

    // Problem 03
    public static string GetEmployeesFullInformation(SoftUniContext context)
    {
        StringBuilder sb = new StringBuilder();

        var employees = context.Employees
            .OrderBy(e => e.EmployeeId)
            .Select(e => new
            {
                e.FirstName,
                e.LastName,
                e.MiddleName,
                e.JobTitle,
                e.Salary
            })
            .ToArray();

        foreach (var employee in employees)
        {
            sb.AppendLine($"{employee.FirstName} {employee.LastName} {employee.MiddleName} {employee.JobTitle} {employee.Salary:F2}");
        }

        return sb.ToString().TrimEnd();
    }

    //Problem 04
    public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
    {
        StringBuilder sb = new StringBuilder();

        var employees = context.Employees
            .Where(e => e.Salary > 50_000)
            .OrderBy(e => e.FirstName)
            .Select(e => new
            {
                e.FirstName,
                e.Salary
            })
            .ToArray();

        foreach (var employee in employees)
        {
            sb.AppendLine($"{employee.FirstName} - {employee.Salary:F2}");
        }

        return sb.ToString().TrimEnd();
    }

    //Problem 05
    public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
    {
        StringBuilder sb = new StringBuilder();

        var employees = context.Employees
            .Where(e => e.Department.Name == "Research and Development")
            .Select(e => new
            {
                e.FirstName,
                e.LastName,
                DepartmentName = e.Department.Name,
                e.Salary
            })
            .OrderBy(e => e.Salary)
            .ThenByDescending(e => e.FirstName)
            .ToArray();

        foreach (var employee in employees)
        {
            sb.AppendLine(
                $"{employee.FirstName} {employee.LastName} from {employee.DepartmentName} - ${employee.Salary:F2}");
        }

        return sb.ToString().TrimEnd();
    }

    //Problem 06
    public static string AddNewAddressToEmployee(SoftUniContext context)
    {
        Address newAddress = new Address()
        {
            AddressText = "Vitoshka 15",
            TownId = 4
        };

        Employee employee = context.Employees
            .FirstOrDefault(e => e.LastName == "Nakov");
        employee.Address = newAddress;
        context.SaveChanges();

        var employeeAddresses = context.Employees
            .OrderByDescending(e => e.AddressId)
            .Take(10)
            .Select(e => e.Address.AddressText)
            .ToArray();

        return string.Join(Environment.NewLine, employeeAddresses);
    }

    //Problem 07
    public static string GetEmployeesInPeriod(SoftUniContext context)
    {
        var employees = context.Employees
            .Take(10)
            .Select(e => new
            {
                e.FirstName,
                e.LastName,
                ManagerFirstName = e.Manager.FirstName,
                ManagerLastName = e.Manager.LastName,
                Projects = e.EmployeesProjects
                    .Where(p => p.Project.StartDate.Year >= 2001 && p.Project.StartDate.Year <= 2003)
                    .Select(p => new
                    {
                        ProjectName = p.Project.Name,
                        ProjectStartDate = p.Project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture),
                        ProjectEndDate = p.Project.EndDate.HasValue ? p.Project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture) : "not finished"
                    })
                    .ToArray()
            })
            .ToArray();

        StringBuilder sb = new StringBuilder();

        foreach (var employee in employees)
        {
            sb.AppendLine($"{employee.FirstName} {employee.LastName} - Manager: {employee.ManagerFirstName} {employee.ManagerLastName}");

            foreach (var project in employee.Projects)
            {
                sb.AppendLine($"--{project.ProjectName} - {project.ProjectStartDate} - {project.ProjectEndDate}");
            }
        }
        return sb.ToString().TrimEnd();
    }

    //Problem 08
    public static string GetAddressesByTown(SoftUniContext context)
    {
        var addresses = context.Addresses
            .OrderByDescending(a => a.Employees.Count)
            .ThenBy(a => a.Town.Name)
            .ThenBy(a => a.AddressText)
            .Take(10)
            .Select(a => new
            {
                a.AddressText,
                EmployeesCount = a.Employees.Count,
                TownName = a.Town.Name
            })
            .ToArray();

        StringBuilder sb = new StringBuilder();

        foreach (var address in addresses)
        {
            sb.AppendLine($"{address.AddressText}, {address.TownName} - {address.EmployeesCount} employees");
        }

        return sb.ToString().TrimEnd();
    }

    //Problem 09 
    public static string GetEmployee147(SoftUniContext context)
    {
        Employee employee = context.Employees
            .Include(e => e.EmployeesProjects)
            .ThenInclude(ep => ep.Project)
            .FirstOrDefault(e => e.EmployeeId == 147);

        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");

        foreach (var employeeProject in employee.EmployeesProjects
                     .OrderBy(ep => ep.Project.Name))
        {
            sb.AppendLine(employeeProject.Project.Name);
        }


        return sb.ToString().TrimEnd();
    }

    // Problem 10
    public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
    {
        var departments = context.Departments
            .Where(d => d.Employees.Count > 5)
            .OrderBy(d => d.Employees.Count)
            .ThenBy(d => d.Name)
            .Select(d => new
            {
                d.Name,
                ManagerFirstName = d.Manager.FirstName,
                ManagerLastName = d.Manager.LastName,
                Employees = d.Employees
                    .OrderBy(e => e.FirstName)
                    .ThenBy(e => e.LastName)
                    .Select(e => new
                    {
                        e.FirstName,
                        e.LastName,
                        e.JobTitle
                    })
                    .ToArray()

            })
            .ToArray();

        StringBuilder sb = new StringBuilder();

        foreach (var department in departments)
        {
            sb.AppendLine($"{department.Name} - {department.ManagerFirstName} {department.ManagerLastName}");

            foreach (var employee in department.Employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");
            }
        }

        return sb.ToString().TrimEnd();
    }

    //Problem 11
    public static string GetLatestProjects(SoftUniContext context)
    {
        var latestProjects = context.Projects
            .OrderByDescending(p => p.StartDate)
            .Take(10)
            .OrderBy(p => p.Name)
            .Select(p => new
            {
                p.Name,
                p.Description,
                p.StartDate
            })
            .ToArray();

        StringBuilder sb = new StringBuilder();

        foreach (var project in latestProjects)
        {
            sb.AppendLine(project.Name);
            sb.AppendLine(project.Description);
            sb.AppendLine(project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture));
        }

        return sb.ToString().TrimEnd();
    }

    //Problem 12
    public static string IncreaseSalaries(SoftUniContext context)
    {
        string[] promotedDepartments = { "Engineering", "Tool Design", "Marketing", "Information Services" };

        foreach (var employee in context.Employees
                     .Where(e => promotedDepartments.Contains(e.Department.Name)))
        {
            employee.Salary *= 1.12m;
        }

        context.SaveChanges();

        var employeesPromoted = context.Employees
            .Where(e => promotedDepartments.Contains(e.Department.Name))
            .OrderBy(e => e.FirstName)
            .ThenBy(e => e.LastName)
            .Select(e => new
            {
                e.FirstName,
                e.LastName,
                e.Salary
            })
            .ToArray();

        StringBuilder sb = new StringBuilder();

        foreach (var employee in employeesPromoted)
        {
            sb.AppendLine($"{employee.FirstName} {employee.LastName} (${employee.Salary:F2})");
        }

        return sb.ToString().TrimEnd();
    }

    //Problem 13
    public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
    {
        var employees = context.Employees
            .Where(e => e.FirstName.ToLower().StartsWith("sa"))
            .OrderBy(e => e.FirstName)
            .ThenBy(e => e.LastName)
            .Select(e => new
            {
                e.FirstName,
                e.LastName,
                e.JobTitle,
                e.Salary
            })
            .ToArray();

        StringBuilder sb = new StringBuilder();

        foreach (var employee in employees)
        {
            sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle} - (${employee.Salary:F2})");
        }

        return sb.ToString().TrimEnd();
    }

    //Problem 14
    public static string DeleteProjectById(SoftUniContext context)
    {
        var employeeProjectsToDelete = context.EmployeesProjects
            .Where(ep => ep.ProjectId == 2);
        context.RemoveRange(employeeProjectsToDelete);

        context.Projects.Remove(context.Projects.Find(2));

        context.SaveChanges();

        var projects = context.Projects
            .Take(10)
            .Select(p => p.Name)
            .ToArray();

        return string.Join(Environment.NewLine, projects);
    }

    //Problem 15
    public static string RemoveTown(SoftUniContext context)
    {
        string townName = "Seattle";

        var employeeAddresses = context.Employees
            .Where(e => e.Address.Town.Name == townName);

        foreach (var employee in employeeAddresses)
        {
            employee.AddressId = null;
        }

        var townAddresses = context.Addresses
            .Where(a => a.Town.Name == townName);
        int totalAddresses = townAddresses.Count();

        context.RemoveRange(townAddresses);

        context.Remove(context.Towns.FirstOrDefault(t => t.Name == townName)!);

        context.SaveChanges();

        return $"{totalAddresses} addresses in Seattle were deleted";
    }
}