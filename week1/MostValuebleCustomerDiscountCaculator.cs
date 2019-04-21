using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week1
{
    public class MostValuebleCustomerDiscountCaculator : IAccountDiscountCaculator
    {
        public decimal ApplyDiscount(decimal price)
        {
            return price - (Constants.DISCOUNT_FOR_MOST_VALUABLE_CUSTOMERS * price);
        }
    }
}
