using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetherRealms
{
	internal class Demon
	{
		public string Name { get; set; }

		public int HealthPoints { get; set; }
		public double Damage { get; set; }

		public Demon(string name, int healthPoints, double damage)
		{
			Name = name;
			HealthPoints = healthPoints;
			Damage = damage;
		}

	}
}
