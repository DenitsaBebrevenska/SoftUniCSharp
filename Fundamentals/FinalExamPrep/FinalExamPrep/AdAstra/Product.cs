using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdAstra
{
	internal class Product
	{
		public string Name { get; set; }
		public string ExpirationDate { get; set; }
		public int Calories { get; set; }

		public Product(string name, string expirationDate, int calories)
		{
			Name = name;
			ExpirationDate = expirationDate;
			Calories = calories;
		}
	}
}
