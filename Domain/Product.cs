namespace Domain
{
    public class Product
    {
        public Product(decimal price, ProductType type)
        {
            Price = price;
            Type = type;
        }

        public decimal Price { get; private set; }
        public ProductType Type { get; private set; }
    }

    public enum ProductType
    {
        Bread,
        Cheese,
        Milk,
        Soup,
        Butter
    }
}