using MyLogger.Core.Layouts.Contracts;

namespace MyLogger.Factories.Contracts
{
    public interface ILayoutFactory
    {
        ILayout CreateLayout(string type);
    }
}
