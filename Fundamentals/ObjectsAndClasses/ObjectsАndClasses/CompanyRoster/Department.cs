using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyRoster
{
	internal class Department
	{
		public string Name { get; set; }

		public List<Employee> Employees = new List<Employee>() ;
	}
}
