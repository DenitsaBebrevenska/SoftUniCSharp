using MyLogger.Core.Layouts;
using MyLogger.Core.Layouts.Contracts;
using MyLogger.CustomLayouts;
using MyLogger.Factories.Contracts;

namespace MyLogger.Factories
{
    public class LayoutFactory : ILayoutFactory
    {
        public ILayout CreateLayout(string type)
        {
            switch (type)
            {
                case "SimpleLayout":
                    return new SimpleLayout();
                case "XmlLayout":
                    return new XmlLayout();
                default:
                    throw new InvalidOperationException("Invalid layout type");
            }
        }
    }
}
