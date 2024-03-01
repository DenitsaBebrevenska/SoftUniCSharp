namespace SoftUniDI.Modules.Contracts;
public interface IModule
{
    void Configure();

    Type GetMapping(Type currentInterface, object attribute);

    object GetInstance(Type implementation);

    void SetInstance(Type implementation, object instance);
}
