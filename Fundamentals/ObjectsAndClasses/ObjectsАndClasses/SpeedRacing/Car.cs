using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedRacing
{
	internal class Car
	{
		public string Model { get; set; }
		public  double FuelAmount { get; set; }
		public  double FuelConsumptionPerKm { get; set; }

		public int TotalDistance { get; set; }

		public Car(string model, double fuelAmount, double fuelConsumption)
		{
			Model = model;
			FuelAmount = fuelAmount;
			FuelConsumptionPerKm = fuelConsumption;
			TotalDistance = 0;
		}

		public bool FuelSuffice(double neededFuel)
		{
			return FuelAmount >= neededFuel;
		}
	}
}
