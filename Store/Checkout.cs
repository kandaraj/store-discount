using System.Collections.Generic;
using Store.BusinessLogic.Interfaces;
using Store.Data.Models;
using Store.Data.Repository;

namespace Store
{
    public class Checkout
    {
        private readonly Client _client;
        private readonly Dictionary<Product, double> _prices;
        private readonly List<PricingRule> _offers;
        private readonly Dictionary<Product, int> _itemCounters;

        public Checkout(IPricingRules pricingRules, IPriceList priceList)
        {
            _client = pricingRules.GetClient();
            _offers = pricingRules.GetPricingRules();
            _prices = priceList.GetPriceList();
            _itemCounters = new Dictionary<Product, int>();   
        }
        public double Total { get; private set; }

        public void Add(Product item)
        {
            IncrementItem(item);
            Total += _prices[item];
            Total -= GetDiscount(item);
        }

        private void IncrementItem(Product item)
        {
            if (!_itemCounters.ContainsKey(item))
            {
                _itemCounters.Add(item, 0);
            }
            _itemCounters[item]++;
        }

        // Move discount logic into DiscountCalculationService
        private double GetDiscount(Product product)
        {
            foreach (var offer in _offers)
            {
                if (IsValidOffer(product, offer)) return offer.Discount;
            }

            return 0;
        }

        private bool IsValidOffer(Product product, PricingRule pricingRule)
        {
            if (pricingRule.Client == _client & pricingRule.Product == product & _itemCounters[product] == pricingRule.NumberOfItems)
            {
                _itemCounters[product] = 0;
                return true;
            }
            return false;
        }
    }
}