using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class ProductRepository
    {
        public List<Product> GetAll()
        {
            List <Product> products = new List<Product>();

            products.AddRange(new List<Product>
            {
                new Product { Name = ProductType.Bread, Price = 1.1M },
                new Product { Name = ProductType.Milk, Price = 0.5M },
                new Product { Name = ProductType.Cheese, Price = 0.9M },
                new Product { Name = ProductType.Soup, Price = 0.6M },
                new Product { Name = ProductType.Butter, Price = 1.2M }
            });

            return products;
        }
    }
}
