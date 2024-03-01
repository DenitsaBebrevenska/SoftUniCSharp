using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jarvis
{
	internal class Jarvis
	{
		public long PartsEnergyConsumption => Head.EnergyConsumption + LeftArm.EnergyConsumption +
		                                      RightArm.EnergyConsumption + Torso.EnergyConsumption
		                                      + LeftLeg.EnergyConsumption + RightLeg.EnergyConsumption;

		public long EnergyAvailable { get; set; }
		public Head Head { get; set; }

		public Arm LeftArm { get; set; }

		public Arm RightArm { get; set; }

		public Torso Torso { get; set; }
		public Leg LeftLeg { get; set; }

		public Leg RightLeg { get; set; }

		public static bool AllPartsPresent(Jarvis jarvis)
		{
			return jarvis.Head != null &&
			       jarvis.LeftArm != null &&
			       jarvis.RightArm != null &&
			       jarvis.Torso != null &&
			       jarvis.LeftLeg != null &&
			       jarvis.RightLeg != null;
		}

		public static bool EnergySuffice(Jarvis jarvis)
		{
			return jarvis.EnergyAvailable >= jarvis.PartsEnergyConsumption;
		}

		public override string ToString()
		{
			string output = "Jarvis:\n" + Head + Torso;
			if (LeftArm.EnergyConsumption > RightArm.EnergyConsumption)
			{
				output += RightArm.ToString() + LeftArm;
			}
			else
			{
				output += LeftArm.ToString() + RightArm;
			}

			if (LeftLeg.EnergyConsumption > RightLeg.EnergyConsumption)
			{
				output += RightLeg.ToString() + LeftLeg;
			}
			else
			{
				output += LeftLeg.ToString() + RightLeg;
			}

			return output;
		}
	}
}
