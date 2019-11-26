using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketProject
{
    // READ:
    // Look at KidsToys and FruitAndVegiitables classes to see how it should be built. 
    // The way this class is done is ok but to make a program easily extendale it should be built in a way 
    // the KidsToys and FruitAndVegiitables classes were built.

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
