using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektPO
{
    public class SedziaBoczny : Osoba
    {
        List<DateTime> terminy = new List<DateTime>();

        public List<DateTime> Terminy { get => terminy; set => terminy = value; }

        public SedziaBoczny()
        {
            
        }

        public SedziaBoczny(string imie, string nazwisko, DateTime dataUrodzenia, List<DateTime> terminy) : base(imie, nazwisko, dataUrodzenia)
        {
            Imie = imie;
            Nazwisko = nazwisko;
            DataUrodzenia = dataUrodzenia;
            Terminy = terminy;
        }

        public override string ToString()
        {
            return $"{base.Imie} {base.Nazwisko}";
        }
    }
}
