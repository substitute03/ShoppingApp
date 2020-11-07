using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Text;

namespace Domain
{
    public class Bill
    {
        public decimal SubTotal { get; }
        public decimal Total { get; }
        public List<SpecialOffer> SpecialOffers { get; }

        public Bill(ShoppingBasket basket)
        {
            SubTotal = basket.SubTotal;
            Total = basket.Total;
            SpecialOffers = basket.SpecialOffersApplied;
        }
    }
}
