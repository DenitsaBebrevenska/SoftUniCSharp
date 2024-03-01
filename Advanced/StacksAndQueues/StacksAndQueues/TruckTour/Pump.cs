using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruckTour
{
	internal class Pump
	{
		public int PumpID { get; set; }

		public int Fuel { get; set; }

		public int DistanceToNextPump { get; set; }

		public Pump(int id, int fuel, int distance)
		{
			PumpID = id;
			Fuel = fuel;
			DistanceToNextPump = distance;
		}
	}
}
