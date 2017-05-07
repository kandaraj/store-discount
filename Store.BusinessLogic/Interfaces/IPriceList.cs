using System.Collections.Generic;
using Store.Data.Repository;

namespace Store.BusinessLogic.Interfaces
{
    public interface IPriceList
    {
        Dictionary<Product, double> GetPriceList();
    }
}