using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RawData
{
	internal class Car
	{
		public string Model { get; set; }
		public Engine CarEngine { get; set; }
		public Cargo CarCargo { get; set; }

		public Car(string model, Engine carEngine, Cargo carCargo)
		{
			Model = model;
			CarEngine = carEngine;
			CarCargo = carCargo;
		}
	}
}
