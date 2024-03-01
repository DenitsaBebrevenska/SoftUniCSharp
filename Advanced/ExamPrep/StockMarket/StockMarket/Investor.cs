using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockMarket
{
    public class Investor
    {
        private List<Stock> portfolio;

        public Investor(string fullName, string emailAddress, decimal moneyToInvest, string brokerName)
        {
            FullName = fullName;
            EmailAddress = emailAddress;
            MoneyToInvest = moneyToInvest;
            BrokerName = brokerName;
            portfolio = new List<Stock>();
        }

        public string FullName { get; private set; }
        public string EmailAddress { get; private set; }
        public decimal MoneyToInvest { get; private set; }
        public string BrokerName { get; private set; }

        public int Count => portfolio.Count;

        public IReadOnlyCollection<Stock> Portfolio => portfolio.AsReadOnly();

        public void BuyStock(Stock stock)
        {
            if (stock.MarketCapitalization > 10_000 && MoneyToInvest >= stock.PricePerShare)
            {
                portfolio.Add(stock);
                MoneyToInvest -= stock.PricePerShare;
            }
        }

        public string SellStock(string companyName, decimal sellPrice)
        {
            Stock stock = portfolio.FirstOrDefault(s => s.CompanyName == companyName);

            if (stock is null)
            {
                return $"{companyName} does not exist.";
            }

            if (sellPrice < stock.PricePerShare)
            {
                return $"Cannot sell {companyName}.";
            }

            portfolio.Remove(stock);
            MoneyToInvest += sellPrice;
            return $"{companyName} was sold.";
        }

        public Stock FindStock(string companyName)
        {
            Stock stock = portfolio.FirstOrDefault(s => s.CompanyName == companyName);

            return stock;
        }

        public Stock FindBiggestCompany() => portfolio.OrderByDescending(s => s.MarketCapitalization).FirstOrDefault();

        public string InvestorInformation()
        {
            StringBuilder reportBuilder = new StringBuilder();
            reportBuilder.AppendLine($"The investor {FullName} with a broker {BrokerName} has stocks:");

            foreach (var stock in portfolio)
            {
                reportBuilder.AppendLine(stock.ToString());
            }

            return reportBuilder.ToString().TrimEnd();
        }
    }
}
