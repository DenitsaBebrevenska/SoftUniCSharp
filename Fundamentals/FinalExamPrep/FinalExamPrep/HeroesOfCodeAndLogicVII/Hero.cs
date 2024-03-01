using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroesOfCodeAndLogicVII
{
	internal class Hero
	{
		public string Name { get; set; }
		public int HitPoints { get; set; }
		public int ManaPoints { get; set; }

		public Hero(string name, int hp, int mp)
		{
			Name = name;
			HitPoints = hp;
			ManaPoints = mp;
		}

		public override string ToString()
		{
			return $"{Name}\n" +
			       $"  HP: {HitPoints}\n" +
			       $"  MP: {ManaPoints}";

		}
	}
}
