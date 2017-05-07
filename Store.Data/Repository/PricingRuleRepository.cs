using System.Collections.Generic;
using Store.Data.Interfaces;
using Store.Data.Models;

namespace Store.Data.Repository
{
    public class PricingRuleRepository : IPricingRuleRepository
    {
        public List<PricingRule> GetOffers()
        {
            // TODO: To be read from config or db so every time this method gets called, read fresh data
            var offers = new List<PricingRule>
            {
                new PricingRule {Client = Client.Unilevel, Discount = 269.99, NumberOfItems = 3, Product = Product.Classic},
                new PricingRule {Client = Client.Apple, Discount = 23, NumberOfItems = 1, Product = Product.Standout},
                new PricingRule {Client = Client.Nike, Discount = 60, NumberOfItems = 4, Product = Product.Premium},
                new PricingRule {Client = Client.Ford, Discount = 269.99, NumberOfItems = 5, Product = Product.Classic},
                new PricingRule {Client = Client.Ford, Discount = 13, NumberOfItems = 1, Product = Product.Standout},
                new PricingRule {Client = Client.Ford, Discount = 15, NumberOfItems = 3, Product = Product.Premium}
            };

            return offers;
        }
    }
}
