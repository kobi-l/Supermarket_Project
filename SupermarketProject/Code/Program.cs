using SupemarketProject;
using System;

namespace SupermarketProject
{
    class Program
    {
        static void Main(string[] args)
        {
            // New Sale
            var shoppingCart = new ShoppingCart("Miss Loyalty");

            // adding products from KidsToys class
            var toy1 = new KidsToys("Lego Small", 10M);
            shoppingCart.AddProduct(toy1);

            var toy2 = new KidsToys("Teddy Bear", 10M);
            shoppingCart.AddProduct(toy2);
            shoppingCart.AddProduct(toy2);

            var toy3 = new KidsToys("Race Car", 10M);
            shoppingCart.AddProduct(toy3);

            // adding products from FruitAndApples class
            var fruitAndVeggie1 = new FruitAndVeggies("Golden Apples", 10M, 2.5);
            shoppingCart.AddProduct(fruitAndVeggie1);
            shoppingCart.AddProduct(fruitAndVeggie1);

            var fruitAndVeggie2 = new FruitAndVeggies("Roman Tomatoes", 10M, 0.5);
            shoppingCart.AddProduct(fruitAndVeggie2);
            shoppingCart.AddProduct(fruitAndVeggie2);

            var fruitAndVeggie3 = new FruitAndVeggies("Bananas", 10M, 1.9);
            shoppingCart.AddProduct(fruitAndVeggie3);
            shoppingCart.AddProduct(fruitAndVeggie3);
            

            // generating receipt
            var receipt = new GenerateReceipt(shoppingCart);
            receipt.WindowSizeOfReceiptPrintout();
            Console.Write(receipt.HeaderOfReceiptPrintout());
            Console.Write(receipt.ContentOfReceiptPrintout());

            Console.ReadKey();


            // using Product1, Product2, Product3:

            //var product1 = new Product1();
            //shoppingCart.AddProduct(product1);

            //var product2 = new Product2();
            //shoppingCart.AddProduct(product2);

            //var product3 = new Product3(2);
            //shoppingCart.AddProduct(product3);

            // product quantity update
            //shoppingCart.ProductQuantityUpdate(product3.ProductName, -3);
        }
    }
}
