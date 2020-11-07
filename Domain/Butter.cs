namespace Domain
{
    public class Butter : Product
    {
        public override decimal Price => 1.2M;
        public override ProductType Type => ProductType.Butter;
    }
}
