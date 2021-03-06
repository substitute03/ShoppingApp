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

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Welcome To The Shop!");
            Console.WriteLine("---------------------");
            bool quit = false;
            while (!quit)
            {
            Start:
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Type a command or type \"/help\" for a list of available commands.");
                Console.ForegroundColor = ConsoleColor.White;

                var command = Console.ReadLine().ToUpper().Trim();

                if (command == "/HELP")
                {
                    Console.WriteLine();
                    Console.WriteLine("* To see a list of available products, type \"/products\".");
                    Console.WriteLine("* To add an item to your basket, type \"/add\".");
                    Console.WriteLine("* To remove an item from your basket, type \"/remove\".");
                    Console.WriteLine("* To cancel a transaction, type \"/cancel\".");
                    Console.WriteLine("* To see the contents of your basket, type \"/basket\".");
                    Console.WriteLine("* Once you have finished shopping, type \"/checkout\" to generate your bill.");
                }
                else if (command == "/BASKET")
                {
                    if (basket.Items.Count == 0)
                    {
                        Console.WriteLine("Your basket is empty. Go and add some items!");
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("Your Basket:");
                        Console.WriteLine("------------------------------------");
                        Console.WriteLine($"Subtotal: £{basket.SubTotal}");
                        Console.WriteLine();
                        foreach (var item in basket.Items)
                        {
                            Console.WriteLine($"{item.Amount} x {item.Product.Type} @ £{item.Product.Price}");
                        }
                        Console.WriteLine("------------------------------------");
                    }
                }
                else if (command == "/PRODUCTS")
                {
                    Console.WriteLine();
                    Console.WriteLine("Here are the products that we sell.");
                    Console.WriteLine("------------------------------------");
                    foreach(var product in products)
                    {
                        Console.WriteLine($"{product.Type} @ £{product.Price}");
                    }
                    Console.WriteLine("------------------------------------");
                }
                else if (command == "/ADD")
                {
                    Console.WriteLine();
                    Console.WriteLine("Please select the product to add to your basket or type /cancel to cancel the transaction.");

                    Product productToAdd = null;
                    string productOrCancel = null;

                    bool isRealProduct = false;
                    while (!isRealProduct)
                    {
                        productOrCancel = Console.ReadLine().ToUpper().Trim();

                        if (productOrCancel.ToUpper().Trim() == "/CANCEL")
                            goto Start;

                        productToAdd = productRepository.GetByName(productOrCancel);

                        if (productToAdd == null)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Please select a valid product.");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        else
                        {
                            isRealProduct = true;
                        }
                    }

                    Console.WriteLine();
                    Console.WriteLine($"You have selected {productOrCancel}. Please enter the number that you want to buy or type /cancel to cancel the transaction.");

                    int quantity = 0;
                    bool isNumber = false;
                    while (!isNumber)
                    {
                        string numberOrCancel = Console.ReadLine();

                        if (numberOrCancel.ToUpper().Trim() == "/CANCEL")
                            goto Start;

                        isNumber = Int32.TryParse(numberOrCancel, out quantity);
                        if (!isNumber)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("You have entered an invalid number. Please make sure you enter a positive integer.");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                    }

                    basket.AddProduct(productToAdd, quantity);

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Added {quantity} {productOrCancel}.");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (command == "/REMOVE")
                {
                    Console.WriteLine();
                    Console.WriteLine("Please select the product to remove from your basket or type /cancel to cancel the transaction.");

                    Product productToRemove = null;
                    string productOrCancel = null;

                    bool isRealProduct = false;
                    while (!isRealProduct)
                    {
                        productOrCancel = Console.ReadLine().ToUpper().Trim();

                        if (productOrCancel.ToUpper().Trim() == "/CANCEL")
                            goto Start;

                        productToRemove = productRepository.GetByName(productOrCancel);

                        if (productToRemove == null)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Please select a valid product.");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        else
                        {
                            isRealProduct = true;
                        }
                    }

                    Console.WriteLine();
                    Console.WriteLine($"You have selected {productOrCancel}. Please enter the number that you want to remove or type /cancel to cancel the transaction.");

                    int quantity = 0;
                    bool isNumber = false;
                    while (!isNumber)
                    {
                        string numberOrCancel = Console.ReadLine();

                        if (numberOrCancel.ToUpper().Trim() == "/CANCEL")
                            goto Start;

                        isNumber = Int32.TryParse(numberOrCancel, out quantity);
                        if (!isNumber)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("You have entered an invalid number. Please make sure you enter a positive integer.");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                    }

                    int countRemoved = basket.RemoveProduct(productToRemove, quantity);

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Removed {countRemoved} {productOrCancel}.");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (command == "/CHECKOUT")
                {
                    var bill = new Bill(basket);

                    Console.WriteLine();
                    Console.WriteLine("Customer Bill");
                    Console.WriteLine("------------------------------------");
                    Console.WriteLine("Special offers applied:");
                    Console.WriteLine();
                    foreach (var offer in bill.SpecialOffers)
                    {
                        Console.WriteLine($"* {offer.Desciption} x {offer.CountApplied} (-£{offer.Discount})");
                    }
                    Console.WriteLine();
                    Console.WriteLine($"Subtotal: £{bill.SubTotal}");
                    Console.WriteLine($"Savings: -£{bill.SubTotal - bill.Total}");
                    Console.WriteLine($"Total: £{bill.Total}");
                    Console.WriteLine("------------------------------------");
                    Console.WriteLine();
                    Console.WriteLine("Thank you.");
                    Console.WriteLine("Press any key to quit.");
                    var end = Console.ReadKey();

                    quit = true;
                }
            }
        }
    }
}
