namespace Domain
{
    public class Bread : Product
    {
        public override decimal Price => 1.1M;
        public override ProductType Type => ProductType.Bread;
    }
}
