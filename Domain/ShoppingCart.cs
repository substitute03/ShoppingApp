using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain
{
    public class ShoppingCart
    {
        public List<Product> Products { get; }

        public decimal SubTotal => ApplySpecialOffers(Total);

        public decimal Total => Products.Sum(p => p.Price);

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
                Products.Remove(product);
            }
        }

        private decimal ApplySpecialOffers(decimal total)
        {
            decimal totalDiscount = 0M;

            if(Products.OfType<Cheese>().Any())
            {
                totalDiscount = totalDiscount + DiscountService
                    .CalculateCheeseDiscount(this);
            }

            if (Products.OfType<Soup>().Any())
            {
                totalDiscount = totalDiscount + DiscountService
                    .CalculateSoupDiscount(this);
            }

            if (Products.OfType<Butter>().Any())
            {
                totalDiscount = totalDiscount + DiscountService
                    .CalculateButterDiscount(this);
            }

            return Total - totalDiscount;
        }
    }
}
