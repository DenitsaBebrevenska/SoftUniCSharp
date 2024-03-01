using MilitaryElite.Enums;
using MilitaryElite.Models.Contracts;
using System.Text;

namespace MilitaryElite.Models
{
    public class Engineer : SpecialisedSoldier, IEngineer
    {
        public IReadOnlyCollection<Repair> Repairs { get; }

        public Engineer(string id, string firstName, string lastName, decimal salary, Corps corps, IReadOnlyCollection<Repair> repairs)
            : base(id, firstName, lastName, salary, corps)
        {
            Repairs = repairs;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine("Repairs:");
            foreach (var repair in Repairs)
            {
                sb.AppendLine("  " + repair);
            }

            return sb.ToString().TrimEnd();
        }
    }
}
