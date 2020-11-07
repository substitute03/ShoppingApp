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
            List<Product> products = new List<Product>();

            products.AddRange(new List<Product>
            {
                new Bread(),
                new Butter(),
                new Soup(),
                new Cheese(),
                new Milk()
            }); ;

            return products;
        }
    }
}
