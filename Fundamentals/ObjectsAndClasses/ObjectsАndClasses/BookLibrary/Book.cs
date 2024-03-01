using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary
{
	internal class Book
	{
		public string Name { get; set; }

		public string Author { get; set; }

		public string Publisher { get; set; }

		public DateTime ReleaseDate { get; set; }

		public string ISBN { get; set; }

		public decimal Price { get; set; }

	}
}
