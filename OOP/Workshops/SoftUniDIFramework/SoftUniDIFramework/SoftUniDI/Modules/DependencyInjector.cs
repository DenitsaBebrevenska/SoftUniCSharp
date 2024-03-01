using SoftUniDI.Injectors;
using SoftUniDI.Modules.Contracts;

namespace SoftUniDI.Modules;
public class DependencyInjector
{
    public static Injector CreateInjector(IModule module)
    {
        module.Configure();
        return new Injector(module);
    }
}
