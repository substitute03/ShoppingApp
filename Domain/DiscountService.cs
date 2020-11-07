using System;
using System.Linq;

namespace Domain
{
    public static class DiscountService
    {
        public static decimal CalculateCheeseDiscount(ShoppingBasket cart)
        {
            int countCheese = cart.Products.OfType<Cheese>().Count();

            int numberToDiscount = countCheese / 2;

            decimal amountToDiscount = cart.Products.OfType<Cheese>()
                .First().Price * numberToDiscount;

            return Math.Round(amountToDiscount, 2);
        }

        public static decimal CalculateBreadDiscount(ShoppingBasket cart)
        {
            int countSoup = cart.Products.OfType<Soup>().Count();

            int numberToDiscount = countSoup;

            decimal amountToDiscount = cart.Products.OfType<Bread>()
                .First().Price * numberToDiscount * 0.5M;

            return Math.Round(amountToDiscount, 2);
        }

        public static decimal CalculateButterDiscount(ShoppingBasket cart)
        {
            int countButter = cart.Products.OfType<Butter>().Count();

            decimal amountToDiscount = cart.Products.OfType<Butter>()
                .First().Price * countButter * (1M / 3M);

            return Math.Round(amountToDiscount, 2);
        }
    }
}
