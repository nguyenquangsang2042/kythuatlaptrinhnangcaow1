using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week1
{
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

}
