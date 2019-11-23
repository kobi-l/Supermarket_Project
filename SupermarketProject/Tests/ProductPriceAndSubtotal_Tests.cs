using Microsoft.VisualStudio.TestTools.UnitTesting;
using SupermarketProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupemarketProject.Tests
{
    [TestClass]
    public class ProductPriceAndSubtotal_Tests
    {
        [TestMethod]
        public void DefaultProductPriceGetApplied_WhenProductIsAdded_Test()
        {
            //Arrange
            var shoppingCart = new ShoppingCart("Loyal");
            var product = new Product1();
            shoppingCart.AddProduct(product);
            //Act
            var expected = product.ProductPrice;

            //Assert
            Assert.AreEqual(expected, shoppingCart.InvoiceSubtotal());
        }

        [TestMethod]
        public void ProductSubtotalGetsUpdated_WhenIncreasingProductsQuantity_Test()
        {
            //Arrange
            var shoppingCart = new ShoppingCart("Loyal");
            var product = new Product1();
            shoppingCart.AddProduct(product);
            shoppingCart.IncreaseProductQuantity(product.ProductName, 3);

            //Act
            var expected = product.ProductPrice * 4;

            //Assert
            Assert.AreEqual(expected, shoppingCart.InvoiceSubtotal());
        }

        [TestMethod]
        public void ProductSubtotalGetsUpdated_WhenDecreasingProductsQuantity_Test()
        {
            //Arrange
            var shoppingCart = new ShoppingCart("Loyal");
            var product = new Product1(4);
            shoppingCart.AddProduct(product);
            shoppingCart.IncreaseProductQuantity(product.ProductName, -2);

            //Act
            var expected = product.ProductPrice * 2;

            //Assert
            Assert.AreEqual(expected, shoppingCart.InvoiceSubtotal());
        }


        [TestMethod]
        public void ProductSubtotalGetsUpdatedAccordingly_WhenVariousProductsInShoppingCart_Test()
        {
            //Arrange
            var shoppingCart = new ShoppingCart("Loyal");
            var product = new Product1(4);
            var product1 = new Product2(2);
            shoppingCart.AddProduct(product);
            shoppingCart.AddProduct(product1);

            //Act
            var expected = product.ProductPrice * 4 + product1.ProductPrice * 2;

            //Assert
            Assert.AreEqual(expected, shoppingCart.InvoiceSubtotal());
        }

        [TestMethod]
        public void ProductSubtotalGetsUpdatedAccordingly_WhenRemovingProductFromShoppingCart_Test()
        {
            //Arrange
            var shoppingCart = new ShoppingCart("Loyal");
            var product = new Product1(4);
            var product1 = new Product2(2);
            shoppingCart.AddProduct(product);
            shoppingCart.AddProduct(product1);
            shoppingCart.RemoveProduct(product.ProductName);

            //Act
            var expected = product1.ProductPrice * 2;

            //Assert
            Assert.AreEqual(expected, shoppingCart.InvoiceSubtotal());
        }

        [TestMethod]
        public void ProductSubtotalGetsSetToZero_WhenRemovingAllProductFromShoppingCart_Test()
        {
            //Arrange
            var shoppingCart = new ShoppingCart("Loyal");
            var product = new Product1(4);
            var product1 = new Product2(2);
            shoppingCart.AddProduct(product);
            shoppingCart.AddProduct(product1);
            shoppingCart.RemoveAllProducts();

            //Act
            var expected = 0;

            //Assert
            Assert.AreEqual(expected, shoppingCart.InvoiceSubtotal());
        }





        [TestMethod]
        public void DefaultProductTaxGetApplied_WhenThereWasNoOverride_Test()
        {
            //Arrange
            var shoppingCart = new ShoppingCart("Loyal");
            var product = new Product1();
            shoppingCart.AddProduct(product);
            //Act
            var expected = product.ProductPrice;

            //Assert
            Assert.AreEqual(expected, shoppingCart.InvoiceTotal() - shoppingCart.InvoiceTax());
        }
    }
}
