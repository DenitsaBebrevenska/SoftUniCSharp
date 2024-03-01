using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThePianist
{
	internal class PieceDetails
	{
		public string Composer { get; set; }
		public string Key { get; set; }

		public PieceDetails(string composer, string key)	
		{
			Composer = composer;
			Key = key;
		}
	}
}
