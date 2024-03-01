namespace Jarvis
{
	internal class Program
	{
		static void Main()
		{
			Jarvis jarvis = new Jarvis();
			jarvis.EnergyAvailable = long.Parse(Console.ReadLine());
			string input;

			while ((input = Console.ReadLine()) != "Assemble!")
			{
				string[] partArgs = input.Split();
				string partName = partArgs[0];

				switch (partName)
				{
					case "Head":
						UpdateHead(jarvis, partArgs);
						break;
					case "Torso":
						UpdateTorso(jarvis, partArgs);
						break;
					case "Arm":
						UpdateArm(jarvis, partArgs);
						break;
					case "Leg":
						UpdateLeg(jarvis, partArgs);
						break;
				}
			}

			PrintJarvisProgress(jarvis);
		}

		static void UpdateHead(Jarvis jarvis, string[] partArgs)
		{
			long energyConsumption = long.Parse(partArgs[1]);
			string iq = partArgs[2];
			string material = partArgs[3];

			if (jarvis.Head == null)
			{
				jarvis.Head = new Head(energyConsumption, iq, material);
				return;
			}

			if (jarvis.Head.EnergyConsumption > energyConsumption)
			{
				jarvis.Head.EnergyConsumption = energyConsumption;
				jarvis.Head.Iq = iq;
				jarvis.Head.SkinMaterial = material;
			}
		}

		static void UpdateTorso(Jarvis jarvis, string[] partArgs)
		{
			int energyConsumption = int.Parse(partArgs[1]);
			double processorSize = double.Parse(partArgs[2]);
			string materialCorpus = partArgs[3];

			if (jarvis.Torso == null)
			{
				jarvis.Torso = new Torso(energyConsumption, processorSize, materialCorpus);
				return;
			}

			if (jarvis.Torso.EnergyConsumption > energyConsumption)
			{
				jarvis.Torso.EnergyConsumption = energyConsumption;
				jarvis.Torso.ProcessorSize = processorSize;
				jarvis.Torso.CorpusMaterial = materialCorpus;
			}

		}
		static void UpdateArm(Jarvis jarvis, string[] partArgs)
		{
			int energyConsumption = int.Parse(partArgs[1]);
			string reach = partArgs[2];
			string fingerCount = partArgs[3];

			if (jarvis.LeftArm == null)
			{
				jarvis.LeftArm = new Arm(energyConsumption, reach, fingerCount);
				return;
			}

			if (jarvis.RightArm == null)
			{
				jarvis.RightArm = new Arm(energyConsumption, reach, fingerCount);
				return;
			}

			if (jarvis.LeftArm.EnergyConsumption > energyConsumption)
			{
				jarvis.LeftArm.EnergyConsumption = energyConsumption;
				jarvis.LeftArm.ReachDistance = reach;
				jarvis.LeftArm.FingerCount = fingerCount;
			}
			else if (jarvis.RightArm.EnergyConsumption > energyConsumption)
			{
				jarvis.RightArm.EnergyConsumption = energyConsumption;
				jarvis.RightArm.ReachDistance = reach;
				jarvis.RightArm.FingerCount = fingerCount;
			}
		}
		static void UpdateLeg(Jarvis jarvis, string[] partArgs)
		{
			long energyConsumption = long.Parse(partArgs[1]);
			string strength = partArgs[2];
			string speed = partArgs[3];

			if (jarvis.LeftLeg == null)
			{
				jarvis.LeftLeg = new Leg(energyConsumption, strength, speed);
				return;
			}

			if (jarvis.RightLeg == null)
			{
				jarvis.RightLeg = new Leg(energyConsumption, strength, speed);
				return;
			}

			if (jarvis.LeftLeg.EnergyConsumption > energyConsumption)
			{
				jarvis.LeftLeg.EnergyConsumption = energyConsumption;
				jarvis.LeftLeg.Strength = strength;
				jarvis.LeftLeg.Speed = speed;
			}
			else if (jarvis.RightLeg.EnergyConsumption > energyConsumption)
			{
				jarvis.RightLeg.EnergyConsumption = energyConsumption;
				jarvis.RightLeg.Strength = strength;
				jarvis.RightLeg.Speed = speed;
			}
		}

		static void PrintJarvisProgress(Jarvis jarvis)
		{
			if (!Jarvis.AllPartsPresent(jarvis))
			{
				Console.WriteLine("We need more parts!");
			}
			else if (!Jarvis.EnergySuffice(jarvis))
			{
				Console.WriteLine("We need more power!");
			}
			else
			{
				Console.WriteLine(jarvis);
			}
		}
	}
}
