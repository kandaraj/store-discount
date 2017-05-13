using System.Collections.Generic;
using Store.BusinessLogic.Interfaces;
using Store.Data.Models;
using Store.Data.Repository;

namespace Store.BusinessLogic.Services
{
    public class DiscountCalculationService
    {
        private readonly List<PricingRule> _offers;
        private readonly Dictionary<Product, int> _itemCounters;
        private readonly Client _client;

        public DiscountCalculationService(IPricingRules pricingRules)
        {
            _offers = pricingRules.GetPricingRules();
            _client = pricingRules.GetClient();
            _itemCounters = new Dictionary<Product, int>();
        }

        private void IncrementItem(Product item)
        {
            if (!_itemCounters.ContainsKey(item))
            {
                _itemCounters.Add(item, 0);
            }
            _itemCounters[item]++;
        }

        public double GetDiscount(Product product)
        {
            IncrementItem(product);
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
