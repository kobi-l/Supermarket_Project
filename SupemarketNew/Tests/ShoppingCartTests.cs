using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace SupermarketProject.Tests
{
    [TestClass]
    public class ShoppingCartTests
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
    }
}
