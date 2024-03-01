namespace AutomotiveRepairShop
{
    public class RepairShop
    {
        public int Capacity { get; set; }
        public List<Vehicle> Vehicles { get; set; }
        public RepairShop(int capacity)
        {
            Capacity = capacity;
            Vehicles = new List<Vehicle>();
        }

        public void AddVehicle(Vehicle vehicle)
        {
            if (Vehicles.Count < Capacity)
            {
                Vehicles.Add(vehicle);
            }
        }

        public bool RemoveVehicle(string vin)
        {
            Vehicle vehicle = Vehicles.FirstOrDefault(v => v.VIN == vin);

            if (vehicle != null)
            {
                Vehicles.Remove(vehicle);
                return true;
            }

            return false;
        }

        public int GetCount() => Vehicles.Count;

        public Vehicle GetLowestMileage() => Vehicles.OrderBy(v => v.Mileage).First();

        public string Report() =>
            $"Vehicles in the preparatory:{Environment.NewLine}{string.Join(Environment.NewLine, Vehicles)}";
    }
}
