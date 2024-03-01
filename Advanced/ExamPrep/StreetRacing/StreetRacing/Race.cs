using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StreetRacing
{
    public class Race
    {
        private List<Car> participants;

        public Race(string name, string type, int laps, int capacity, int maxHorsePower)
        {
            Name = name;
            Type = type;
            Laps = laps;
            Capacity = capacity;
            MaxHorsePower = maxHorsePower;
            participants = new List<Car>();
        }

        public int Count => participants.Count;
        public IReadOnlyCollection<Car> Participants => participants.AsReadOnly();
        public string Name { get; private set; }
        public string Type { get; private set; }
        public int Laps { get; private set; }
        public int Capacity { get; private set; }
        public int MaxHorsePower { get; private set; }


        public void Add(Car car)
        {
            if (participants.All(c => c.LicensePlate != car.LicensePlate)
                && participants.Count < Capacity
                && car.HorsePower <= MaxHorsePower)
            {
                participants.Add(car);
            }
        }

        public bool Remove(string licensePlate)
        {
            Car car = participants.FirstOrDefault(c => c.LicensePlate == licensePlate);

            if (car != null)
            {
                participants.Remove(car);
                return true;
            }

            return false;
        }

        public Car FindParticipant(string licensePlate)
            => participants.FirstOrDefault(c => c.LicensePlate == licensePlate);

        public Car GetMostPowerfulCar() => participants.OrderByDescending(c => c.HorsePower).FirstOrDefault();

        public string Report()
        {
            StringBuilder reportBuilder = new StringBuilder();
            reportBuilder.AppendLine($"Race: {Name} - Type: {Type} (Laps: {Laps})");

            foreach (var car in participants)
            {
                reportBuilder.AppendLine(car.ToString());
            }

            return reportBuilder.ToString().TrimEnd();
        }
    }
}
