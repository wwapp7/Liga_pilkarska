using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektPO
{
    public class NieprawidlowoWprowadzonyWynikException : Exception
    {
        public NieprawidlowoWprowadzonyWynikException(string message) : base(message)
        { }
    }
}
