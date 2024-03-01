using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jarvis
{
	internal class Torso
	{
		public long EnergyConsumption { get; set; }

		public double ProcessorSize { get; set; }

		public string CorpusMaterial { get; set; }

		public Torso(long energyConsumption, double processorSize, string material)
		{
			EnergyConsumption = energyConsumption;
			ProcessorSize = processorSize;
			CorpusMaterial = material;
		}
		public override string ToString()
		{
			return "#Torso:\n" +
			       $"###Energy consumption: {EnergyConsumption}\n" +
			       $"###Processor size: {ProcessorSize:F1}\n" +
			       $"###Corpus material: {CorpusMaterial}\n";
		}
	}
}
