using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FishingNet
{
    public class Net
    {
        private List<Fish> fish;
        public string Material { get; set; }
        public int Capacity { get; set; }
        public IReadOnlyCollection<Fish> Fish => fish.AsReadOnly();
        public Net(string material, int capacity)
        {
            Material = material;
            Capacity = capacity;
            fish = new List<Fish>();
        }

        public int Count => fish.Count;
        public string AddFish(Fish currentFish)
        {

            if (string.IsNullOrWhiteSpace(currentFish.FishType) || currentFish.Length <= 0 || currentFish.Weight <= 0)
            {
                return "Invalid fish.";
            }

            if (this.fish.Count == Capacity)
            {
                return "Fishing net is full.";
            }

            this.fish.Add(currentFish);
            return $"Successfully added {currentFish.FishType} to the fishing net.";
        }

        public bool ReleaseFish(double weight)
        {
            Fish currentFish = this.fish.FirstOrDefault(f => f.Weight.Equals(weight));

            if (currentFish != null)
            {
                this.fish.Remove(currentFish);
                return true;
            }

            return false;
        }

        public Fish GetFish(string fishType) => this.fish.FirstOrDefault(f => f.FishType == fishType);

        public Fish GetBiggestFish() => this.fish.OrderByDescending(f => f.Length).First();

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Into the {Material}:");

            foreach (var currentFish in fish.OrderByDescending(f => f.Length))
            {
                sb.AppendLine(currentFish.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
