using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AverageGrades
{
	internal class Student
	{
		public string Name { get; set; }

		public List<double> Grades = new List<double>();

		public double AverageGrade => Grades.Sum() / Grades.Count;

		public Student(string name, List<double> grades)
		{
			Name = name;
			Grades = grades;
		}
	}
}
