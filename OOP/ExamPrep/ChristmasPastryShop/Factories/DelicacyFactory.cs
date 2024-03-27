using ChristmasPastryShop.Factories.Contracts;
using ChristmasPastryShop.Models.Delicacies;
using ChristmasPastryShop.Models.Delicacies.Contracts;

namespace ChristmasPastryShop.Factories
{
    public class DelicacyFactory : IFactory<IDelicacy>
    {
        public IDelicacy Create(string type, params string[] details)
        {
            switch (type)
            {
                case "Gingerbread":
                    return new Gingerbread(details[0]);
                case "Stolen":
                    return new Stolen(details[0]);
                default:
                    return null;
            }
        }
    }
}
