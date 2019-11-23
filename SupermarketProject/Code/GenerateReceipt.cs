using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketProject
{
    public class GenerateReceipt 
    {
        private ShoppingCart ShoppingCart { get; }

        public GenerateReceipt(ShoppingCart shoppingCart)
        {
            ShoppingCart = shoppingCart;
        }

        public void GetReceiptPrintout()
        {            
            //Windows size &remove scrollbars
            Console.SetWindowSize(30, 30);
            Console.BufferHeight = 40;
            Console.BufferWidth = 30;

            //Header of the Invoice
            Console.WriteLine("Supermarket JUSTEEN's");
            Console.WriteLine("205 Moonwalk Dr, Sunny City");
            Console.WriteLine(DateTime.UtcNow);
            Console.Write(Environment.NewLine);

            // Invoice content
            Console.WriteLine($"Customer: {ShoppingCart.CustomerName}");
            Console.WriteLine("Purchases: ");

            foreach (var product in ShoppingCart.Products)
                Console.WriteLine(product.Value.GenerateItemLine());

            Console.WriteLine("----------------------------");

            Console.WriteLine("Subtotal:".PadRight(20, ' ') + $"{ShoppingCart.InvoiceSubtotal(),7:C}");
            Console.WriteLine("Tax:".PadRight(20, ' ') + $"{ShoppingCart.InvoiceTax(),7:C}");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Total:".PadRight(20, ' ') + $"{ShoppingCart.InvoiceTotal(),7:C}");
            Console.ResetColor();

            Console.Write(Environment.NewLine);
            Console.Write(Environment.NewLine);

            // Products Sold:
            Console.WriteLine($"Products Sold: {ShoppingCart.Products.Sum(product => product.Value.ProductQuantity)}");
            Console.ReadKey();
        }
    }
}
