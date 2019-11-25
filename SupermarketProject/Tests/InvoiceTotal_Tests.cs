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
    public class InvoiceTotal_Tests
    {
        [TestMethod]
        public void InvoiceTotalIsBeingCalculatedBasdOfProductPriceAndTaxRate_WhenProductIsAdded_Test()
        {
            //Arrange
            var shoppingCart = new ShoppingCart("Loyal");
            var product = new Product1();
            shoppingCart.AddProduct(product);

            //Act
            var expected = product.ProductPrice + product.ProductPrice * product.GetProductTax();

            //Assert
            Assert.AreEqual(expected, shoppingCart.InvoiceTotal());
        }

        [TestMethod]
        public void InvoiceTotalIsBeingUpdated_WhenIncreasingProductsQuantity_Test()
        {
            //Arrange
            var shoppingCart = new ShoppingCart("Loyal");
            var product = new Product1(2);
            shoppingCart.AddProduct(product);

            //Act
            var expected = product.GetProductTotalPrice() + (product.ProductPrice * 2 * product.GetProductTax());

            //Assert
            Assert.AreEqual(expected, shoppingCart.InvoiceTotal());
        }

        [TestMethod]
        public void InvoiceTotalIsBeingUpdated_WhenDecreasingProductsQuantity_Test()
        {
            //Arrange
            var shoppingCart = new ShoppingCart("Loyal");
            var product = new Product1(4);
            shoppingCart.AddProduct(product);
            shoppingCart.ProductQuantityUpdate(product.ProductName, -2);

            //Act
            var expected = product.GetProductTotalPrice() + (product.ProductPrice * 2 * product.GetProductTax());

            //Assert
            Assert.AreEqual(expected, shoppingCart.InvoiceTotal());
        }

        [TestMethod]
        public void InvoiceTotalIsBeingUpdated_WhenRemovingAProductFromShoppingCart_Test()
        {
            //Arrange
            var shoppingCart = new ShoppingCart("Loyal");
            var product = new Product1(4);
            shoppingCart.AddProduct(product);
            shoppingCart.RemoveProduct(product.ProductName);

            //Act
            var expected = 0;

            //Assert
            Assert.AreEqual(expected, shoppingCart.InvoiceTotal());
        }

        [TestMethod]
        public void InvoiceTotalIsBeingUpdated_WhenRemovingAllProductFromShoppingCart_Test()
        {
            //Arrange
            var shoppingCart = new ShoppingCart("Loyal");
            var product = new Product1(4);
            shoppingCart.AddProduct(product);
            shoppingCart.RemoveAllProducts();

            //Act
            var expected = 0;

            //Assert
            Assert.AreEqual(expected, shoppingCart.InvoiceTotal());
        }
    }
}
