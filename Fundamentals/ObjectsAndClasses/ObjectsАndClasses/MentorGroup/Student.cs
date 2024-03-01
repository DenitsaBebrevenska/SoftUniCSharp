using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MentorGroup
{
	internal class Student
	{
		public string Name { get; set; }

		public List<string> Comments { get; set; }

		public List<DateTime> AttendanceDates { get; set; }

		public Student()
		{
			Comments = new List<string>();

			AttendanceDates = new List<DateTime>();
		}
	}
}
