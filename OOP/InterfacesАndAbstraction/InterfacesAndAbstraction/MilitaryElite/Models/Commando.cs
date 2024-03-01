using MilitaryElite.Enums;
using MilitaryElite.Models.Contracts;
using System.Text;

namespace MilitaryElite.Models
{
    public class Commando : SpecialisedSoldier, ICommando
    {
        public Commando(string id, string firstName, string lastName, decimal salary, Corps corps, IReadOnlyCollection<Mission> missions)
            : base(id, firstName, lastName, salary, corps)
        {
            Missions = missions;
        }

        public IReadOnlyCollection<Mission> Missions { get; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine("Missions:");
            foreach (var mission in Missions)
            {
                sb.AppendLine("  " + mission);
            }

            return sb.ToString().TrimEnd();
        }
    }
}
