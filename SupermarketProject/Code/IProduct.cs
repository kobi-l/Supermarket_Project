using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketProject
{
    public interface IProduct
    {
        string ProductName { get; set; }
        int ProductQuantity { get; set; }
        decimal ProductPrice { get; set; }

        decimal GetProductTax();
        decimal GetProductTotalPrice();
        void QuantityUpdate(double newQuantity);
        double GetQuantity();
        string GenerateItemLine();
    }
}
