using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week4
{
    
    public class UserServise 
    {
        private readonly IMessagingService _messagingService;
        private readonly ILogger _logger;

        public UserServise(IMessagingService messagingService, ILogger logger)
        {
            _messagingService = messagingService;
            _logger = logger;
        }

        public bool RegisterUser(String login, string password)
        {
            try
            {
                _messagingService.SendRegistrationEmailMessage(message);
            }
            catch(Exception ex)
            {
                _logger.Error(string.Format("Exception occurred while sending an activation emailto a user with login: { 0}, " +
                    "email: { 1}",login, emailAddress), ex.ToString());
            }
            return true;
        }
    }
    
}
