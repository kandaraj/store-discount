using System;
using NUnit.Framework;
using Store.BusinessLogic.Interfaces;
using Store.BusinessLogic.Services;
using Store.Data.Repository;

namespace Store.Test
{
    [TestFixture]
    public class CheckoutFixture
    {
        [TestCase(Client.Unilevel, "classic,classic,classic,premium", 934.97)]
        [TestCase(Client.Unilevel, "classic,classic,classic,premium", 934.97)]
        [TestCase(Client.Default, "classic,standout,premium", 987.97)]
        [TestCase(Client.Apple, "standout,standout,standout,premium", 1294.96)]
        [TestCase(Client.Nike, "premium,premium,premium,premium", 1519.96)]
        [TestCase(Client.Ford, "classic,classic,classic,classic,classic", 1079.96)]
        [TestCase(Client.Ford, "standout", 309.99)]
        [TestCase(Client.Ford, "standout,standout,standout", 929.97)]
        [TestCase(Client.Ford, "premium,premium,premium", 1169.97)]
        public void ScanMultipleItems_TotalIsSum(Client client, string items, double total)
        {
            IPricingRules pricingRules = new PricingRulesService(client);
            IPriceList pricelist = new PricelistService();
            ScanMultipleItems(pricingRules, pricelist, items, total);
        }

        private void ScanMultipleItems(IPricingRules pricingRules, IPriceList priceList, string items, double total)
        {
            // Arrange
            var checkout = new Checkout(pricingRules, priceList);
            var list = items.Split(',');
            // Act
            foreach (var t in list)
            {
                Product result;
                Enum.TryParse(t, true, out result);
                checkout.Add(result);
            }

            // Assert
            Assert.AreEqual(total, checkout.Total);
        }
    }
}