using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamworkProjects
{
	internal class Team
	{
		public string Creator { get; set; }
		public string Name { get; set; }

		public List<string> Members { get; set; }

		public Team(string creator, string name)
		{
			Name = name;
			Creator = creator;
			Members = new List<string>();
		}
	}
}
