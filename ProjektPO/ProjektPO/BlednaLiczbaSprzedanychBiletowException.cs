using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektPO
{
    public class BlednaLiczbaSprzedanychBiletowException : Exception
    {
        public BlednaLiczbaSprzedanychBiletowException() { }
        
        public BlednaLiczbaSprzedanychBiletowException(string message) : base(message)
        { }
    }
}
