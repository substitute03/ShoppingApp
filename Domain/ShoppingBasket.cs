using System.Collections.Generic;
using System.Linq;

namespace Domain
{
    public class ShoppingBasket
    {
        public List<Product> Products { get; } = new List<Product>();

        public decimal Total => ApplySpecialOffers(SubTotal);

        public decimal SubTotal => Products.Sum(p => p.Price);

        public List<SpecialOffer> SpecialOffersApplied { get; } = new List<SpecialOffer>();

        public void AddProduct(Product product, int numberToAdd)
        {
            if (numberToAdd == 0)
                return;

            for (int i = 1; i <= numberToAdd; i++)
            {
                Products.Add(product);
            }
        }

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

            if(Products.OfType<Cheese>().Any())
            {
                decimal discount = DiscountService.CalculateCheeseDiscount(this);
                totalDiscount = totalDiscount + discount;

                SpecialOffersApplied.Add(new SpecialOffer
                {
                    Name = nameof(Cheese),
                    Discount = discount
                });
            }

            if (Products.OfType<Soup>().Any())
            {
                decimal discount = DiscountService.CalculateBreadDiscount(this);
                totalDiscount = totalDiscount + discount;

                SpecialOffersApplied.Add(new SpecialOffer
                {
                    Name = nameof(Bread),
                    Discount = discount
                });
            }

            if (Products.OfType<Butter>().Any())
            {
                decimal discount = DiscountService.CalculateButterDiscount(this);
                totalDiscount = totalDiscount + discount;

                SpecialOffersApplied.Add(new SpecialOffer
                {
                    Name = nameof(Butter),
                    Discount = discount

                });
            }

            return SubTotal - totalDiscount;
        }
    }
}
