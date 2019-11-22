using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketProject
{
    public abstract class ProductAbstract : IProduct
    {
        public string ProductName { get; set; }
        public int ProductQuantity { get; set; }
        public decimal ProductPrice { get; set; }

        // Regular way:
        //public virtual decimal GetProductTax()
        //{
        //    return 0.1M;
        //}

        // Expression-Bodied way:
        public virtual decimal GetProductTax() => .1M;

        // Regular Way:
        //public decimal GetProductTotalPrice()
        //{
        //    return ProductQuantity * ProductPrice;
        //}

        // Expression-Bodied way:
        public decimal GetProductTotalPrice() => ProductQuantity * ProductPrice;


        // Regular way:
        //public virtual string GenerateItemLine()
        //{
        //    return $"{ProductName,-15}{ProductQuantity,5}{ProductPrice,7:C}";
        //}

        // Expression-Bodied way:
        public virtual string GenerateItemLine() => $"{ProductName,-15}{ProductQuantity,5}{ProductPrice,7:C}";


    }
}
