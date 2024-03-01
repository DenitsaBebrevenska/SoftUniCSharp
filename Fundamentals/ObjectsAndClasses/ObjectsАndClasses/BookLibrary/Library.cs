using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary
{
	internal class Library
	{
		public string Name { get; set; }

		public List<Book> Books = new List<Book>();
	}
}
