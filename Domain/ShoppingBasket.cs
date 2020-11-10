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

        public decimal Total => GetTotal();

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
        /// Removed 1 or more of the specified product from the shopping basket. Returns the number of items removed.
        /// </summary>
        /// <param name="product"></param>
        /// <param name="numberToRemove"></param>
        public int RemoveProduct (Product product, int numberToRemove)
        {
            if (numberToRemove < 1)
            {
                return 0;
            }

            ShoppingBasketItem productInBasket = Items.SingleOrDefault(
                i => i.Product.Type == product.Type);

            if (productInBasket == null)
            {
                return 0;
            }

            int amountInBasket = productInBasket.Amount;

            if (amountInBasket <= numberToRemove)
            {
                Items.Remove(productInBasket);
                return amountInBasket;
            }
            else
            {
                productInBasket.Amount -= numberToRemove;
                return numberToRemove;
            }         
        }

        /// <summary>
        /// Gets a ShoppingBasketItem from the ShoppingBasket that matches the supplied ProductType.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public ShoppingBasketItem GetItem(ProductType type)
        {
            return Items.SingleOrDefault(i => i.Product.Type == type);
        }

        private decimal GetTotal()
        {
            ApplySpecialOffers();

            decimal discount = SpecialOffersApplied.Sum(so => so.Discount);

            return SubTotal - discount;
        }

        private void ApplySpecialOffers()
        {
            SpecialOffersApplied.Clear();

            List<SpecialOffer> offersToApply = discountService.GetSpecialOffers(this);

            SpecialOffersApplied.AddRange(offersToApply);
        }
    }
}
