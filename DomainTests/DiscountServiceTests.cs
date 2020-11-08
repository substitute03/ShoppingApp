using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace DomainTests
{
    [TestClass]
    public class DiscountServiceTests
    {
        [DataTestMethod]
        [DataRow(2, 1, "0.55")]
        [DataRow(1, 1, "0.55")]
        [DataRow(3, 2, "1.1")]
        [DataRow(3, 3, "1.65")]
        public void For_each_soup_bought_price_of_one_bread_should_be_half(int countBread, int countSoup, string expectedDiscount)
        {
            // Arrange
            decimal expected = decimal.Parse(expectedDiscount);
            var basket = new ShoppingBasket(new DiscountService());    

            basket.AddProduct(new Bread(), countBread);
            basket.AddProduct(new Soup(), countSoup);

            var bill = new Bill(basket);

            // Act
            decimal actual = bill.SpecialOffers
                .Where(so  => so.ProductType == ProductType.Bread)
                .Select(so => so.Discount)
                .Single();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [DataTestMethod]
        [DataRow(2, "0.9")]
        [DataRow(3, "0.9")]
        [DataRow(4, "1.8")]
        [DataRow(5, "1.8")]
        public void For_each_two_cheeses_bought_one_should_be_free(int countCheese, string expectedDiscount)
        {
            // Arrange
            decimal expected = decimal.Parse(expectedDiscount);
            var basket = new ShoppingBasket(new DiscountService());

            basket.AddProduct(new Cheese(), countCheese);

            var bill = new Bill(basket);

            // Act
            decimal actual = bill.SpecialOffers
                .Where(so => so.ProductType == ProductType.Cheese)
                .Select(so => so.Discount)
                .Single();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [DataTestMethod]
        [DataRow(1, "0.4")]
        [DataRow(2, "0.8")]
        [DataRow(3, "1.2")]
        public void Price_of_each_butter_should_be_reduced_by_one_third(int countButter, string expectedDiscount)
        {
            // Arrange
            decimal expected = decimal.Parse(expectedDiscount);
            var basket = new ShoppingBasket(new DiscountService());

            basket.AddProduct(new Butter(), countButter);

            var bill = new Bill(basket);

            // Act
            decimal actual = bill.SpecialOffers
                .Where(so => so.ProductType == ProductType.Butter)
                .Select(so => so.Discount)
                .Single();

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
