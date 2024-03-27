using ChristmasPastryShop.Factories.Contracts;
using ChristmasPastryShop.Models.Cocktails;
using ChristmasPastryShop.Models.Cocktails.Contracts;

namespace ChristmasPastryShop.Factories
{
    public class CocktailFactory : IFactory<ICocktail>
    {
        public ICocktail Create(string type, params string[] details)
        {
            switch (type)
            {
                case "Hibernation":
                    return new Hibernation(details[0], details[1]);
                case "MulledWine":
                    return new MulledWine(details[0], details[1]);
                default:
                    return null;
            }
        }
    }
}
