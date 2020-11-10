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

        public List<ShoppingBasketItem> Items { get; } = new List<ShoppingBasketItem>();

        public decimal Total => ApplySpecialOffers();

        public decimal SubTotal => Items.Sum(i => i.Product.Price * i.Amount);

        public List<SpecialOffer> SpecialOffersApplied { get; } = new List<SpecialOffer>();

        /// <summary>
        /// Adds 1 of more of the specified product to the shopping basket.
        /// </summary>
        /// <param name="product"></param>
        /// <param name="numberToAdd"></param>
        public void AddProduct(Product product, int numberToAdd)
        {
            if (numberToAdd < 1)
            {
                return;
            }            

            ShoppingBasketItem productInBasket = Items.SingleOrDefault(
                i => i.Product.Type == product.Type);

            if (productInBasket == null)
            {
                Items.Add(new ShoppingBasketItem(product, numberToAdd));
            }
            else
            {
                productInBasket.Amount += numberToAdd;
            }
        }

        /// <summary>
        /// Removed 1 or more of the specified product from the shopping basket.
        /// </summary>
        /// <param name="product"></param>
        /// <param name="numberToRemove"></param>
        public void RemoveProduct (Product product, int numberToRemove)
        {
            if (numberToRemove < 1)
            {
                return;
            }

            ShoppingBasketItem productInBasket = Items.SingleOrDefault(
                i => i.Product.Type == product.Type);

            if (productInBasket == null)
            {
                return;
            }

            if (productInBasket.Amount <= numberToRemove)
            {
                Items.Remove(productInBasket);
            }
            else
            {
                productInBasket.Amount -= numberToRemove;
            }         
        }

        public ShoppingBasketItem GetItem(ProductType type)
        {
            return Items.SingleOrDefault(i => i.Product.Type == type);
        }

        private decimal ApplySpecialOffers()
        {
            decimal totalDiscount = 0M;
            SpecialOffersApplied.Clear();

            if(Items.Any(p => p.Product.Type == ProductType.Cheese))
            {
                decimal discount = discountService.CalculateCheeseDiscount(this);
                totalDiscount = totalDiscount + discount;

                SpecialOffersApplied.Add(new SpecialOffer
                {
                    ProductType = ProductType.Cheese,
                    Discount = discount
                });
            }

            if (Items.Any(p => p.Product.Type == ProductType.Soup) &&
                Items.Any(p => p.Product.Type == ProductType.Bread))
            {
                decimal discount = discountService.CalculateBreadDiscount(this);
                totalDiscount = totalDiscount + discount;

                SpecialOffersApplied.Add(new SpecialOffer
                {
                    ProductType = ProductType.Bread,
                    Discount = discount
                });
            }

            if (Items.Any(p => p.Product.Type == ProductType.Butter))
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
