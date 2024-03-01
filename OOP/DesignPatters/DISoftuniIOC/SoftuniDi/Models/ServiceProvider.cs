using SoftuniDi.Models.Contracts;
using System.Reflection;

namespace SoftuniDi.Models;
public class ServiceProvider : IServiceProviderr
{
    private ServiceCollection serviceCollection;

    public ServiceProvider(ServiceCollection serviceCollection)
    {
        this.serviceCollection = serviceCollection;
    }

    public object GetRequiredService(Type interfaceType)
    {
        var factory = serviceCollection.GetFactoryMapping(interfaceType);
        if (factory != null)
        {
            return factory(this);
        }

        Type implementationType = serviceCollection.GetMapping(interfaceType);

        ConstructorInfo constructor = implementationType.GetConstructors().OrderBy(x => x.GetParameters().Length).ToList()[0];

        object[] parameters = new object[constructor.GetParameters().Length];
        int index = 0;

        foreach (ParameterInfo parameter in constructor.GetParameters())
        {
            parameters[index++] = GetRequiredService(parameter.ParameterType);
        }

        object implementation = Activator.CreateInstance(implementationType, parameters);

        return implementation;
    }


    public T GetRequiredService<T>()
    {
        return (T)GetRequiredService(typeof(T));
    }
}
