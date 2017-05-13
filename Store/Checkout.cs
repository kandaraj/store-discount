using System.Collections.Generic;
using Store.BusinessLogic.Interfaces;
using Store.BusinessLogic.Services;
using Store.Data.Repository;

namespace Store
{
    public class Checkout
    {
        private readonly Dictionary<Product, double> _prices;
        private readonly DiscountCalculationService _discountCalculationService;

        public Checkout(IPricingRules pricingRules, IPriceList priceList)
        {
            _prices = priceList.GetPriceList();
            _discountCalculationService = new DiscountCalculationService(pricingRules);   
        }

        public double Total { get; private set; }

        public void Add(Product item)
        {
            Total += _prices[item];
            Total -= _discountCalculationService.GetDiscount(item);
        }
 
    }
}