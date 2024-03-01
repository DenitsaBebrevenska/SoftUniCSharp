using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P_rates
{
	internal class City
	{
		public string Name { get; set; }
		public int Population { get; set; }
		public int Gold { get; set; }

		public City(string name, int population, int gold)
		{
			Name = name;
			Population = population;
			Gold = gold;
		}

		public override string ToString()
		{
			return $"{Name} -> Population: {Population} citizens, Gold: {Gold} kg";
		}
	}
}
