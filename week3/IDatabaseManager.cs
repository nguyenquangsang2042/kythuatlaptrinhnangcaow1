using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week3
{
    public interface IDatabaseManager
    {
        EmailData GetEmailData(int emailId);
    }
}
