using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;

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
                Console.WriteLine("Please select a product and quantity to add to your basket, or type \"/help\" for a list of options. Type /checkout when you are done shopping.");

                var command = Console.ReadLine().ToUpper().Trim();

                if (command == "/HELP")
                {
                    Console.WriteLine();
                    Console.WriteLine("* To see a list of available products, type \"/products\".");
                    Console.WriteLine("* To add an item to your basket, type \"/add\". When you have added an item to your basket, type \"/confirm\" to confirm.");
                    Console.WriteLine("* Once you have finished shopping, type \"/checkout\" to generate your bill.");
                    Console.WriteLine();
                }
                else if (command == "/PRODUCTS")
                {
                    Console.WriteLine();
                    foreach(var product in products)
                    {
                        Console.WriteLine(product.GetType().Name);
                    }
                    Console.WriteLine();
                }
                else if (command.Substring(0, 4) == "/ADD")
                {
                    Console.WriteLine("Please select the product to add to your basket.");

                    Product productToAdd = null;
                    string product = null;
                    bool isRealProduct = false;
                    while (!isRealProduct)
                    {
                        product = Console.ReadLine().ToUpper().Trim();
                        switch (product)
                        {
                            case "BREAD":
                                productToAdd = productRepository.GetByType(ProductType.Bread);
                                isRealProduct = true;
                                break;
                            case "CHEESE":
                                productToAdd = productRepository.GetByType(ProductType.Cheese);
                                isRealProduct = true;
                                break;
                            case "SOUP":
                                productToAdd = productRepository.GetByType(ProductType.Soup);
                                isRealProduct = true;
                                break;
                            case "MILK":
                                productToAdd = productRepository.GetByType(ProductType.Milk);
                                isRealProduct = true;
                                break;
                            case "BUTTER":
                                productToAdd = productRepository.GetByType(ProductType.Butter);
                                isRealProduct = true;
                                break;
                            default:
                                Console.WriteLine("Please select a valid product.");
                                break;
                        }
                    }

                    Console.WriteLine($"You have selected {product}. Please enter the number that you want to buy.");

                    int quantity = 0;
                    bool isNumber = false;
                    while (!isNumber)
                    {
                        isNumber = Int32.TryParse(Console.ReadLine(), out quantity);
                        if (!isNumber)
                            Console.WriteLine("You have entered an invalid number. Please make sure you enter a positive integer.");
                    }

                    bool isConfirmed = false;
                    while (!isConfirmed)
                    {
                        Console.WriteLine($"You have selected {quantity} {product}. To confirm, please type /confirm");
                        if (Console.ReadLine().ToUpper().Trim() == "/CONFIRM")
                            isConfirmed = true;
                    }

                    basket.AddProduct(productToAdd, quantity);
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
