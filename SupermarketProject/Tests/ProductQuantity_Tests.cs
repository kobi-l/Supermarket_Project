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
            shoppingCart.ProductQuantityUpdate(product.ProductName, 2);

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
            shoppingCart.ProductQuantityUpdate(product.ProductName, -3);

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
            shoppingCart.ProductQuantityUpdate(product.ProductName, -2);

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
            shoppingCart.ProductQuantityUpdate(product.ProductName, -5);

            //Act

            //Assert
            //Assert.AreEqual(0, product.ProductQuantity);
            Assert.AreEqual(0, shoppingCart.Products.Count);
        }

        [TestMethod]
        public void ProductsQuantity_AddingTheSameProductTwice_Expected_ProductQuantityShouldIncrease_Test()
        {
            //Arrange
            var shoppingCart = new ShoppingCart("Loyal");
            var product = new Product1(3);

            var expectedQuantity = 6;
            var expectedProductLine = 1;
            //Act
            shoppingCart.AddProduct(product);
            shoppingCart.AddProduct(product);

            //Assert
            Assert.AreEqual(expectedQuantity, product.ProductQuantity);
            Assert.AreEqual(expectedProductLine, shoppingCart.Products.Count);
        }

        [TestMethod]
        public void ProductsQuantity_AddingVariousProductsInAnyOrder_Expected_ProductQuantityShouldIncrease_Test()
        {
            // Arrange
            var shoppingCart = new ShoppingCart("Loyal");
            var product1 = new Product1(3);
            var product2 = new Product2();
            var product3 = new Product3(4);

            var expectedQuantityP1 = 6;
            var expectedQuantityP2 = 2;
            var expectedQuantityP3 = 8;

            var expectedProductLine = 3;

            // Act
            shoppingCart.AddProduct(product1);
            shoppingCart.AddProduct(product2);
            shoppingCart.AddProduct(product3);
            shoppingCart.AddProduct(product2);
            shoppingCart.AddProduct(product1);
            shoppingCart.AddProduct(product3);
            //shoppingCart.AddProduct(product1);
            //shoppingCart.AddProduct(product2);
            //shoppingCart.AddProduct(product3);

            // Assert for product quantity
            Assert.AreEqual(expectedQuantityP1, product1.ProductQuantity);
            Assert.AreEqual(expectedQuantityP2, product2.ProductQuantity);
            Assert.AreEqual(expectedQuantityP3, product3.ProductQuantity);

            // Assert for product line
            Assert.AreEqual(expectedProductLine, shoppingCart.Products.Count);
        }

        [TestMethod]
        public void ProductsQuantity_AddingProductMoreThanTwo2_Test()
        {
            //Arrange
            var shoppingCart = new ShoppingCart("Loyal");
            var product1 = new KidsToys("toy", 5);
            var product2 = new KidsToys("toy", 5);
            var product3 = new KidsToys("toy", 5);
            shoppingCart.AddProduct(product1);
            shoppingCart.AddProduct(product2);
            shoppingCart.AddProduct(product3);

            var expectedQuantity = 3;
            //Act
            var actual = shoppingCart.Products["toy"].GetQuantity();

            //Assert
            Assert.AreEqual(expectedQuantity, actual);
        }


        [TestMethod]
        public void ProductsQuantity_AddingProductMoreThanTwo3_Test()
        {
            //Arrange
            var shoppingCart = new ShoppingCart("Loyal");
            var product1 = new KidsToys("toy", 5);
            var product2 = new KidsToys("toy", 10);
            var product3 = new KidsToys("toy", 15);

            shoppingCart.AddProduct(product3);
            shoppingCart.AddProduct(product1);
            shoppingCart.AddProduct(product2);
            

            var expectedQuantity = 5;
            //Act
            var actual = shoppingCart.Products["toy"].ProductPrice;

            //Assert
            Assert.AreEqual(expectedQuantity, actual);
        }
    }
}
