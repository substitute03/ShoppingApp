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

        public decimal Total => ApplySpecialOffers(SubTotal);

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
        /// <param name="product"></param>
        /// <param name="numberToRemove"></param>
        public void RemoveProduct (Product product, int numberToRemove)
        {
            if (numberToRemove == 0)
                return;

            for (int i = 1; i <= numberToRemove; i++)
            {
                foreach(Product item in Products)
                {
                    if (item.GetType() == product.GetType())
                    {
                        Products.Remove(item);
                        break;
                    }
                }
            }
        }

        private decimal ApplySpecialOffers(decimal total)
        {
            decimal totalDiscount = 0M;
            SpecialOffersApplied.Clear();

            if(Products.OfType<Cheese>().Any()) // might be clearer to use producttype enum
            {
                decimal discount = discountService.CalculateCheeseDiscount(this);
                totalDiscount = totalDiscount + discount;

                SpecialOffersApplied.Add(new SpecialOffer
                {
                    ProductType = ProductType.Cheese,
                    Discount = discount
                });
            }

            if (Products.OfType<Soup>().Any())
            {
                decimal discount = discountService.CalculateBreadDiscount(this);
                totalDiscount = totalDiscount + discount;

                SpecialOffersApplied.Add(new SpecialOffer
                {
                    ProductType = ProductType.Bread,
                    Discount = discount
                });
            }

            if (Products.OfType<Butter>().Any())
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
