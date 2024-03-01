namespace CompanyRoster
{
	internal class Program
	{
		static void Main()
		{
			int employeeCount = int.Parse(Console.ReadLine());
			List<Department> departmentList = new List<Department>();
			for (int i = 0; i < employeeCount; i++)
			{
				string[] employeeDetails = Console.ReadLine().Split();
				string name = employeeDetails[0];
				double salary = double.Parse(employeeDetails[1]);
				string departmentName = employeeDetails[2];
				Department department = new Department();
				if (departmentList.Exists(d => d.Name == departmentName))
				{
					int index = departmentList.FindIndex(d => d.Name == departmentName);
					department = departmentList[index];
				}
				else
				{
					department.Name = departmentName;
					departmentList.Add(department);
				}

				department.Employees.Add(new Employee(name, salary));
			}

			string departmentMaxSalary = GetHighestSalaryDepartment(departmentList);
			Console.WriteLine($"Highest Average Salary: {departmentMaxSalary}");
			PrintDepartmentEmployees(departmentList, departmentMaxSalary);
		}

		static void PrintDepartmentEmployees(List<Department> departments, string departmentMaxSalary )
		{
			int indexDepartment = departments.FindIndex(d => d.Name == departmentMaxSalary);
			Department department = departments[indexDepartment];
			foreach (Employee employee in department.Employees.OrderByDescending(e => e.Salary))
			{
				Console.WriteLine($"{employee.Name} {employee.Salary:F2}");
			}
		}

		static string GetHighestSalaryDepartment(List<Department> departments)
		{
			double maxSalary = double.MinValue;
			string departmentMaxSalary = "";
			for (int i = 0; i < departments.Count; i++)
			{
				double totalSalaryDepartment = 0;
				Department currentDepartment = departments[i];

				for (int j = 0; j < currentDepartment.Employees.Count; j++)
				{
					Employee currentEmployee = currentDepartment.Employees[j];
					totalSalaryDepartment += currentEmployee.Salary;
				}

				if (totalSalaryDepartment > maxSalary)
				{
					maxSalary = totalSalaryDepartment;
					departmentMaxSalary = currentDepartment.Name;
				}
			}

			return departmentMaxSalary;
		}
	}
}