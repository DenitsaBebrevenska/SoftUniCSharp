using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheRace
{
    public class Race
    {
        private List<Racer> data;

        public Race(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            data = new List<Racer>();
        }

        public int Count => data.Count;
        public string Name { get; private set; }
        public int Capacity { get; private set; }

        public void Add(Racer racer)
        {
            if (data.Count < Capacity)
            {
                data.Add(racer);
            }
        }

        public bool Remove(string name)
        {
            Racer racer = data.FirstOrDefault(r => r.Name == name);

            if (racer != null)
            {
                data.Remove(racer);
                return true;
            }

            return false;
        }

        public Racer GetOldestRacer()
        => data.OrderByDescending(r => r.Age).FirstOrDefault();

        public Racer GetRacer(string name)
        => data.FirstOrDefault(r => r.Name == name);

        public Racer GetFastestRacer()
        => data.OrderByDescending(r => r.Car.Speed).FirstOrDefault();

        public string Report()
        {
            StringBuilder reportBuilder = new StringBuilder();
            reportBuilder.AppendLine($"Racers participating at {Name}:");
            data.ForEach(r => reportBuilder.AppendLine(r.ToString()));

            return reportBuilder.ToString().TrimEnd();
        }
    }
}
