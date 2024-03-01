using MilitaryElite.Models.Contracts;
using System.Text;

namespace MilitaryElite.Models
{
    public class LieutenantGeneral : Private, ILeutenantGeneral
    {
        public IReadOnlyCollection<Private> Privates { get; }

        public LieutenantGeneral(string id, string firstName, string lastName, decimal salary, IReadOnlyCollection<Private> privates)
            : base(id, firstName, lastName, salary)
        {
            Privates = privates;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine("Privates:");

            foreach (var privateSoldier in Privates)
            {
                sb.AppendLine("  " + privateSoldier);
            }

            return sb.ToString().TrimEnd();
        }
    }
}
