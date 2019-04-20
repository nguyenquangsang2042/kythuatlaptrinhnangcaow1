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
    public enum AccountStatus
    {
        NotRegistered = 1,
        SimpleCustomer = 2,
        ValuableCustomer = 3,
        MostValuableCustomer = 4
    }
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
    public interface IAccountDiscountCaculatorFactory
    {
        IAccountDiscountCaculator GetAccountDiscountCaculator(AccountStatus accountStatus);
    }
    public interface ILoyaltyDiscountCalculator
    {
        decimal ApplyDiscount(decimal price, int timeOfHavingAccountInYears);
    }
    public class DefaultloyaltyDiscountCalculator: ILoyaltyDiscountCalculator
    {
        public decimal ApplyDiscount(decimal price, int timeOfHavingAccountinYears)
        {
            decimal discountForLoyaltyInPercentage = (timeOfHavingAccountinYears >
                Constants.MAXIMUM_DISCOUNT_FOR_LOYALTY) ?
                (decimal)Constants.MAXIMUM_DISCOUNT_FOR_LOYALTY / 100 : (decimal)timeOfHavingAccountinYears / 100;
            return price - (discountForLoyaltyInPercentage * price);
        }
    }
    public class DefaultAccountDiscountCaculatorFactory : IAccountDiscountCaculatorFactory
    {
        public IAccountDiscountCaculatorFactory GetAccountDiscountCaculator(AccountStatus accountStatus)
        {
            IAccountDiscountCaculator caculator;
            switch (accountStatus)
            {
                case AccountStatus.NotRegistered:
                    caculator = new NotRegisteredDiscountCaculator();
                    break;
                case AccountStatus.SimpleCustomer:
                    caculator = new SimpleCustomerDiscountCaculator();
                    break;
                case AccountStatus.ValuableCustomer:
                    caculator = new ValuebleCustomerDiscountCaculator();
                    break;
                case AccountStatus.MostValuableCustomer:
                    caculator = new MostValuebleCustomerDiscountCaculator();
                    break;
                default:
                    throw new NotImplementedException();
                   
            }
            return (IAccountDiscountCaculatorFactory)caculator;
         
        }

        IAccountDiscountCaculator IAccountDiscountCaculatorFactory.GetAccountDiscountCaculator(AccountStatus accountStatus)
        {
            throw new NotImplementedException();
        }
    }
    public interface IAccountDiscountCaculator
    {
        decimal ApplyDiscount(decimal price);
    }
    public class NotRegisteredDiscountCaculator: IAccountDiscountCaculator
    {
       public decimal ApplyDiscount(decimal price)
        {
            return price;
        }
    }
    public class SimpleCustomerDiscountCaculator : IAccountDiscountCaculator
    {   
        public decimal ApplyDiscount(decimal price)
        {
            return price - (Constants.DISCOUNT_FOR_SIMPLE_CUSTOMERS * price);
        }
    }
    public class ValuebleCustomerDiscountCaculator : IAccountDiscountCaculator
    {
        public decimal ApplyDiscount(decimal price)
        {
            return price - (Constants.DISCOUNT_FOR_VALUABLE_CUSTOMERS * price);
        }
    }
    public class MostValuebleCustomerDiscountCaculator : IAccountDiscountCaculator
    {
        public decimal ApplyDiscount(decimal price)
        {
            return price - (Constants.DISCOUNT_FOR_MOST_VALUABLE_CUSTOMERS * price);
        }
    }
}


    
