using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektPO
{
    public abstract class Osoba : IEquatable<Osoba>, ICloneable
    {
        string imie;
        string nazwisko;
        DateTime dataUrodzenia;

        public string Imie { get => imie; set => imie = value; }
        public string Nazwisko { get => nazwisko; set => nazwisko = value; }
        public DateTime DataUrodzenia { get => dataUrodzenia; set => dataUrodzenia = value; }

        public Osoba()
        {
            
        }

        public Osoba(string imie, string nazwisko, DateTime dataUrodzenia)
        {
            Imie = imie;
            Nazwisko = nazwisko;
            DataUrodzenia = dataUrodzenia;
        }

        public int Wiek()
        {
            int wynik = 0;
            wynik += (DateTime.Now.Year - this.dataUrodzenia.Year);

            if (this.dataUrodzenia.Month > DateTime.Now.Month)
            {
                return wynik--;
            } else if (this.dataUrodzenia.Month < DateTime.Now.Month)
            {
                return wynik;
            } else
            {
                if (this.dataUrodzenia.Day < DateTime.Now.Day)
                {
                    return wynik--;
                } else
                {
                    return wynik;
                }
            }
        }

        public override string ToString()
        {
            return $"{this.imie} {this.nazwisko} {this.dataUrodzenia}({Wiek()})";
        }

        public bool Equals(Osoba? other)
        {
            {
                if (other == null) { return false; }
                return Nazwisko.Equals(other.Nazwisko);
            }
        }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
