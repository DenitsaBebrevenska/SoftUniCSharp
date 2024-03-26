using ChristmasPastryShop.Models.Booths.Contracts;
using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories;
using ChristmasPastryShop.Repositories.Contracts;
using ChristmasPastryShop.Utilities.Messages;
using System;
using System.Text;

namespace ChristmasPastryShop.Models.Booths
{
    public class Booth : IBooth
    {
        private int capacity;

        public Booth(int boothId, int capacity)
        {
            BoothId = boothId;
            Capacity = capacity;
            DelicacyMenu = new DelicacyRepository();
            CocktailMenu = new CocktailRepository();
            CurrentBill = 0;
            Turnover = 0;
            IsReserved = false;
        }
        public int BoothId { get; private set; }

        public int Capacity
        {
            get => capacity;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.CapacityLessThanOne);
                }
                capacity = value;
            }
        }
        public IRepository<IDelicacy> DelicacyMenu { get; private set; }
        public IRepository<ICocktail> CocktailMenu { get; private set; }
        public double CurrentBill { get; private set; }
        public double Turnover { get; private set; }
        public bool IsReserved { get; private set; }

        public void UpdateCurrentBill(double amount)
            => CurrentBill += amount;

        public void Charge()
        {
            Turnover += CurrentBill;
            CurrentBill = 0;
        }

        public void ChangeStatus()
            => IsReserved = !IsReserved;

        public override string ToString()
        {
            StringBuilder boothString = new StringBuilder();
            boothString.AppendLine($"Booth: {BoothId}");
            boothString.AppendLine($"Capacity: {Capacity}");
            boothString.AppendLine($"Turnover: {Turnover:F2} lv");
            boothString.AppendLine("-Cocktail menu:");

            foreach (var cocktail in CocktailMenu.Models)
            {
                boothString.AppendLine($"--{cocktail}");
            }

            boothString.AppendLine("-Delicacy menu:");

            foreach (var delicacy in DelicacyMenu.Models)
            {
                boothString.AppendLine($"--{delicacy}");
            }

            return boothString.ToString().TrimEnd();
        }
    }
}
