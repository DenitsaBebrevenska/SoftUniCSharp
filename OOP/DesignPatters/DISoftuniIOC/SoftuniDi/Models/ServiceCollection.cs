using SoftuniDi.Models.Contracts;

namespace SoftuniDi.Models;
public class ServiceCollection
{
    private Dictionary<Type, Type> mappings;
    private Dictionary<Type, Func<IServiceProviderr, object>> mappingsWithFactories;

    public ServiceCollection()
    {
        mappings = new Dictionary<Type, Type>();
        mappingsWithFactories = new Dictionary<Type, Func<IServiceProviderr, object>>();
    }

    // ILogger -> ConsoleLogger
    public void AddSingleton(Type interfaceType, Type implementationType)
    {
        mappings.Add(interfaceType, implementationType);
    }

    public void AddSingleton<TInterface, TImplementation>()
    {
        AddSingleton(typeof(TInterface), typeof(TImplementation));
    }

    public void AddSingleton<TInterface, TImplementation>(Func<IServiceProviderr, object> factory)
    {
        AddSingleton(typeof(TInterface), factory);
    }

    public void AddSingleton(Type interfaceType, Func<IServiceProviderr, object> factory)
    {
        mappingsWithFactories.Add(interfaceType, factory);
    }

    public Type GetMapping(Type interfaceType)
    {
        return mappings[interfaceType];
    }

    public Func<IServiceProviderr, object> GetFactoryMapping(Type interfaceType)
    {
        if (!mappingsWithFactories.ContainsKey(interfaceType))
        {
            return null;
        }

        return mappingsWithFactories[interfaceType];
    }

    public IServiceProviderr BuildServiceProvider()
    {
        return new ServiceProvider(this);
    }
}