﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektPO
{
    public class ZawodnikaNieByloNaBoiskuException : Exception
    {
        public ZawodnikaNieByloNaBoiskuException(string message) : base(message)
        { }
    }
}
