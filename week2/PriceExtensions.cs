using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week1
{
    public static class PriceExtensions
    {
        public static decimal ApplyDiscountForAccountStatus(this decimal price, decimal discountSize)
        {
            return price - (discountSize * price);
        }
        public static decimal ApplyDiscountForTimeOfHavingAccount(this decimal price, int timeOfHavingAccountinYears)
        {
            decimal discountForLoyaltyInPercentage = (timeOfHavingAccountinYears > Constants.MAXIMUM_DISCOUNT_FOR_LOYALTY) ?
                (decimal)Constants.MAXIMUM_DISCOUNT_FOR_LOYALTY / 100 : (decimal)timeOfHavingAccountinYears / 100;
            return price - (discountForLoyaltyInPercentage * price);
        }
    }
}
