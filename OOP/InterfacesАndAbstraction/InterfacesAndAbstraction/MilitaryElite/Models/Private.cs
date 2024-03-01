using MilitaryElite.Models.Contracts;

namespace MilitaryElite.Models
{
    public class Private : Soldier, IPrivate
    {
        public Private(string id, string firstName, string lastName, decimal salary) : base(id, firstName, lastName)
        {
            Salary = salary;
        }
        public decimal Salary { get; }

        public override string ToString()
        {
            return base.ToString() + $" Salary: {Salary:F2}";
        }
    }
}
