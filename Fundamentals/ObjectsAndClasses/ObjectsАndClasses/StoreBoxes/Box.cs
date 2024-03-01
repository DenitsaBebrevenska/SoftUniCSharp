using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreBoxes
{
	internal class Box
	{
		public Box(string serialNumber, Item item, int quantity)
		{
			SerialNumber = serialNumber;
			Item = item;
			Quantity = quantity;
		}

		public string SerialNumber { get; set; }
		public Item Item { get; set; }
		public int Quantity { get; set; }

		public decimal PricePerBox => Quantity * Item.Price;
	}
}
