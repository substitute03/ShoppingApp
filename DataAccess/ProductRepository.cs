using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess
{
    public class ProductRepository
    {
        public List<Product> GetAll()
        {
            return Products;
        }

        public Product GetByType(ProductType type)
        {
            return Products.Single(p => p.Type == type);
        }

        public Product GetByName(string name)
        {
            name = name.ToUpper().Trim();

            return Products.SingleOrDefault(p => p.Type.ToString().ToUpper() == name);
        }

        private List<Product> Products => new List<Product>
        {
            new Product(1.1M, ProductType.Bread),
            new Product(1.2M, ProductType.Butter),
            new Product(0.6M, ProductType.Soup),
            new Product(0.9M, ProductType.Cheese),
            new Product(0.5M, ProductType.Milk)
        };
    }
}
