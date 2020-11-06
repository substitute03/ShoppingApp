using System;
using System.Collections.Generic;
using System.Security;
using System.Text;

namespace Domain
{
    public abstract class Product
    {
        public ProductType Name { get; set; }
        public decimal Price { get; set; }
    }

    public enum ProductType
    {
        Bread,
        Milk,
        Cheese,
        Soup,
        Butter
    }
}
