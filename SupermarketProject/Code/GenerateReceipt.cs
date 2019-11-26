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

        // Receipt window size
        public void WindowSizeOfReceiptPrintout() //<-- this move to program
        {
            Console.SetWindowSize(40, 30);
            Console.BufferHeight = 40;
            Console.BufferWidth = 40;
        }

        // Receipt Header
        public string HeaderOfReceiptPrintout()
        {
            var receiptHeader = new StringBuilder();
            receiptHeader.Append("Supermarket JUSTEEN's");
            receiptHeader.AppendLine();
            receiptHeader.Append("205 Moonwalk Dr, Sunny City");
            receiptHeader.AppendLine();
            receiptHeader.Append(DateTime.UtcNow);
            receiptHeader.AppendLine();
            receiptHeader.AppendLine();

            return receiptHeader.ToString();
        }

        // Receipt Content
        public string ContentOfReceiptPrintout()
        {
            var receiptContent = new StringBuilder();

            receiptContent.Append($"Customer: {ShoppingCart.CustomerName}");
            receiptContent.AppendLine();
            receiptContent.AppendLine();
            receiptContent.Append("Purchases: ");
            receiptContent.AppendLine();

            foreach (var product in ShoppingCart.Products)
            {
                receiptContent.Append(product.Value.GenerateItemLine());
                receiptContent.AppendLine();
            }

            receiptContent.AppendLine();

            receiptContent.Append("------------------------------------");
            receiptContent.AppendLine();

            receiptContent.Append("Subtotal:".PadRight(20, ' ') + $"{ShoppingCart.InvoiceSubtotal(),16:C}");
            receiptContent.AppendLine();
            receiptContent.Append("Tax:".PadRight(20, ' ') + $"{ShoppingCart.InvoiceTax(),16:C}");
            receiptContent.AppendLine();
            receiptContent.Append("Total:".PadRight(20, ' ') + $"{ShoppingCart.InvoiceTotal(),16:C}");
            receiptContent.AppendLine();

            receiptContent.AppendLine();
            receiptContent.AppendLine();

            // Products Sold:
            receiptContent.Append($"Products Sold: {ShoppingCart.Products.Sum(product => product.Value.ProductQuantity)}");

            return receiptContent.ToString();
        }

        #region GENERATE RECEIPT using Console.WriteLine()
        public void GetReceiptPrintout()
        {
            //Windows size &remove scrollbars
            Console.SetWindowSize(45, 45);
            Console.BufferHeight = 45;
            Console.BufferWidth = 45;

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

            Console.WriteLine("-----------------------------------");

            Console.WriteLine("Subtotal:".PadRight(20, ' ') + $"{ShoppingCart.InvoiceSubtotal(),14:C}");
            Console.WriteLine("Tax:".PadRight(20, ' ') + $"{ShoppingCart.InvoiceTax(),14:C}");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Total:".PadRight(20, ' ') + $"{ShoppingCart.InvoiceTotal(),14:C}");
            Console.ResetColor();

            Console.Write(Environment.NewLine);
            Console.Write(Environment.NewLine);

            // Products Sold:
            Console.WriteLine($"Products Sold: {ShoppingCart.Products.Sum(product => product.Value.ProductQuantity)}");
            Console.ReadKey();
        }
        #endregion
    }
}
