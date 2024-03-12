namespace RobotService.Factories.Contracts
{
    public interface IFactory<out T>
    {
        public T CreateInstance(string typeName, params string[] tokens);
    }
}
