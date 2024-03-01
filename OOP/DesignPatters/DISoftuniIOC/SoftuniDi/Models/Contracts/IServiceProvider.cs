namespace SoftuniDi.Models.Contracts;
public interface IServiceProviderr
{
    public T GetRequiredService<T>();
    public object GetRequiredService(Type type);
}
