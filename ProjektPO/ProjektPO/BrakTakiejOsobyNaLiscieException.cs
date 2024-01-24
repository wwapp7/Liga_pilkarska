using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektPO
{
    public class BrakTakiejOsobyNaLiscieException : Exception
    {
        public BrakTakiejOsobyNaLiscieException(string message) : base(message)
        { }
    }
}
