using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleCatalogue_Archive
{
	internal class Vehicle
	{
		public string Type { get; set; }
		public string Model { get; set; }

		public string Color { get; set; }

		public ushort HorsePower { get; set; }

		public Vehicle(string type, string model, string color, ushort hp)
		{
			Type = type;
			Model = model;
			Color = color;
			HorsePower = hp;
		}
		public override string ToString()
		{
			return $"Type: {Type}\nModel: {Model}\nColor: {Color}\nHorsepower: {HorsePower}";
		}
	}
}
