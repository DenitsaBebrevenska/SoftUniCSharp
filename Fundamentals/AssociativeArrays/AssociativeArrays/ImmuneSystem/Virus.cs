using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImmuneSystem
{
	internal class Virus
	{
		public string Name { get; set; }

		public int DefeatTime { get; set; } //in seconds

		public Virus(string name, int defeatTime)
		{
			Name = name;
			DefeatTime = defeatTime;
		}
	}
}
