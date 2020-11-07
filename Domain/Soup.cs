namespace Domain
{
    public class Soup : Product
    {
        public override decimal Price => 0.6M;
        public override ProductType Type => ProductType.Soup;
    }
}
