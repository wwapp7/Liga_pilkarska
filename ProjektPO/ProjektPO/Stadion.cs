using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektPO
{
    public class Stadion
    {
        string nazwa;
        string druzyna;
        int pojemnosc;
        List<DateTime> terminy = new List<DateTime>();

        public string Nazwa { get => nazwa; set => nazwa = value; }
        public int Pojemnosc { get => pojemnosc; set => pojemnosc = value; }
        public List<DateTime> Terminy { get => terminy; set => terminy = value; }
        public string Druzyna { get => druzyna; set => druzyna = value; }

        public Stadion()
        {
            
        }

        public Stadion(string nazwa, string druzyna, int pojemnosc, List<DateTime> terminy)
        {
            Nazwa = nazwa;
            Druzyna = druzyna;
            Pojemnosc = pojemnosc;
            Terminy = terminy;
        }

        public override string ToString()
        {
            return $"{this.nazwa} ({this.druzyna})";
        }
    }
}
