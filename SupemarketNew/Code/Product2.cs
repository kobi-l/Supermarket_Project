using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupemarketNew
{
    public class Product2 : ProductAbstract
    {
        public Product2(int productQuantity = 1)
        {
            ProductName = "Apples";
            ProductPrice = 7.49M;
            ProductQuantity = productQuantity;
        }
    }
}
