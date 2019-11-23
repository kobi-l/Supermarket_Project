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
    public class ProductQuantity_Tests
    {
        [TestMethod]
        public void ProductGetsAdded_With_DefaultQuantityOfOne_Test()
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
        public void ProductCanBeAdded_With_MultipleQuantity_Test()
        {
            //Arrange
            var shoppingCart = new ShoppingCart("Loyal");
            var product = new Product1(3);
            shoppingCart.AddProduct(product);
            //Act
            var actual = product.ProductQuantity;

            //Assert
            Assert.AreEqual(3, actual);
        }

        [TestMethod]
        public void ProductCount_DoesntChage_WhenAddingAProduct_withMultipleQuantity_Test()
        {
            //Arrange
            var shoppingCart = new ShoppingCart("Loyal");
            var product = new Product1(3);
            shoppingCart.AddProduct(product);
            //Act
            var actual = shoppingCart.Products.Count;

            //Assert
            Assert.AreEqual(1, actual);
        }

        [TestMethod]
        public void ProductsQuantity_CanBeIncreased_Test()
        {
            //Arrange
            var shoppingCart = new ShoppingCart("Loyal");
            var product = new Product1();
            shoppingCart.AddProduct(product);
            shoppingCart.IncreaseProductQuantity(product.ProductName, 2);

            //Act
            var actual = product.ProductQuantity;

            //Assert
            Assert.AreEqual(3, actual);
        }

        [TestMethod]
        public void ProductsQuantity_CanBeDecreased_Test()
        {
            //Arrange
            var shoppingCart = new ShoppingCart("Loyal");
            var product = new Product1(5);
            shoppingCart.AddProduct(product);
            shoppingCart.IncreaseProductQuantity(product.ProductName, -3);

            //Act
            var actual = product.ProductQuantity;

            //Assert
            Assert.AreEqual(2, actual);
        }

        [TestMethod]
        public void ProductsQuantity_DecreasingToZero_ExpectedRemoveProductFromShoppingCard_Test()
        {
            //Arrange
            var shoppingCart = new ShoppingCart("Loyal");
            var product = new Product1(2);
            shoppingCart.AddProduct(product);
            shoppingCart.IncreaseProductQuantity(product.ProductName, -2);

            //Act

            //Assert
            Assert.AreEqual(0, product.ProductQuantity);
            Assert.AreEqual(0, shoppingCart.Products.Count);
        }

        [TestMethod]
        public void ProductsQuantity_DecreasingToBelowZero_Expected_RemoveProductFromShoppingCard_Test()
        {
            //Arrange
            var shoppingCart = new ShoppingCart("Loyal");
            var product = new Product1(2);
            shoppingCart.AddProduct(product);
            shoppingCart.IncreaseProductQuantity(product.ProductName, -5);

            //Act

            //Assert
            Assert.AreEqual(0, product.ProductQuantity);
            Assert.AreEqual(0, shoppingCart.Products.Count);
        }
    }
}
