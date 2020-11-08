using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public interface IDiscountService
    {
        decimal CalculateCheeseDiscount(ShoppingBasket basket);
        decimal CalculateBreadDiscount(ShoppingBasket basket);
        decimal CalculateButterDiscount(ShoppingBasket basket);
    }
}
