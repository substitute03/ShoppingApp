using System;
using System.Linq;

namespace Domain
{
    public class DiscountService
    {
        /// <summary>
        /// Returns the eligible discount amount for cheese based on the contents of the shopping basket.
        /// </summary>
        /// <param name="basket"></param>
        /// <returns></returns>
        internal decimal CalculateCheeseDiscount(ShoppingBasket basket)
        {
            int countCheese = basket.Products.Count(p => p.Type == ProductType.Cheese);
            int numberToDiscount = countCheese / 2;

            decimal amountToDiscount = basket.Products
                .First(p => p.Type == ProductType.Cheese).Price * numberToDiscount;

            return Math.Round(amountToDiscount, 2);
        }

        /// <summary>
        /// Returns the eligible discount amount for bread based on the contents of the shopping basket.
        /// </summary>
        /// <param name="basket"></param>
        /// <returns></returns>
        internal decimal CalculateBreadDiscount(ShoppingBasket basket)
        {
            int countSoup = basket.Products.Count(p => p.Type == ProductType.Soup);
            int countBread = basket.Products.Count(p => p.Type == ProductType.Bread);
            int numberToDiscount = 0;

            if (countSoup >= countBread)
            {
                numberToDiscount = countBread;
            }
            else if (countBread > countSoup)
            {
                numberToDiscount = countSoup;
            }                

            decimal amountToDiscount = basket.Products
                .First(p => p.Type == ProductType.Bread).Price * numberToDiscount * 0.5M;

            return Math.Round(amountToDiscount, 2);
        }

        /// <summary>
        /// Returns the eligible discount amount for butter based on the contents of the shopping basket.
        /// </summary>
        /// <param name="basket"></param>
        /// <returns></returns>
        internal decimal CalculateButterDiscount(ShoppingBasket basket)
        {
            int countButter = basket.Products.Count(p => p.Type == ProductType.Butter);

            decimal amountToDiscount = basket.Products
                .First(p => p.Type == ProductType.Butter).Price * countButter * (1M / 3M);

            return Math.Round(amountToDiscount, 2);
        }
    }
}
