using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Renovators
{
    public class Catalog
    {
        private List<Renovator> renovators;

        public string Name { get; private set; }
        public int NeededRenovators { get; private set; }
        public string Project { get; private set; }

        public IReadOnlyCollection<Renovator> Renovators => renovators.AsReadOnly();

        public Catalog(string name, int neededRenovators, string project)
        {
            Name = name;
            NeededRenovators = neededRenovators;
            Project = project;
            renovators = new List<Renovator>();
        }
        public int Count => renovators.Count;

        public string AddRenovator(Renovator renovator)
        {
            if (string.IsNullOrWhiteSpace(renovator.Name) || string.IsNullOrWhiteSpace(renovator.Type))
            {
                return "Invalid renovator's information.";
            }

            if (renovators.Count == NeededRenovators)
            {
                return "Renovators are no more needed.";
            }

            if (renovator.Rate > 350.00)
            {
                return "Invalid renovator's rate.";
            }

            renovators.Add(renovator);
            return $"Successfully added {renovator.Name} to the catalog.";
        }

        public bool RemoveRenovator(string name)
        {
            Renovator renovator = renovators.FirstOrDefault(r => r.Name == name);

            if (renovator != null)
            {
                renovators.Remove(renovator);
                return true;
            }

            return false;
        }
        public int RemoveRenovatorBySpecialty(string type)
        {
            int count = renovators.Count(r => r.Type == type);
            renovators.RemoveAll(r => r.Type == type);
            return count;
        }

        public Renovator HireRenovator(string name)
        {
            Renovator renovator = renovators.FirstOrDefault(r => r.Name == name);

            if (renovator != null)
            {
                renovator.Hired = true;
            }

            return renovator;
        }

        public List<Renovator> PayRenovators(int days)
            => renovators.Where(r => r.Days >= days).ToList();

        public string Report()
        {
            StringBuilder reportBuilder = new StringBuilder();
            reportBuilder.AppendLine($"Renovators available for Project {Project}:");

            foreach (var renovator in renovators.Where(r => r.Hired == false))
            {
                reportBuilder.AppendLine(renovator.ToString());
            }

            return reportBuilder.ToString().TrimEnd();
        }
    }
}
