namespace MilitaryElite.Models.Contracts
{
    public interface ILeutenantGeneral : IPrivate
    {
        IReadOnlyCollection<Private> Privates { get; }
    }
}
