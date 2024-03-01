using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesReport
{
	internal class Sale
	{
		public string Town { get; set; }

		public decimal Amount { get; set; }

		public Sale(string town, decimal amount)
		{
			Town = town;
			Amount = amount;
		}
	}
}
