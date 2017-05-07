using System.Collections.Generic;
using Store.BusinessLogic.Interfaces;
using Store.Data.Interfaces;
using Store.Data.Models;
using Store.Data.Repository;

namespace Store.BusinessLogic.Services
{
    public class PricingRulesService : IPricingRules
    {
        private Client _client;
        private List<PricingRule> _allOffers;

        // TODO: Remove this constructor and make IPricingRuleRepository as injectable
        public PricingRulesService(Client client)
        {
            SetOfferService(client, new PricingRuleRepository());
        }
        
        public PricingRulesService(Client client, IPricingRuleRepository pricingRuleRepository)
        {
            SetOfferService(client, pricingRuleRepository);
        }

        private void SetOfferService(Client client, IPricingRuleRepository pricingRuleRepository)
        {
            _allOffers = pricingRuleRepository.GetOffers();
            _client = client;
        }

        public Client GetClient()
        {
            return _client;
        }

        public List<PricingRule> GetPricingRules()
        {
            return _allOffers.FindAll(x => x.Client == _client);
        }
    }
}
