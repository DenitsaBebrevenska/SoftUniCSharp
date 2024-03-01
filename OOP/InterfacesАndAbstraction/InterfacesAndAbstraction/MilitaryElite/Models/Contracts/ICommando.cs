namespace MilitaryElite.Models.Contracts
{
    public interface ICommando : ISpecialisedSoldier
    {
        public IReadOnlyCollection<Mission> Missions { get; }
    }
}
