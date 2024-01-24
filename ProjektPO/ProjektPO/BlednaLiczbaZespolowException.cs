using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektPO
{
    public class BlednaLiczbaZespolowException : Exception
    {
        public BlednaLiczbaZespolowException(string message) : base(message)
        { }
    }
}
