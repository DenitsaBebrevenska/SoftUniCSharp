using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace СръбскоUnleashed
{
	internal class Concert
	{
		public string Singer { get; set; }
		public uint TotalGain { get; set; }

		public Concert(string singer, uint totalGain)
		{
			Singer = singer;
			TotalGain = totalGain;
		}
	}
}
