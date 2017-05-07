using System.Collections.Generic;
using Store.Data.Models;

namespace Store.Data.Interfaces
{
    public interface IPricingRuleRepository
    {
        List<PricingRule> GetOffers();
    }
}