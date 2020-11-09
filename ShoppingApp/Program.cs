using DataAccess;
using Domain;
using System;
using System.Collections.Generic;

namespace ShoppingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var productRepository = new ProductRepository();
            var basket = new ShoppingBasket(new DiscountService());
            List<Product> products = productRepository.GetAll();

            bool quit = false;
            while (!quit)
            {
                Console.WriteLine();
                Console.WriteLine("Please select a product and quantity to add to your basket, or type \"/help\" for a list of options. Type /checkout when you are done shopping.");

                var command = Console.ReadLine().ToUpper().Trim();

                if (command == "/HELP")
                {
                    Console.WriteLine();
                    Console.WriteLine("* To see a list of available products, type \"/products\".");
                    Console.WriteLine("* To add an item to your basket, type \"/add\".");
                    Console.WriteLine("* To remove an item from your basket, type \"/remove\".");
                    Console.WriteLine("* To see the contents of your basket, type \"/basket\".");
                    Console.WriteLine("* Once you have finished shopping, type \"/checkout\" to generate your bill.");
                    Console.WriteLine();
                }
                else if (command == "/BASKET")
                {
                    Console.WriteLine();
                    Console.WriteLine("Your basket:");
                    foreach (var product in basket.Products)
                    {
                        Console.WriteLine($"{product.Type} @ £{ product.Price}");
                    }
                }
                else if (command == "/PRODUCTS")
                {
                    Console.WriteLine();
                    foreach(var product in products)
                    {
                        Console.WriteLine($"{product.Type} @ £{product.Price}");
                    }
                }
                else if (command == "/ADD")
                {
                    Console.WriteLine();
                    Console.WriteLine("Please select the product to add to your basket.");

                    Product productToAdd = null;
                    string product = null;

                    bool isRealProduct = false;
                    while (!isRealProduct)
                    {
                        product = Console.ReadLine().ToUpper().Trim();
                        productToAdd = productRepository.GetByName(product);

                        if (productToAdd == null)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Please select a valid product.");
                        }
                        else
                        {
                            isRealProduct = true;
                        }

                    }

                    Console.WriteLine();
                    Console.WriteLine($"You have selected {product}. Please enter the number that you want to buy.");

                    int quantity = 0;
                    bool isNumber = false;
                    while (!isNumber)
                    {
                        isNumber = Int32.TryParse(Console.ReadLine(), out quantity);
                        if (!isNumber)
                            Console.WriteLine("You have entered an invalid number. Please make sure you enter a positive integer.");
                    }

                    basket.AddProduct(productToAdd, quantity);

                    Console.WriteLine($"Added {quantity} {product}.");
                }
                else if (command == "/REMOVE")
                {
                    Console.WriteLine();
                    Console.WriteLine("Please select the product to remove from your basket.");

                    Product productToRemove = null;
                    string product = null;

                    bool isRealProduct = false;
                    while (!isRealProduct)
                    {
                        product = Console.ReadLine().ToUpper().Trim();
                        productToRemove = productRepository.GetByName(product);

                        if (productToRemove == null)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Please select a valid product.");
                        }
                        else
                        {
                            isRealProduct = true;
                        }

                    }

                    Console.WriteLine();
                    Console.WriteLine($"You have selected {product}. Please enter the number that you want to remove.");

                    int quantity = 0;
                    bool isNumber = false;
                    while (!isNumber)
                    {
                        isNumber = Int32.TryParse(Console.ReadLine(), out quantity);
                        if (!isNumber)
                            Console.WriteLine("You have entered an invalid number. Please make sure you enter a positive integer.");
                    }

                    basket.RemoveProduct(productToRemove, quantity);

                    Console.WriteLine($"Removed {quantity} {product}.");
                }
                else if (command == "/CHECKOUT")
                {
                    var bill = new Bill(basket);

                    Console.WriteLine();
                    Console.WriteLine("Here is your bill.");
                    Console.WriteLine("Special offers applied:");
                    Console.WriteLine();

                    foreach (var offer in bill.SpecialOffers)
                    {
                        Console.WriteLine($"Offer: {offer.ProductType} Discount: {offer.Discount} ");
                    }

                    Console.WriteLine();
                    Console.WriteLine($"Subtotal: {bill.SubTotal}");
                    Console.WriteLine($"Total: {bill.Total}");
                    Console.WriteLine();
                    Console.WriteLine("Thank you.");

                    quit = true;
                }
            }
        }
    }
}
