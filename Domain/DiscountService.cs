using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain
{
    public class DiscountService
    {
        /// <summary>
        /// Returns a list of Special Offers that the supplied basket is eligible for.
        /// </summary>
        /// <param name="basket"></param>
        /// <returns></returns>
        public List<SpecialOffer> GetSpecialOffers(ShoppingBasket basket)
        {
            var offers = new List<SpecialOffer>();

            if (basket.Items.Any(p => p.Product.Type == ProductType.Cheese))
            {
                offers.Add(CalculateCheeseDiscount(basket));
            }

            if (basket.Items.Any(p => p.Product.Type == ProductType.Soup) &&
                basket.Items.Any(p => p.Product.Type == ProductType.Bread))
            {
                offers.Add(CalculateBreadDiscount(basket));
            }

            if (basket.Items.Any(p => p.Product.Type == ProductType.Butter))
            {
                offers.Add(CalculateButterDiscount(basket));
            }

            return offers;
        }

        private SpecialOffer CalculateCheeseDiscount(ShoppingBasket basket)
        {
            ShoppingBasketItem item = basket.GetItem(ProductType.Cheese);
            int numberToDiscount = item.Amount / 2;
            decimal discount = Math.Round(item.Product.Price * numberToDiscount, 2);

            return new SpecialOffer(ProductType.Cheese, "Buy one cheese, get one free", discount, numberToDiscount);

        }

        private SpecialOffer CalculateBreadDiscount(ShoppingBasket basket)
        {
            ShoppingBasketItem soupInBasket = basket.GetItem(ProductType.Soup);
            ShoppingBasketItem breadInBasket = basket.GetItem(ProductType.Bread);
            int numberToDiscount = Math.Min(soupInBasket.Amount, breadInBasket.Amount);
            decimal discount = Math.Round(breadInBasket.Product.Price * numberToDiscount * 0.5M, 2);

            return new SpecialOffer(ProductType.Bread, "Buy a soup, get a half price bread", discount, numberToDiscount);
        }

        private SpecialOffer CalculateButterDiscount(ShoppingBasket basket)
        {
            ShoppingBasketItem butterInBasket = basket.GetItem(ProductType.Butter);
            int numberToDiscount = butterInBasket.Amount;
            decimal discount = Math.Round(butterInBasket.Product.Price * numberToDiscount * (1M / 3M), 2);

            return new SpecialOffer(ProductType.Butter, "One third off butter", discount, numberToDiscount);
        }
    }
}
