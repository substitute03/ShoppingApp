namespace Domain
{
    public class Cheese : Product
    {
        public override decimal Price => 0.9M;
        public override ProductType Type => ProductType.Cheese;
    }
}
