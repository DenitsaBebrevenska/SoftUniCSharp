namespace MilitaryElite.Models.Contracts
{
    public interface IEngineer : ISpecialisedSoldier
    {
        public IReadOnlyCollection<Repair> Repairs { get; }
    }
}
