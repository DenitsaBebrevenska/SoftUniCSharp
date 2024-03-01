using MilitaryElite.Models.Contracts;

namespace MilitaryElite.Models
{
    public class Spy : Soldier, ISpy
    {
        public int CodeNumber { get; }

        public Spy(string id, string firstName, string lastName, int codeNumber) : base(id, firstName, lastName)
        {
            CodeNumber = codeNumber;
        }

        public override string ToString()
        {
            return base.ToString() + $"{Environment.NewLine}Code Number: {CodeNumber}";
        }
    }
}
