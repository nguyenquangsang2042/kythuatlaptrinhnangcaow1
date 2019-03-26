using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week1
{
    class DiscountManager
    {
        public decimal ApplyDiscount(decimal price, AccountStatus accountStatus, int timeOfHavingAccountInYears)
        { 
            decimal priceAfterDiscount = 0;
            decimal discountForLoyaltyInPercentage = (timeOfHavingAccountInYears > Constants.MAXIMUM_DISCOUNT_FOR_LOYALTY) ?
                (decimal)Constants.MAXIMUM_DISCOUNT_FOR_LOYALTY / 100 : (decimal)timeOfHavingAccountInYears / 100; 
            switch(accountStatus){
                case AccountStatus.NotRegistered:
            { 
                priceAfterDiscount = price;
                break;
            } 
                case AccountStatus.SimpleCustomer:
                {
                    priceAfterDiscount = (price - (Constants.DISCOUNT_FOR_SIMPLE_CUSTOMERS * price));
                    priceAfterDiscount = priceAfterDiscount - (discountForLoyaltyInPercentage * priceAfterDiscount);
                    break;
                }
                case AccountStatus.ValuableCustomer:
                    {
                        priceAfterDiscount = (price-(Constants.DISCOUNT_FOR_VALUABLE_CUSTOMERS * price));
                        priceAfterDiscount = priceAfterDiscount - (discountForLoyaltyInPercentage * priceAfterDiscount);
                        break;
                    } 
                case AccountStatus.MostValuableCustomer:
                        {
                            priceAfterDiscount = (price - (Constants.DISCOUNT_FOR_MOST_VALUABLE_CUSTOMERS * price));
                            priceAfterDiscount = priceAfterDiscount - (discountForLoyaltyInPercentage * priceAfterDiscount);
                            break;
                        } 
                default:
                    throw new NotImplementedException();
        }
        
            return priceAfterDiscount;
        
        }
        public enum AccountStatus
        {
            NotRegistered=1,
            SimpleCustomer=2,
            ValuableCustomer=3,
            MostValuableCustomer=4
        }
        //den buoc 16

    }

}
