using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketDatabase
{
	internal class Product
	{
		public string Name { get; set; }

		public decimal Price { get; set; }

		public uint Quantity { get; set; }

		public decimal TotalMoney => Price * Quantity;

		public Product(string name, decimal price, uint quantity)
		{
			Name = name;
			Price = price;
			Quantity = quantity;
		}
	}
}
