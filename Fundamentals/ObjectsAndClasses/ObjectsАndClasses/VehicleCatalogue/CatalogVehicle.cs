using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleCatalogue
{
	internal class CatalogVehicle
	{
		public List<Car> Cars { get; set; }
		public List<Truck> Trucks { get; set; }
		public CatalogVehicle()
		{
			Cars = new List<Car>();
			Trucks = new List<Truck>();
		}
	}
}
