﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week1
{
    public interface IAccountDiscountCaculator
    {
        decimal ApplyDiscount(decimal price);
    }

}
