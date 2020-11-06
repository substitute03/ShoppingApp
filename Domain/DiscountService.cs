using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain
{
    public static class DiscountService
    {
        public static decimal CalculateCheeseDiscount(ShoppingCart cart)
        {
            int countCheese = cart.Products.OfType<Cheese>().Count();

            int numberToDiscount = countCheese / 2;

            decimal amountToDiscount = cart.Products.OfType<Cheese>()
                .First().Price * numberToDiscount;

            return amountToDiscount;
        }

        public static decimal CalculateSoupDiscount(ShoppingCart cart)
        {
            int countSoup = cart.Products.OfType<Soup>().Count();

            int numberToDiscount = countSoup / 2;

            decimal amountToDiscount = cart.Products.OfType<Bread>()
                .First().Price * numberToDiscount * 0.5M;

            return amountToDiscount;
        }

        public static decimal CalculateButterDiscount(ShoppingCart cart)
        {
            int countButter = cart.Products.OfType<Butter>().Count();

            decimal amountToDiscount = cart.Products.OfType<Butter>()
                .First().Price * countButter * (2M / 3M);

            return amountToDiscount;
        }
    }
}
