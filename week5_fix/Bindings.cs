using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week5
{
     public class Bindings : NinjectModule
    {
        public override void Load()
        {
            Bind<IPasswordValidator>().ToConstant(new PasswordValidator(
                GetPasswordRulesForConsumer1())).WhenInjectedInto<Consumer1>();
            Bind<IPasswordValidator>().ToConstant(new PasswordValidator(
                GetPasswordRulesForConsumer2())).WhenInjectedInto<Consumer2>();

        }
    }
    private List<IPasswordValidationRule> GetPasswordRulesForConsumer1()
    {
        return new List<IPasswordValidationRule>()
        {
            { new PasswordMinLegthRule(8) },
            { new PasswordUsernameRule() },
            { new PasswordHistoryRule() }
        };

    }
    private List<IPasswordValidationRule> GetPasswordRulesForConsumer2()
    {
        return new List<IPasswordValidationRule>()
        {
            { new PasswordMinLegthRule(8) },
            { new PasswordUsernameRule() },
            { new PasswordHistoryRule() },
            { new PasswordBlackListRule(new List<string>()
            {
                "password","qwerty","abc123"
            }) }
        };

    }
}
