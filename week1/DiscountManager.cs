using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace week1
{
    
    class DiscountManager
    {  
        private readonly IAccountDiscountCaculatorFactory _factory;
        private readonly ILoyaltyDiscountCalculator _loyaltyDiscountCalculator;
        
        public DiscountManager(IAccountDiscountCaculatorFactory factory, ILoyaltyDiscountCalculator loyaltyDiscountCalculator)
        {
            _factory = factory;
            _loyaltyDiscountCalculator = loyaltyDiscountCalculator;
        }
        public decimal ApplyDiscount(decimal price, AccountStatus accountStatus, int timeOfHavingAccountInYears)
        {
            decimal priceAfterDiscount = 0;
            decimal discountForLoyaltyInPercentage = (timeOfHavingAccountInYears > Constants.MAXIMUM_DISCOUNT_FOR_LOYALTY) ?
                (decimal)Constants.MAXIMUM_DISCOUNT_FOR_LOYALTY / 100 : (decimal)timeOfHavingAccountInYears / 100;
            switch (accountStatus)
            {
                case AccountStatus.NotRegistered:
                    {
                        priceAfterDiscount = price;
                        break;
                    }
                case AccountStatus.SimpleCustomer:
                    {
                        priceAfterDiscount = price.ApplyDiscountForAccountStatus(Constants.DISCOUNT_FOR_SIMPLE_CUSTOMERS)
                            ;
                        break;
                    }
                case AccountStatus.ValuableCustomer:
                    {
                        priceAfterDiscount = price.ApplyDiscountForAccountStatus(Constants.DISCOUNT_FOR_VALUABLE_CUSTOMERS)
                           ;
                        break;
                    }
                case AccountStatus.MostValuableCustomer:
                    {
                        priceAfterDiscount = price.ApplyDiscountForAccountStatus(Constants.DISCOUNT_FOR_MOST_VALUABLE_CUSTOMERS)
                         ;
                        break;
                    }
                default:
                    throw new NotImplementedException();
            }
            priceAfterDiscount = priceAfterDiscount.ApplyDiscountForTimeOfHavingAccount(timeOfHavingAccountInYears);
            return priceAfterDiscount;
        }
    }
}


    
