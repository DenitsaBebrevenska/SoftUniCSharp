using System.Text;

namespace SoftUniKindergarten
{
    public class Kindergarten
    {
        public string Name { get; private set; }
        public int Capacity { get; private set; }

        public List<Child> Registry { get; private set; }
        public int ChildrenCount => Registry.Count;

        public Kindergarten(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            Registry = new List<Child>();
        }

        public bool AddChild(Child child)
        {
            if (Capacity > Registry.Count)
            {
                Registry.Add(child);
                return true;
            }

            return false;
        }


        public bool RemoveChild(string childFullName)
        {
            string[] names = childFullName.Split();
            Child child = Registry.FirstOrDefault(c => c.FirstName == names[0] && c.LastName == names[1]);

            if (child != null)
            {
                Registry.Remove(child);
                return true;
            }

            return false;
        }

        public Child GetChild(string childFullName)
        {
            string[] names = childFullName.Split();
            Child child = Registry.FirstOrDefault(c => c.FirstName == names[0] && c.LastName == names[1]);
            return child;
        }

        public string RegistryReport()
        {
            StringBuilder reportBuilder = new();
            reportBuilder.AppendLine($"Registered children in {Name}:");

            foreach (var child in Registry.OrderByDescending(c => c.Age)
                         .ThenBy(c => c.LastName)
                         .ThenBy(c => c.FirstName))
            {
                reportBuilder.AppendLine(child.ToString());
            }

            return reportBuilder.ToString().TrimEnd();
        }
    }
}
