using System.Text;

namespace Renovators
{
    public class Renovator
    {
        public string Name { get; private set; }
        public string Type { get; private set; }
        public double Rate { get; private set; }
        public int Days { get; private set; }
        public bool Hired { get; set; }

        public Renovator(string name, string type, double rate, int days)
        {
            Name = name;
            Type = type;
            Rate = rate;
            Days = days;
            Hired = false;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"-Renovator: {Name}");
            sb.AppendLine($"--Specialty: {Type}");
            sb.AppendLine($"--Rate per day: {Rate} BGN");

            return sb.ToString().TrimEnd();
        }
    }
}
