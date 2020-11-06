using Domain;
using System;

namespace ShoppingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var cart = new ShoppingCart();

            cart.AddProduct(new Cheese(), 2);
            cart.AddProduct(new Bread(), 2);
            cart.AddProduct(new Soup(), 2);
            cart.AddProduct(new Butter(), 3);

            cart.RemoveProduct(new Soup(), 2);

            var subTotal = cart.SubTotal;
            var total = cart.Total;
        }
    }
}
