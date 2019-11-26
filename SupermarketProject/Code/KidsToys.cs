using SupermarketProject;
using System.Collections.Generic;
using System.Linq;

namespace SupermarketProject
{
    public class KidsToys : ProductAbstract
    {
        public KidsToys(string productName, decimal productPrice, int productQuantity = 1)
        {
            ProductName = productName;
            ProductPrice = productPrice;
            ProductQuantity = productQuantity;
        }
    }
}
