using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektPO
{
    public class SedziaGlowny : Osoba
    {
        List<DateTime> terminy = new List<DateTime>();
        int daneCzerwoneKartki = 0;
        int daneZolteKartki = 0;

        public List<DateTime> Terminy { get => terminy; set => terminy = value; }
        public int DaneCzerwoneKartki { get => daneCzerwoneKartki; set => daneCzerwoneKartki = value; }
        public int DaneZolteKartki { get => daneZolteKartki; set => daneZolteKartki = value; }

        public SedziaGlowny()
        {
            
        }

        public SedziaGlowny(string imie, string nazwisko, DateTime dataUrodzenia, List<DateTime> terminy) : base(imie, nazwisko, dataUrodzenia) 
        {
            Imie = imie;
            Nazwisko = nazwisko;
            DataUrodzenia = dataUrodzenia;
            Terminy = terminy;
        }

        public override string ToString()
        {
            return $"Sędzia główny: {base.Imie} {base.Nazwisko}";
        }
    }
}
