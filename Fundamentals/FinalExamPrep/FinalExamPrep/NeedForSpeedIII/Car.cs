using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeedForSpeedIII
{
	internal class Car
	{
		public string Name { get; set; }
		public int Mileage { get; set; }
		public int Fuel { get; set; }

		public Car(string name, int mileage, int fuel)
		{
			Name = name;
			Mileage = mileage;
			Fuel = fuel;
		}

		public override string ToString()
		{
			return $"{Name} -> Mileage: {Mileage} kms, Fuel in the tank: {Fuel} lt.";
		}
	}
}
