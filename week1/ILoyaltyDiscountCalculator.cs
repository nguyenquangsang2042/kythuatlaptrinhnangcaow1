using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week1
{
    public interface ILoyaltyDiscountCalculator
    {
        decimal ApplyDiscount(decimal price, int timeOfHavingAccountInYears);
    }
}
