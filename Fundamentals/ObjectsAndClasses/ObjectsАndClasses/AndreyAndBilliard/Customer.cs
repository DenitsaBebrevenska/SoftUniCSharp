using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndreyAndBilliard
{
	internal class Customer
	{
		public string Name { get; set; }

		public Dictionary<string, int> ItemsBought { get; set; } = new Dictionary<string, int>();

		public decimal Bill { get; set; }

	}
}
