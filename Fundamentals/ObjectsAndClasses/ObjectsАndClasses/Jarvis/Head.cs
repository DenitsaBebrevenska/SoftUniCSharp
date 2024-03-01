using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jarvis
{
	internal class Head
	{
		public long EnergyConsumption { get; set; }

		public string Iq { get; set; }

		public string SkinMaterial { get; set; }

		public Head(long energyConsumption, string iq, string material)
		{
			EnergyConsumption = energyConsumption;
			Iq = iq;
			SkinMaterial = material;
		}
		public override string ToString()
		{
			return "#Head:\n" +
				   $"###Energy consumption: {EnergyConsumption}\n" +
				   $"###IQ: {Iq}\n" +
				   $"###Skin material: {SkinMaterial}\n";
		}
	}
}
