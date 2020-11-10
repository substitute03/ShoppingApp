using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace DomainTests
{
    [TestClass]
    public class ShoppingBasketTests
    {
        [DataTestMethod]
        [DataRow(1)]
        [DataRow(2)]
        [DataRow(10)]
        [DataRow(100)]
        public void Can_add_a_product_to_the_basket(int numberToAdd)
        {
            // Arrange
            var type = ProductType.Bread;
            var basket = new ShoppingBasket(null);
            var product = new Product(decimal.Zero, type);

            // Act
            basket.AddProduct(product, numberToAdd);

            // Assert
            Assert.AreEqual(numberToAdd, basket.GetItem(type).Amount);
        }

        [DataTestMethod]
        [DataRow(1)]
        [DataRow(2)]
        [DataRow(10)]
        [DataRow(100)]
        public void Can_add_multiple_product_types_to_the_basket(int numberToAdd)
        {
            // Arrange
            var basket = new ShoppingBasket(null);
            var bread = new Product(decimal.Zero, ProductType.Bread);
            var milk = new Product(decimal.Zero, ProductType.Milk);
            var cheese = new Product(decimal.Zero, ProductType.Cheese);
            var butter = new Product(decimal.Zero, ProductType.Butter);
            var soup = new Product(decimal.Zero, ProductType.Soup);

            // Act
            basket.AddProduct(bread, numberToAdd);
            basket.AddProduct(milk, numberToAdd);
            basket.AddProduct(cheese, numberToAdd);
            basket.AddProduct(butter, numberToAdd);
            basket.AddProduct(soup, numberToAdd);

            // Assert
            Assert.AreEqual(numberToAdd, basket.GetItem(ProductType.Bread).Amount);
            Assert.AreEqual(numberToAdd, basket.GetItem(ProductType.Milk).Amount);
            Assert.AreEqual(numberToAdd, basket.GetItem(ProductType.Cheese).Amount);
            Assert.AreEqual(numberToAdd, basket.GetItem(ProductType.Butter).Amount);
            Assert.AreEqual(numberToAdd, basket.GetItem(ProductType.Soup).Amount);
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
            var type = ProductType.Bread;
            var product = new Product(decimal.Zero, ProductType.Bread);

            // Act
            basket.AddProduct(product, numberToAddAndRemove);
            basket.RemoveProduct(product, numberToAddAndRemove);

            // Assert
            Assert.AreEqual(null, basket.GetItem(type));
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
            var type = ProductType.Bread;
            var product = new Product(decimal.Zero, type);

            // Act
            basket.AddProduct(product, numberToAdd);
            basket.RemoveProduct(product, numberToRemove);

            // Assert
            Assert.AreEqual(expectedNumberLeftInBasket, basket.GetItem(type).Amount);
        }

        [DataTestMethod]
        [DataRow(0, 1)]
        [DataRow(2, 3)]
        [DataRow(10, 11)]
        [DataRow(100, 500)]
        [DataRow(500, 1000)]
        public void Removing_more_items_than_are_in_the_basket_removes_all_the_items(int numberToAdd, int numberToRemove)
        {
            // Arrange
            var basket = new ShoppingBasket(null);
            var type = ProductType.Bread;
            var product = new Product(decimal.Zero, type);

            // Act
            basket.AddProduct(product, numberToAdd);
            basket.RemoveProduct(product, numberToRemove);

            // Assert
            Assert.AreEqual(null, basket.GetItem(type));
        }
    }
}
