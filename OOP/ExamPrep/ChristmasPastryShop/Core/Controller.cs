using ChristmasPastryShop.Core.Contracts;
using ChristmasPastryShop.Factories;
using ChristmasPastryShop.Factories.Contracts;
using ChristmasPastryShop.Models.Booths;
using ChristmasPastryShop.Models.Booths.Contracts;
using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories;
using ChristmasPastryShop.Repositories.Contracts;
using ChristmasPastryShop.Utilities.Messages;
using System.Linq;
using System.Text;

namespace ChristmasPastryShop.Core
{
    public class Controller : IController
    {
        private IRepository<IBooth> booths;
        private IFactory<IDelicacy> delicacyFactory;
        private IFactory<ICocktail> cocktailFactory;
        public Controller()
        {
            booths = new BoothRepository();
            delicacyFactory = new DelicacyFactory();
            cocktailFactory = new CocktailFactory();
        }
        public string AddBooth(int capacity)
        {
            int id = booths.Models.Count + 1;
            booths.AddModel(new Booth(id, capacity));

            return string.Format(OutputMessages.NewBoothAdded, id, capacity);
        }

        public string AddDelicacy(int boothId, string delicacyTypeName, string delicacyName)
        {
            IDelicacy delicacy = delicacyFactory.Create(delicacyTypeName, delicacyName);

            if (delicacy is null)
            {
                return string.Format(OutputMessages.InvalidDelicacyType, delicacyTypeName);
            }

            IBooth booth = booths.Models.FirstOrDefault(b => b.BoothId == boothId);

            if (booth.DelicacyMenu.Models.Any(d => d.Name == delicacyName))
            {
                return string.Format(OutputMessages.DelicacyAlreadyAdded, delicacyName);
            }

            booth.DelicacyMenu.AddModel(delicacy);
            return string.Format(OutputMessages.NewDelicacyAdded, delicacyTypeName, delicacyName);
        }

        public string AddCocktail(int boothId, string cocktailTypeName, string cocktailName, string size)
        {
            ICocktail cocktail = cocktailFactory.Create(cocktailTypeName, cocktailName, size);

            if (cocktail is null)
            {
                return string.Format(OutputMessages.InvalidCocktailType, cocktailTypeName);
            }

            if (size != "Small" && size != "Middle" && size != "Large")
            {
                return string.Format(OutputMessages.InvalidCocktailSize, size);
            }

            IBooth booth = booths.Models.FirstOrDefault(b => b.BoothId == boothId);

            if (booth.CocktailMenu.Models
                    .Any(c => c.Name == cocktailName && c.Size == size))
            {
                return string.Format(OutputMessages.CocktailAlreadyAdded, size, cocktailName);
            }

            booth.CocktailMenu.AddModel(cocktail);
            return string.Format(OutputMessages.NewCocktailAdded, size, cocktailName, cocktailTypeName);
        }

        public string ReserveBooth(int countOfPeople)
        {
            var boothsOrdered = booths.Models.OrderBy(b => b.Capacity)
                .ThenByDescending(b => b.BoothId);
            IBooth booth = boothsOrdered.FirstOrDefault(b => !b.IsReserved && b.Capacity >= countOfPeople);

            if (booth is null)
            {
                return string.Format(OutputMessages.NoAvailableBooth, countOfPeople);
            }

            booth.ChangeStatus();
            return string.Format(OutputMessages.BoothReservedSuccessfully, booth.BoothId, countOfPeople);
        }

        public string TryOrder(int boothId, string order)
        {
            string[] orderDetails = order.Split('/');
            string type = orderDetails[0];
            string name = orderDetails[1];
            int count = int.Parse(orderDetails[2]);
            IBooth booth = booths.Models.FirstOrDefault(b => b.BoothId == boothId);
            ICocktail cocktail = null;
            IDelicacy delicacy = null;

            if (orderDetails.Length == 3)
            {
                delicacy = delicacyFactory.Create(type, name);
            }
            else
            {
                string size = orderDetails[3];
                cocktail = cocktailFactory.Create(type, name, size);
            }

            if (cocktail is null && delicacy is null)
            {
                return string.Format(OutputMessages.NotRecognizedType, type);
            }

            if (cocktail != null)
            {
                if (booth.CocktailMenu.Models.All(c => c.Name != name))
                {
                    return string.Format(OutputMessages.NotRecognizedItemName, type, name);
                }

                if (booth.CocktailMenu.Models.Any(c => c.Name == name && c.Size == cocktail.Size))
                {
                    booth.UpdateCurrentBill(cocktail.Price * count);
                    return string.Format(OutputMessages.SuccessfullyOrdered, boothId, count, name);
                }

                return string.Format(OutputMessages.CocktailStillNotAdded, cocktail.Size, name);
            }

            //delicacy is not null

            if (booth.DelicacyMenu.Models.All(d => d.Name != name))
            {
                return string.Format(OutputMessages.NotRecognizedItemName, type, name);
            }

            if (booth.DelicacyMenu.Models.Any(d => d.Name == name))
            {
                booth.UpdateCurrentBill(delicacy.Price * count);
                return string.Format(OutputMessages.SuccessfullyOrdered, boothId, count, name);
            }

            return string.Format(OutputMessages.DelicacyStillNotAdded, type, name);
        }

        public string LeaveBooth(int boothId)
        {
            IBooth booth = booths.Models.FirstOrDefault(b => b.BoothId == boothId);

            double currentBill = booth.CurrentBill;
            booth.Charge();
            booth.ChangeStatus();

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Format(OutputMessages.GetBill, $"{currentBill:F2}"));
            sb.AppendLine(string.Format(OutputMessages.BoothIsAvailable, boothId));

            return sb.ToString().TrimEnd();
        }

        public string BoothReport(int boothId)
        {
            IBooth booth = booths.Models.FirstOrDefault(b => b.BoothId == boothId);

            return booth.ToString();
        }
    }
}
