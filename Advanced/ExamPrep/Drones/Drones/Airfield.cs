using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Drones
{
    public class Airfield
    {
        private List<Drone> drones;
        public string Name { get; set; }
        public int Capacity { get; set; }
        public double LandingStrip { get; set; }

        public int Count => drones.Count;
        public IReadOnlyCollection<Drone> Drones => drones.AsReadOnly();

        public Airfield(string name, int capacity, double landingStrip)
        {
            this.drones = new List<Drone>();
            Name = name;
            Capacity = capacity;
            LandingStrip = landingStrip;
        }

        public string AddDrone(Drone drone)
        {
            if (string.IsNullOrWhiteSpace(drone.Name) || string.IsNullOrWhiteSpace(drone.Brand)
                                                      || drone.Range < 5 || drone.Range > 15)
            {
                return "Invalid drone.";
            }

            if (drones.Count == Capacity)
            {
                return "Airfield is full.";
            }

            drones.Add(drone);
            return $"Successfully added {drone.Name} to the airfield.";
        }

        public bool RemoveDrone(string name)
        {
            Drone drone = drones.FirstOrDefault(d => d.Name == name);

            if (drone != null)
            {
                drones.Remove(drone);
                return true;
            }

            return false;
        }

        public int RemoveDroneByBrand(string brand)
        {
            int count = drones.Count(d => d.Brand == brand);
            drones.RemoveAll(d => d.Brand == brand);
            return count;
        }

        public Drone FlyDrone(string name)
        {
            Drone drone = drones.FirstOrDefault(d => d.Name == name);

            if (drone != null)
            {
                drone.Available = false;
            }

            return drone;
        }

        public List<Drone> FlyDronesByRange(int range)
        {
            foreach (var drone in drones.Where(d => d.Range >= range))
            {
                drone.Available = false;
            }

            return drones.Where(d => d.Range >= range).ToList();
        }

        public string Report()
        {
            StringBuilder reportBuilder = new StringBuilder();
            reportBuilder.AppendLine($"Drones available at {Name}:");

            foreach (var drone in drones.Where(d => d.Available))
            {
                reportBuilder.AppendLine(drone.ToString());
            }

            return reportBuilder.ToString().TrimEnd();
        }
    }
}
