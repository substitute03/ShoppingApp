using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace DomainTests
{
    [TestClass]
    public class DiscountServiceTests
    {
        [DataTestMethod]
        [DataRow(2, 1, "0.55")] // Buy a soup and two breads - only one bread should be reduced.
        [DataRow(1, 1, "0.55")]
        [DataRow(3, 2, "1.1")]
        [DataRow(3, 3, "1.65")]
        public void For_each_soup_bought_price_of_one_bread_should_be_half(int countBread, int countSoup, string expectedBreadDiscount)
        {
            // Arrange
            decimal expected = decimal.Parse(expectedBreadDiscount);
            var basket = new ShoppingBasket(new DiscountService());    

            basket.AddProduct(new Product(1.1M, ProductType.Bread), countBread);
            basket.AddProduct(new Product(0.6M, ProductType.Soup), countSoup);

            // Act
            var bill = new Bill(basket);

            decimal actual = bill.SpecialOffers
                .Where(so => so.ProductType == ProductType.Bread)
                .Sum(so => so.Discount);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [DataTestMethod]
        [DataRow(2, "0.9")]
        [DataRow(3, "0.9")] // Buy three cheeses - only one should be free.
        [DataRow(4, "1.8")] // Buy four cheeses - two now should be free.
        [DataRow(5, "1.8")]
        public void For_each_two_cheeses_bought_one_should_be_free(int countCheese, string expectedCheeseDiscount)
        {
            // Arrange
            decimal expected = decimal.Parse(expectedCheeseDiscount);
            var basket = new ShoppingBasket(new DiscountService());

            basket.AddProduct(new Product(0.9M, ProductType.Cheese), countCheese);

            // Act
            var bill = new Bill(basket);

            decimal actual = bill.SpecialOffers
                .Where(so => so.ProductType == ProductType.Cheese)
                .Sum(so => so.Discount);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [DataTestMethod]
        [DataRow(1, "0.4")] // Butter alone.
        [DataRow(2, "0.8")] // Butter alone.
        [DataRow(3, "1.2")] // Butter alone.
        public void Price_of_each_butter_should_be_reduced_by_one_third(int countButter, string expectedButterDiscount)
        {
            // Arrange
            decimal expected = decimal.Parse(expectedButterDiscount);
            var basket = new ShoppingBasket(new DiscountService());

            basket.AddProduct(new Product(1.2M, ProductType.Butter), countButter);

            // Act
            var bill = new Bill(basket);

            decimal actual = bill.SpecialOffers
                .Where(so => so.ProductType == ProductType.Butter)
                .Sum(so => so.Discount);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void All_discounts_applied_when_basket_is_eligible_for_all_discounts()
        {
            // Arrange
            decimal expectedBreadDiscount = 0.55M;
            decimal expectedCheeseDiscount = 0.6M;
            decimal expectedButterDiscount = 0.4M;
            decimal expectedMilkDiscount = 0M;

            var basket = new ShoppingBasket(new DiscountService());

            // Buy a soup and two breads - only one bread should be reduced.
            basket.AddProduct(new Product(1.1M, ProductType.Bread), 2);
            basket.AddProduct(new Product(0.6M, ProductType.Soup), 1);

            // Buy three cheeses - only one should be free.
            basket.AddProduct(new Product(0.6M, ProductType.Cheese), 3);

            // Butter with other things
            basket.AddProduct(new Product(1.2M, ProductType.Butter), 1);

            basket.AddProduct(new Product(0.5M, ProductType.Milk), 5);

            // Act
            var bill = new Bill(basket);

            decimal actualBreadDiscount = bill.SpecialOffers
                .Where(so => so.ProductType == ProductType.Bread)
                .Sum(so => so.Discount);

            decimal actualCheeseDiscount = bill.SpecialOffers
                .Where(so => so.ProductType == ProductType.Cheese)
                .Sum(so => so.Discount);

            decimal actualButterDiscount = bill.SpecialOffers
                .Where(so => so.ProductType == ProductType.Butter)
                .Sum(so => so.Discount);

            decimal actualMilkDiscount = bill.SpecialOffers
                .Where(so => so.ProductType == ProductType.Milk)
                .Sum(so => so.Discount);
              
            // Assert
            Assert.AreEqual(expectedBreadDiscount, actualBreadDiscount);
            Assert.AreEqual(expectedCheeseDiscount, actualCheeseDiscount);
            Assert.AreEqual(expectedButterDiscount, actualButterDiscount);
            Assert.AreEqual(expectedMilkDiscount, actualMilkDiscount);
        }

        [TestMethod]
        public void Milk_is_not_discounted()
        {
            // Arrange
            decimal expectedMilkDiscount = 0M;

            var basket = new ShoppingBasket(new DiscountService());

            basket.AddProduct(new Product(0.5M, ProductType.Milk), 5);

            // Act
            var bill = new Bill(basket);

            decimal actualMilkDiscount = bill.SpecialOffers
                .Where(so => so.ProductType == ProductType.Milk)
                .Sum(so => so.Discount);

            // Assert
            Assert.AreEqual(expectedMilkDiscount, actualMilkDiscount);
        }
    }
}
