namespace Domain
{
    public abstract class Product
    {
        public abstract decimal Price { get; }
        public abstract ProductType Type { get; }
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
