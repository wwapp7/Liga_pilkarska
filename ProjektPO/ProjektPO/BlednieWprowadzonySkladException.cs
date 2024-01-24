using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektPO
{
    public class BlednieWprowadzonySkladException : Exception
    {
        public BlednieWprowadzonySkladException(string message) : base(message)
        { }
    }
}
