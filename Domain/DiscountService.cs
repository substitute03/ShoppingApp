using System;
using System.Linq;

namespace Domain
{
    public class DiscountService : IDiscountService
    {
        /// <summary>
        /// Returns the eligible discount amount for cheese based on the contents of the shopping basket.
        /// </summary>
        /// <param name="basket"></param>
        /// <returns></returns>
        public decimal CalculateCheeseDiscount(ShoppingBasket basket)
        {
            int countCheese = basket.Products.OfType<Cheese>().Count();

            int numberToDiscount = countCheese / 2;

            decimal amountToDiscount = basket.Products.OfType<Cheese>()
                .First().Price * numberToDiscount;

            return Math.Round(amountToDiscount, 2);
        }

        /// <summary>
        /// Returns the eligible discount amount for bread based on the contents of the shopping basket.
        /// </summary>
        /// <param name="basket"></param>
        /// <returns></returns>
        public decimal CalculateBreadDiscount(ShoppingBasket basket)
        {
            int countSoup = basket.Products.OfType<Soup>().Count();

            int numberToDiscount = countSoup;

            decimal amountToDiscount = basket.Products.OfType<Bread>()
                .First().Price * numberToDiscount * 0.5M;

            return Math.Round(amountToDiscount, 2);
        }

        /// <summary>
        /// Returns the eligible discount amount for butter based on the contents of the shopping basket.
        /// </summary>
        /// <param name="basket"></param>
        /// <returns></returns>
        public decimal CalculateButterDiscount(ShoppingBasket basket)
        {
            int countButter = basket.Products.OfType<Butter>().Count();

            decimal amountToDiscount = basket.Products.OfType<Butter>()
                .First().Price * countButter * (1M / 3M);

            return Math.Round(amountToDiscount, 2);
        }
    }
}
