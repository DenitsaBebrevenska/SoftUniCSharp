using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jarvis
{
	internal class Arm
	{
		public long EnergyConsumption { get; set; } = 0;

		public string ReachDistance { get; set; }

		public string FingerCount { get; set; }

		public Arm(long energyConsumption, string reachDistance, string fingerCount)
		{
			EnergyConsumption = energyConsumption;
			ReachDistance = reachDistance;
			FingerCount = fingerCount;
		}

		public override string ToString()
		{
			return "#Arm:\n" +
			       $"###Energy consumption: {EnergyConsumption}\n" +
			       $"###Reach: {ReachDistance}\n" +
			       $"###Fingers: {FingerCount}\n";
		}
	}
}
