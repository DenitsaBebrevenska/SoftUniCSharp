using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogsAggregator
{
	internal class UserName
	{
		public string Name { get; set; }

		public uint TotalDuration { get; set; }

		public List<string> IpList { get; set; }

		public UserName(string name, uint duration)
		{
			Name = name;
			TotalDuration = duration;
			IpList = new List<string>();
		}

		public string PrintListOfIps()
		{
			return $"[{string.Join(", ", IpList.OrderBy(x => x))}]";
		}
	}
}
