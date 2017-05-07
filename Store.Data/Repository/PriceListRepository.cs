using System.Collections.Generic;

namespace Store.Data.Repository
{
    public class PriceListRepository
    {
        public Dictionary<Product, double> GetPriceList()
        {
            return new Dictionary<Product, double>
            {
                { Product.Classic, 269.99 },
                { Product.Standout, 322.99 },
                { Product.Premium, 394.99 }
            };
        }
    }
}
