using SoftUniDI.Attributes;
using SoftUniDI.Modules.Contracts;
using System.Reflection;

namespace SoftUniDI.Injectors;
public class Injector
{
    private IModule module;

    public Injector(IModule module)
    {
        this.module = module;
    }

    private bool CheckForFieldInjection<TClass>()
    {
        return typeof(TClass)
            .GetFields((BindingFlags)62)
            .Any(field => field.GetCustomAttributes(typeof(Inject), true).Any());
    }

    private bool CheckForConstructorInjection<TClass>()
    {
        return typeof(TClass)
            .GetConstructors()
            .Any(constructor => constructor.GetCustomAttributes(typeof(Inject), true).Any());
    }

    private TClass CreateConstructorInjection<TClass>()
    {
        var desiredClass = typeof(TClass);

        if (desiredClass == null)
        {
            return default(TClass);
        }

        var constructors = desiredClass.GetConstructors();

        foreach (var constructor in constructors)
        {
            if (!CheckForConstructorInjection<TClass>())
            {
                continue;
            }

            var inject = (Inject)constructor.GetCustomAttributes(typeof(Inject), true)
                .FirstOrDefault();
            var parameterTypes = constructor.GetParameters();
            var constructorParams = new object[parameterTypes.Length];
            var i = 0;

            foreach (var parameterType in parameterTypes)
            {
                var named = parameterType.GetCustomAttributes(typeof(Named));
                Type dependency = null;

                if (named == null)
                {
                    dependency = module.GetMapping(parameterType.ParameterType, inject);
                }
                else
                {
                    dependency = module.GetMapping(parameterType.ParameterType, named);
                }

                if (parameterType.ParameterType.IsAssignableFrom(dependency))
                {
                    object instance = module.GetInstance(dependency);

                    if (instance == null)
                    {
                        constructorParams[i++] = instance;
                    }
                    else
                    {
                        instance = Activator.CreateInstance(dependency);
                        constructorParams[i++] = instance;
                        module.SetInstance(parameterType.ParameterType, instance);
                    }
                }
            }

            return (TClass)Activator.CreateInstance(desiredClass, constructorParams);
        }

        return default(TClass);
    }

    private TClass CreateFieldInjection<TClass>()
    {
        var desiredClass = typeof(TClass);
        var desiredClassInstance = module.GetInstance(desiredClass);

        if (desiredClass == null)
        {
            desiredClassInstance = Activator.CreateInstance(desiredClass);
            module.SetInstance(desiredClass, desiredClassInstance);
        }

        var fields = desiredClass.GetFields((BindingFlags)62);

        foreach (var field in fields)
        {
            if (field.GetCustomAttributes(typeof(Inject), true).Any())
            {
                var injection = (Inject)field
                    .GetCustomAttributes(typeof(Inject), true)
                    .FirstOrDefault();

                Type dependency = null;

                var named = field.GetCustomAttributes(typeof(Named), true);
                var type = field.FieldType;

                if (named == null)
                {
                    dependency = module.GetMapping(type, injection);
                }
                else
                {
                    dependency = module.GetMapping(type, named);
                }

                if (type.IsAssignableFrom(dependency))
                {
                    object instance = module.GetInstance(dependency);

                    if (instance == null)
                    {
                        instance = Activator.CreateInstance(dependency);
                        module.SetInstance(dependency, instance);
                    }

                    field.SetValue(desiredClassInstance, instance);
                }
            }
        }

        return (TClass)desiredClassInstance;
    }

    public TClass Inject<TClass>()
    {
        var hasConstructorAttribute = CheckForConstructorInjection<TClass>();
        var hasFieldAttribute = CheckForFieldInjection<TClass>();

        if (hasConstructorAttribute && hasFieldAttribute)
        {
            throw new ArgumentException("There must be  only field or constructor annotated with Injection attribute");
        }

        if (hasConstructorAttribute)
        {
            return CreateConstructorInjection<TClass>();
        }

        if (hasFieldAttribute)
        {
            return CreateFieldInjection<TClass>();
        }

        return (TClass)default;
    }
}
