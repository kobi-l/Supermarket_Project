using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketProject
{
    public class ShoppingCart
    {
        public string CustomerName { get; set; }

        public Dictionary<string, IProduct> Products { get; set; }

        public ShoppingCart(string customerName)
        {
            CustomerName = customerName;
            Products = new Dictionary<string, IProduct>();
        }

        #region METHODS

        public void AddProduct(IProduct product)
        {
            if (!Products.TryGetValue(product.ProductName, out IProduct existingProduct))
                Products.Add(product.ProductName, product);

            else if (Products.TryGetValue(product.ProductName, out IProduct invoiceProduct))
                ProductQuantityUpdate(product.ProductName, product.ProductQuantity);
        }

        public void RemoveProduct(string productName) => Products.Remove(productName);


        public void RemoveAllProducts() => Products.Clear();

        public void ProductQuantityUpdate(string productName, int quantity = 1)
        {
            if (Products.TryGetValue(productName, out IProduct existingProduct))
            {
                existingProduct.ProductQuantity += quantity;

                if (existingProduct.ProductQuantity <= 0)
                {
                    existingProduct.ProductQuantity = 0;
                    RemoveProduct(productName);
                }
            }
        }

        public decimal InvoiceSubtotal() => Products.Sum(product => product.Value.GetProductTotalPrice());

        public decimal InvoiceTax() => Products.Sum(product => product.Value.GetProductTax() * product.Value.GetProductTotalPrice());

        public decimal InvoiceTotal() => InvoiceSubtotal() + InvoiceTax();

        #endregion
    }
}
