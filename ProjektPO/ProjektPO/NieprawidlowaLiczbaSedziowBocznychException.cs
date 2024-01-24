using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektPO
{
    public class NieprawidlowaLiczbaSedziowBocznychException : Exception
    {
        public NieprawidlowaLiczbaSedziowBocznychException(string message) : base(message)
        { }
    }
}
