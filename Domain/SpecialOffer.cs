using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class SpecialOffer
    {
        public ProductType ProductType { get; }
        public string Desciption { get; }
        public decimal Discount { get; }
        public int CountApplied { get; }

        public SpecialOffer(ProductType type, string description, decimal discount, int countApplied)
        {
            ProductType = type;
            Desciption = description;
            Discount = discount;
            CountApplied = countApplied;
        }
    }
}
