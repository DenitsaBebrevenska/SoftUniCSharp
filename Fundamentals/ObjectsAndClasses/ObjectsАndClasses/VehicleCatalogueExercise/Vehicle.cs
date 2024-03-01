using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleCatalogueExercise
{
	internal class Vehicle
	{
		public Vehicle(string type, string model, string color, int horsepower)
		{
			Type = type;
			Model = model;
			Color = color;
			Horsepower = horsepower;
		}

		public string Type { get; set; }
		public string Model { get; set; }
		public string Color { get; set; }
		public int Horsepower { get; set; }
	}

}
