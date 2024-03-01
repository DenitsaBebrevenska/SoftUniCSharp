using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreBoxes
{
	internal class Item
	{
		public Item(string name, decimal price)
		{
			Name = name;
			Price = price;
		}

		public string Name { get; set; }
		public decimal Price { get; set; }

	}
}
