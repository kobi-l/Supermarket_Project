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

        // Expression-Bodied way:
        public virtual decimal GetProductTax() => .1M;

        // Expression-Bodied way:
        public virtual decimal GetProductTotalPrice() => ProductQuantity * ProductPrice;

        // Expression-Bodied way:
        public virtual string GenerateItemLine() => $"{ProductName,-10}{ProductQuantity,11}{ProductPrice,14:C}";

        public virtual void QuantityUpdate(double newQuantity) => ProductQuantity += (int)(newQuantity);

        public virtual double GetQuantity() => ProductQuantity;
    }
}
