using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupemarketNew
{
    public class Product1 : ProductAbstract
    {
        public Product1(int productQuantity = 1) 
        {
            ProductName = "Bananas";
            ProductPrice = 4.99M;
            ProductQuantity = productQuantity;
        }

        // Expression-Bodied way:
        public override decimal GetProductTax() => .05M;
    }
}
