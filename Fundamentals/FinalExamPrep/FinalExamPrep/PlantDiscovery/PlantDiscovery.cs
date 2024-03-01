using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantDiscovery
{
	internal class Plant
	{
		public string Name { get; set; }
		public int Rarity { get; set; }
		public List<double> Rating { get; set; }

		public Plant(string name, int rarity)
		{
			Name = name;
			Rarity = rarity;
			Rating = new List<double>();
		}
		public override string ToString()
		{
			if (Rating.Count == 0)
			{
				Rating.Add(0); //to avoid NaN
			}

			return $"- {Name}; Rarity: {Rarity}; Rating: {Rating.Sum(x => x)/Rating.Count:F2}\n";
		}
	}
}
