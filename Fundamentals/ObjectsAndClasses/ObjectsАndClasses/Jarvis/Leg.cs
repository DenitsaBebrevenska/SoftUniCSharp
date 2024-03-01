using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jarvis
{
	internal class Leg
	{
		public long EnergyConsumption { get; set; }
		public string Strength { get; set; }

		public string Speed { get; set; }

		public Leg(long energyConsumption, string strength, string speed)
		{
			EnergyConsumption = energyConsumption;
			Strength = strength;
			Speed = speed;
		}
		public override string ToString()
		{
			return "#Leg:\n" +
			       $"###Energy consumption: {EnergyConsumption}\n" +
			       $"###Strength: {Strength}\n" +
			       $"###Speed: {Speed}\n";
		}
	}
}
