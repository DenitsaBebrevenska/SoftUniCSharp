using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonArmy
{
	internal class Dragon
	{
		public string Name { get; set; }
		public int Damage { get; set; }
		public int Health { get; set; }
		public int Armor { get; set; }

		public Dragon(string name, int damage, int health, int armor)
		{
			Name = name;

			Damage = damage;

			Health = health;

			Armor = armor;
			
		}
	}
}
