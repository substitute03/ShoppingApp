using System.Collections.Generic;
using System.Linq;

namespace Domain
{
    public class ShoppingBasket
    {
        DiscountService discountService;

        public ShoppingBasket(DiscountService discountService)
        {
            this.discountService = discountService;
        }

        public List<Product> Products { get; } = new List<Product>();

        public decimal Total => ApplySpecialOffers();

        public decimal SubTotal => Products.Sum(p => p.Price);

        public List<SpecialOffer> SpecialOffersApplied { get; } = new List<SpecialOffer>();

        /// <summary>
        /// Adds 1 of more of the specified product to the shopping basket.
        /// </summary>
        /// <param name="product"></param>
        /// <param name="numberToAdd"></param>
        public void AddProduct(Product product, int numberToAdd)
        {
            if (numberToAdd == 0)
                return;

            for (int i = 1; i <= numberToAdd; i++)
            {
                Products.Add(product);
            }
        }

        /// <summary>
        /// Removed 1 or more of the specified product from the shopping basket.
        /// </summary>
        /// <param name="productToRemove"></param>
        /// <param name="numberToRemove"></param>
        public void RemoveProduct (Product productToRemove, int numberToRemove)
        {
            if (numberToRemove == 0)
                return;

            for (int i = 1; i <= numberToRemove; i++)
            {
                foreach (Product item in Products)
                {
                    if (item.Type == productToRemove.Type)
                    {
                        Products.Remove(item);
                        break;
                    }
                }
            }
        }

        private decimal ApplySpecialOffers()
        {
            decimal totalDiscount = 0M;
            SpecialOffersApplied.Clear();

            if(Products.Any(p => p.Type == ProductType.Cheese))
            {
                decimal discount = discountService.CalculateCheeseDiscount(this);
                totalDiscount = totalDiscount + discount;

                SpecialOffersApplied.Add(new SpecialOffer
                {
                    ProductType = ProductType.Cheese,
                    Discount = discount
                });
            }

            if (Products.Any(p => p.Type == ProductType.Soup) &&
                Products.Any(p => p.Type == ProductType.Bread))
            {
                decimal discount = discountService.CalculateBreadDiscount(this);
                totalDiscount = totalDiscount + discount;

                SpecialOffersApplied.Add(new SpecialOffer
                {
                    ProductType = ProductType.Bread,
                    Discount = discount
                });
            }

            if (Products.Any(p => p.Type == ProductType.Butter))
            {
                decimal discount = discountService.CalculateButterDiscount(this);
                totalDiscount = totalDiscount + discount;

                SpecialOffersApplied.Add(new SpecialOffer
                {
                    ProductType = ProductType.Butter,
                    Discount = discount

                });
            }

            return SubTotal - totalDiscount;
        }
    }
}
