using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleCatalogue
{
	internal class Car
	{
		public Car(string brand, string model, int horsePower)
		{
			Brand = brand;
			Model = model;
			HorsePower = horsePower;
			
		}
		public string Brand { get; set; }
		public string Model { get; set; }

		public int HorsePower { get; set; }
	}
}
