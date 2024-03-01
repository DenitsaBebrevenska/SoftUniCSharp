using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders
{
	internal class ProductInfo
	{
		public ProductInfo(decimal price, int quantity)
		{
			Price = price;
			Quantity = quantity;
		}

		public decimal Price { get; set; }
		public int Quantity { get; set; }
	}
}
