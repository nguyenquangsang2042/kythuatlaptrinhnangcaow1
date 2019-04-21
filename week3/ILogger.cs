using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week3
{
    public interface ILogger
    {
        void Error(string v);
        void Exception(string v);
        void Infor(string v);
    }

}
