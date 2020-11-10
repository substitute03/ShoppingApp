using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class ShoppingBasketItem
    {
        public Product Product { get; set; }
        public int Amount { get; set; }

        public ShoppingBasketItem(Product product, int amount)
        {
            Product = product;
            Amount = amount;
        }
    }
}
