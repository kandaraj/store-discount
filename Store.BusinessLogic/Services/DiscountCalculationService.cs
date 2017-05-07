using System.Collections.Generic;
using Store.Data.Models;
using Store.Data.Repository;

namespace Store.BusinessLogic.Services
{
    public static class DiscountCalculationService
    {
        public static double GetDiscount(Product product, List<PricingRule> offers)
        {
            foreach (var offer in offers)
            {
                if (offer.Product == product)
                {
                    return offer.Discount;
                }
            }

            return 0;
        }
    }
}
