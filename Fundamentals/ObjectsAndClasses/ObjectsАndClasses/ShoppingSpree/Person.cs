using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingSpree
{
	internal class Person
	{
		public string Name { get; set; }
		public int Money { get; set; }
		public List<Product> Products { get; set; }

		public Person(string name, int money)
		{
			Name = name;
			Money = money;
			Products = new List<Product>();
		}
	}
}
