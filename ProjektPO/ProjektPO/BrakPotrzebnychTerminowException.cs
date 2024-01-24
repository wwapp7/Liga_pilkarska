using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektPO
{
    public class BrakPotrzebnychTerminowException : Exception
    {
        public BrakPotrzebnychTerminowException(string message) : base(message)
        { }
    }
}
