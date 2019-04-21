using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week1
{
    public class DefaultloyaltyDiscountCalculator : ILoyaltyDiscountCalculator
    {
        public decimal ApplyDiscount(decimal price, int timeOfHavingAccountinYears)
        {
            decimal discountForLoyaltyInPercentage = (timeOfHavingAccountinYears >
                Constants.MAXIMUM_DISCOUNT_FOR_LOYALTY) ?
                (decimal)Constants.MAXIMUM_DISCOUNT_FOR_LOYALTY / 100 : (decimal)timeOfHavingAccountinYears / 100;
            return price - (discountForLoyaltyInPercentage * price);
        }
    }

}
