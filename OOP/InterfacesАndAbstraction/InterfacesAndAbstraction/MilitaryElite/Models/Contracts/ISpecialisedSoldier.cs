using MilitaryElite.Enums;

namespace MilitaryElite.Models.Contracts
{
    public interface ISpecialisedSoldier : IPrivate
    {
        Corps Corps { get; }
    }
}
