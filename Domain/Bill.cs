using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Text;

namespace Domain
{
    public class Bill
    {
        decimal SubTotal { get; }
        decimal Total { get; }
        List<SpecialOffer> SpecialOffers { get; }

        public Bill(ShoppingCart cart)
        {
            SubTotal = cart.SubTotal;
            Total = cart.Total;
            SpecialOffers = cart.SpecialOffersApplied;
        }
    }
}
