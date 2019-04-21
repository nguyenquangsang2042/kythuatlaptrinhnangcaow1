using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week4
{
    interface IMessagingService
    {
        void SendRegistrationEmailMessage(object message);
    }
}
