using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather
{
	internal class Weather
	{
		public string City { get; set; }

		public double AverageTemperature { get; set; }

		public string Type { get; set; }


		public Weather(string city, double temperature, string type)
		{
			City = city;
			AverageTemperature = temperature;
			Type = type;
		}

		public override string ToString()
		{
			return $"{City} => {AverageTemperature:F2} => {Type}";
		}
	}
}
