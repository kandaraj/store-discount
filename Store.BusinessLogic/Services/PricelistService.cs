using System.Collections.Generic;
using Store.BusinessLogic.Interfaces;
using Store.Data.Repository;

namespace Store.BusinessLogic.Services
{
    public class PricelistService: IPriceList
    {
        public Dictionary<Product, double> GetPriceList()
        {
            return new PriceListRepository().GetPriceList();
        }
    }
}
