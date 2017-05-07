using System.Collections.Generic;
using Store.Data.Models;
using Store.Data.Repository;

namespace Store.BusinessLogic.Interfaces
{
    public interface IPricingRules
    {
        Client GetClient();
        List<PricingRule> GetPricingRules();
    }
}
