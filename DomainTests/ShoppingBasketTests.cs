using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DomainTests
{
    [TestClass]
    public class ShoppingBasketTests
    {
        [DataTestMethod]
        [DataRow(1, 1)]
        [DataRow(2, 2)]
        [DataRow(10, 10)]
        [DataRow(100, 100)]
        public void Can_add_a_product_to_the_basket(int numberToAdd, int expectedItemsInBasket)
        {
            // Arrange
            var basket = new ShoppingBasket(null);

            // Act
            basket.AddProduct(new Product(decimal.Zero, ProductType.Bread), numberToAdd);

            // Assert
            Assert.AreEqual(expectedItemsInBasket, basket.Products.Count);
        }

        [DataTestMethod]
        [DataRow(1, 5)]
        [DataRow(2, 10)]
        [DataRow(10, 50)]
        [DataRow(100, 500)]
        public void Can_add_multiple_product_types_to_the_basket(int numberToAdd, int expectedItemsInBasket)
        {
            // Arrange
            var basket = new ShoppingBasket(null);

            // Act
            basket.AddProduct(new Product(decimal.Zero, ProductType.Bread), numberToAdd);
            basket.AddProduct(new Product(decimal.Zero, ProductType.Milk), numberToAdd);
            basket.AddProduct(new Product(decimal.Zero, ProductType.Cheese), numberToAdd);
            basket.AddProduct(new Product(decimal.Zero, ProductType.Butter), numberToAdd);
            basket.AddProduct(new Product(decimal.Zero, ProductType.Soup), numberToAdd);

            // Assert
            Assert.AreEqual(expectedItemsInBasket, basket.Products.Count);
        }

        [DataTestMethod]
        [DataRow(1)]
        [DataRow(2)]
        [DataRow(10)]
        [DataRow(100)]
        public void Can_remove_all_items_from_the_basket(int numberToAddAndRemove)
        {
            // Arrange
            var basket = new ShoppingBasket(null);

            // Act
            basket.AddProduct(new Product(decimal.Zero, ProductType.Bread), numberToAddAndRemove);
            basket.RemoveProduct(new Product(decimal.Zero, ProductType.Bread), numberToAddAndRemove);

            // Assert
            Assert.AreEqual(0, basket.Products.Count);
        }

        [DataTestMethod]
        [DataRow(2, 1, 1)]
        [DataRow(10, 5, 5)]
        [DataRow(100, 50, 50)]
        [DataRow(500, 100, 400)]
        public void Can_remove_some_items_from_the_basket(int numberToAdd, int numberToRemove, int expectedNumberLeftInBasket)
        {
            // Arrange
            var basket = new ShoppingBasket(null);

            // Act
            basket.AddProduct(new Product(decimal.Zero, ProductType.Bread), numberToAdd);
            basket.RemoveProduct(new Product(decimal.Zero, ProductType.Bread), numberToRemove);

            // Assert
            Assert.AreEqual(expectedNumberLeftInBasket, basket.Products.Count);
        }

        [DataTestMethod]
        [DataRow(0, 1, 0)]
        [DataRow(2, 3, 0)]
        [DataRow(10, 11, 0)]
        [DataRow(100, 500, 0)]
        [DataRow(500, 1000, 0)]
        public void Removing_more_items_than_are_in_the_basket_removes_all_the_items(int numberToAdd, int numberToRemove, int expectedNumberLeftInBasket)
        {
            // Arrange
            var basket = new ShoppingBasket(null);

            // Act
            basket.AddProduct(new Product(decimal.Zero, ProductType.Bread), numberToAdd);
            basket.RemoveProduct(new Product(decimal.Zero, ProductType.Bread), numberToRemove);

            // Assert
            Assert.AreEqual(expectedNumberLeftInBasket, basket.Products.Count);
        }
    }
}
