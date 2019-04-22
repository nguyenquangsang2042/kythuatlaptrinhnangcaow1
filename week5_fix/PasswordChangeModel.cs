using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week5
{
    public class Password
    {
        public string NewPassword { get; set; }
        public List<string> PasswordHistoryItems { get; set; }
        public string Username { get; set; }
    }
    
    public class PasswordHistoryItem
    {
        public string PasswordText { get; set; }
        public DateTime CreationDate { get; set; }
    }

    public interface IPasswordValidator
    {
        bool IsValid(PasswordChangeModel passwordChangeModel);
    }


    public class PasswordMinLegthRule : IPasswordValidationRule
    {
        private readonly int _minLegth;

        public PasswordMinLegthRule(int minLegth)
        {
            _minLegth = minLegth;
        }

        public bool IsValid(PasswordChangeModel passwordChangeModel)
        {
            return passwordChangeModel.NewPassword.Length >= _minLegth;
        }
    }

    public class PasswordUsernameRule : IPasswordValidationRule
    {
        public bool IsValid(PasswordChangeModel passwordChangeModel)
        {
            return passwordChangeModel.NewPassword != passwordChangeModel.Username;
        }
    }


    public class PasswordHistoryRule : IPasswordValidationRule
    {
        public bool IsValid(PasswordChangeModel passwordChangeModel)
        {
            return passwordChangeModel.PasswordHistoryItems == null ||
                 !passwordChangeModel.PasswordHistoryItems.Any
                 (x => x.PasswordText == passwordChangeModel.NewPassword);
        }
    }

    public class PasswordValidator : IPasswordValidator
    {
        private List<IPasswordValidationRule> _validationRules;

        public PasswordValidator(List<IPasswordValidationRule>
            validationRules)
        {
            _validationRules = validationRules;
        }

        public bool IsValid(PasswordChangeModel passwordChangeModel)
        {
            foreach(var validationRule in _validationRules)
            {
                if(!validationRule.IsValid(passwordChangeModel))
                {
                    return false;
                }
            }
            return true;
        }
    }

    public interface IPasswordValidationRule
    {
        bool IsValid(PasswordChangeModel passwordChangeModel);
    }

   
    public class PasswordManager
    {
        public bool ChangePassword ()
        {
            //var passwordValidator = new PasswordValidator();
           // var isPasswordValid = passwordValidator.IsValid();
           return true;
        }
    }
}

