namespace UniversityCompetition.Factories.Contracts
{
    public interface IFactory<T>
    {
        T Create(string type, params string[] details);
    }
}
