using Store.Data.Repository;

namespace Store.Data.Models
{
    public class PricingRule
    {
        public Client Client { get; set; }

        public Product Product { get; set; }

        public double Discount { get; set; }

        public int NumberOfItems { get; set; }
    }
}