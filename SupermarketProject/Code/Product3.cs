using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketProject
{
    public class Product3 : ProductAbstract
    {
        public Product3(int productQuantity = 1)
        {
            ProductName = "Watermelon";
            ProductPrice = 3.99M;
            ProductQuantity = productQuantity;
        }

        // Tax override
        public override decimal GetProductTax() => .02M;
    }
}
