using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockMarket
{
    public class Investor
    {
        private List<Stock> portfolio;
        private string fullName;
        private string emailAddress;
        private decimal moneyToInvest;
        private string brokerName;

        public Investor(string fullName, string emailAddress, decimal moneyToInvest, string brokerName)
        {
            FullName = fullName;
            EmailAddress = emailAddress;
            MoneyToInvest = moneyToInvest;
            BrokerName = brokerName;
            portfolio = new List<Stock>();
        }

        public List<Stock> Portfolio { get => portfolio; set => portfolio = value; }
        public string FullName { get => fullName; set => fullName = value; }
        public string EmailAddress { get => emailAddress; set => emailAddress = value; }
        public decimal MoneyToInvest { get => moneyToInvest; set => moneyToInvest = value; }
        public string BrokerName { get => brokerName; set => brokerName = value; }
        public int Count { get => portfolio.Count; }

        public void BuyStock(Stock stock)
        {
            if (stock.MarketCapitalization > 10000 && MoneyToInvest >= stock.PricePerShare)
            {
                MoneyToInvest -= stock.PricePerShare;
                portfolio.Add(stock);
            }
        }

        public string SellStock(string companyName, decimal sellPrice)
        {
            if (portfolio.Any(x => x.CompanyName == companyName))
            {
                Stock stockForSell = portfolio.Single(x => x.CompanyName == companyName);
                if (sellPrice < stockForSell.PricePerShare)
                {
                    return $"Cannot sell {companyName}.";
                }
                else
                {
                    portfolio.Remove(stockForSell);
                    return $"{companyName} was sold.";                   
                }
            }
            else
                return $"{companyName} does not exist.";
        }

        public Stock FindStock(string companyName)
        {
            if (portfolio.Any(x => x.CompanyName == companyName))
            {
                return portfolio.Single(x => x.CompanyName == companyName);
            }
            else
                return null;
        }

        public Stock FindBiggestCompany()
        {
            if (Count != 0)
            {
                return portfolio.OrderByDescending(x => x.MarketCapitalization).First();
            }
            else
                return null;
        }

        public string InvestorInformation()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"The investor {fullName} with a broker {brokerName} has stocks:");
            foreach (var stock in portfolio)
            {
                sb.AppendLine(stock.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
