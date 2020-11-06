using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain
{
    public class ShoppingCart
    {
        private readonly List<Product> _products;
        public List<Product> Products => _products;

        public decimal SubTotal { get; private set; }

        public decimal Total => _products.Sum(p => p.Price);

        public void AddProduct(Product product, int numberToAdd)
        {
            if (numberToAdd == 0)
                return;

            for (int i = 1; i <= numberToAdd; i++)
            {
                _products.Add(product);
            }

            CalculateSubTotal();
        }

        public void RemoveProduct (Product product, int numberToRemove)
        {
            if (numberToRemove == 0)
                return;

            for (int i = 1; i <= numberToRemove; i++)
            {
                _products.Remove(product);
            }

            CalculateSubTotal();
        }

        private void CalculateSubTotal()
        {

        }
    }
}
