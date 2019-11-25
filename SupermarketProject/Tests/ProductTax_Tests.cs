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
    public class ProductTax_Tests
    {
        [TestMethod]
        public void DefaultProductTaxGetApplied_WhenThereWasNoOverride_Test()
        {
            //Arrange
            var shoppingCart = new ShoppingCart("Loyal");
            var product = new Product2();
            shoppingCart.AddProduct(product);

            //Act
            var expected = product.ProductPrice * 0.1m;

            //Assert
            Assert.AreEqual(expected, shoppingCart.InvoiceTax());
        }


        [TestMethod]
        public void TaxOverrideGetsApplied_WhenThereWasOverride_Test()
        {
            //Arrange
            var shoppingCart = new ShoppingCart("Loyal");
            var product = new Product1();
            shoppingCart.AddProduct(product);

            //Act
            var expected = product.ProductPrice * 0.05m;

            //Assert
            Assert.AreEqual(expected, shoppingCart.InvoiceTax());
        }

        [TestMethod]
        public void TaxGetsUpdatedAccordingly_WhenIncreasingProductsQuantity_Test()
        {
            //Arrange
            var shoppingCart = new ShoppingCart("Loyal");
            var product = new Product1();
            shoppingCart.AddProduct(product);
            shoppingCart.ProductQuantityUpdate(product.ProductName, 3);

            //Act
            var expected = product.ProductPrice * 4 * 0.05m;

            //Assert
            Assert.AreEqual(expected, shoppingCart.InvoiceTax());
        }

        [TestMethod]
        public void TaxGetsUpdatedAccordingly_WhenDecreasingProductsQuantity_Test()
        {
            //Arrange
            var shoppingCart = new ShoppingCart("Loyal");
            var product = new Product1(4);
            shoppingCart.AddProduct(product);
            shoppingCart.ProductQuantityUpdate(product.ProductName, -2);

            //Act
            var expected = product.ProductPrice * 2 * 0.05m;

            //Assert
            Assert.AreEqual(expected, shoppingCart.InvoiceTax());
        }
    }
}
