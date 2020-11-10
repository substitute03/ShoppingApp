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
            ShoppingBasketItem item = basket.GetItem(ProductType.Cheese);
            int numberToDiscount = item.Amount / 2;
            decimal discount = item.Product.Price * numberToDiscount;

            return Math.Round(discount, 2);
        }

        /// <summary>
        /// Returns the eligible discount amount for bread based on the contents of the shopping basket.
        /// </summary>
        /// <param name="basket"></param>
        /// <returns></returns>
        internal decimal CalculateBreadDiscount(ShoppingBasket basket)
        {
            ShoppingBasketItem soupInBasket = basket.GetItem(ProductType.Soup);
            ShoppingBasketItem breadInBasket = basket.GetItem(ProductType.Bread);
            int numberToDiscount = Math.Min(soupInBasket.Amount, breadInBasket.Amount);
            decimal discount = breadInBasket.Product.Price * numberToDiscount * 0.5M;

            return Math.Round(discount, 2);
        }

        /// <summary>
        /// Returns the eligible discount amount for butter based on the contents of the shopping basket.
        /// </summary>
        /// <param name="basket"></param>
        /// <returns></returns>
        internal decimal CalculateButterDiscount(ShoppingBasket basket)
        {
            ShoppingBasketItem butterInBasket = basket.GetItem(ProductType.Butter);
            decimal amountToDiscount = butterInBasket.Product.Price * butterInBasket.Amount * (1M / 3M);

            return Math.Round(amountToDiscount, 2);
        }
    }
}
