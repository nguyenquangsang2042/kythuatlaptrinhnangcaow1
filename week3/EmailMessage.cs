using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week3
{
    public class EmailMessage
    {
        public string Form { get; internal set; }
        public string To { get; internal set; }
        public string Subject { get; internal set; }
        public string Body { get; internal set; }
    }
}
