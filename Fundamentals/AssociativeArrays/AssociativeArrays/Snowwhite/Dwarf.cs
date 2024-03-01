using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snowwhite
{
	internal class Dwarf
	{
		public Dwarf()
		{

		}
		public Dwarf(string name, string hatColor, int physics)
		{
			Name = name;
			HatColor = hatColor;
			Physics = physics;
		}

		public string Name { get; set; }

		public string HatColor { get; set; }

		public int Physics { get; set; }
	}
}
