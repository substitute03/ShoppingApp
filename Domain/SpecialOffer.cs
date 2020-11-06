using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Domain
{
    public abstract class SpecialOffer
    {
        public abstract bool AppliesTo(ShoppingCart cart);
        public abstract int NumberToApply(ShoppingCart cart);
    }

    public class BuyOneGetFree : SpecialOffer
    {
        public BuyOneGetFree(int buyThisNumber, ProductType buyThisProduct,
            int getThisNumber)
        {
            BuyThisNumber = buyThisNumber;
            BuyThisProduct = buyThisProduct;
            GetThisNumber = getThisNumber;
        }

        public ProductType BuyThisProduct { get; }
        public int BuyThisNumber { get; }
        public int GetThisNumber { get; }

        public override bool AppliesTo(ShoppingCart cart)
        {
            return cart.Products.Count(p => p.Name == BuyThisProduct) > 0;
        }

        public override int NumberToApply(ShoppingCart cart)
        {
            if (AppliesTo(cart))
            {

            }
            throw new NotImplementedException();
        }
    }

    public enum OfferType
    {
        BuyOneGetOneFree
    }

}
