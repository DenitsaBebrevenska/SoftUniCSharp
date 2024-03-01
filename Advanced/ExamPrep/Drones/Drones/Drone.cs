using System.Text;

namespace Drones
{
    public class Drone
    {
        public string Name { get; private set; }
        public string Brand { get; private set; }
        public int Range { get; private set; }
        public bool Available { get; set; }

        public Drone(string name, string brand, int range)
        {
            Name = name;
            Brand = brand;
            Range = range;
            Available = true;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Drone: {Name}");
            sb.AppendLine($"Manufactured by: {Brand}");
            sb.AppendLine($"Range: {Range} kilometers");

            return sb.ToString().TrimEnd();
        }
    }
}
