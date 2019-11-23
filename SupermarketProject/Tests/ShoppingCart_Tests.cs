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
    public class ShoppingCartNew_Tests
    {
        [TestMethod]
        public void ShoppingCart_Customer_GetsAssigned_Test()
        {
            //Arrange
            var shoppingCart = new ShoppingCart("Loyal");
            var expectedCustomerName = "Loyal";

            //Act
            var actual = shoppingCart.CustomerName;

            //Assert
            Assert.AreEqual(expectedCustomerName, actual);
        }

        [TestMethod]
        public void ProductCanBeAdded_toShoppingCart_Test()
        {
            //Arrange
            var shoppingCart = new ShoppingCart("Loyal");
            var product = new Product1();
            shoppingCart.AddProduct(product);
            //Act
            var actual = product.ProductQuantity;

            //Assert
            Assert.AreEqual(1, actual);
        }

        [TestMethod]
        public void RemoveProduct_Test()
        {
            //Arrange
            var shoppingCart = new ShoppingCart("Loyal");
            var product = new Product1(3);
            shoppingCart.AddProduct(product);
            shoppingCart.RemoveProduct(product.ProductName);
            //Act
            var actual = shoppingCart.Products.Count;

            //Assert
            Assert.AreEqual(0, actual);
        }

        [TestMethod]
        public void RemoveAllProduct_Test()
        {
            //Arrange
            var shoppingCart = new ShoppingCart("Loyal");
            var product = new Product1(3);
            var product1 = new Product2(2);

            shoppingCart.AddProduct(product);
            shoppingCart.AddProduct(product1);
            shoppingCart.RemoveAllProducts();

            //Act
            var actual = shoppingCart.Products.Count;

            //Assert
            Assert.AreEqual(0, actual);
        }
    }
}
