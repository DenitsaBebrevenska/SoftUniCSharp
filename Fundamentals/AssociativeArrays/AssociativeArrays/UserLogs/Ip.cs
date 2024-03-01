using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogs
{
	internal class Ip
	{
		public string Number { get; set; }

		public byte MessageCount { get; set; }

		public Ip(string number, byte messageCount)
		{
			Number = number;
			MessageCount = messageCount;
		}

		public override string ToString()
		{
			return $"{Number} => {MessageCount}";
		}
	}
}
