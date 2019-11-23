using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketProject
{
    public class Product1 : ProductAbstract
    {
        public Product1(int productQuantity = 1) 
        {
            ProductName = "Bananas";
            ProductPrice = 4.99M;
            ProductQuantity = productQuantity;
        }

        // Tax override uisng the expression-bodied way:
        public override decimal GetProductTax() => .05M;
    }
}
