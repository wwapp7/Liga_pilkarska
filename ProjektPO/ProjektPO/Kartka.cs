using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektPO
{
    public class Kartka
    {
        Pilkarz zawodnik;
        string minuta;
        TypKartki kolor;
        Mecz mecz;

        public string Minuta { get => minuta; set => minuta = value; }
        public Pilkarz Zawodnik { get => zawodnik; set => zawodnik = value; }
        public TypKartki Kolor { get => kolor; set => kolor = value; }
        public Mecz Mecz { get => mecz; set => mecz = value; }

        public Kartka()
        {

        }

        public Kartka(Pilkarz zawodnik, string minuta, TypKartki kolor, Mecz mecz)
        {
            Zawodnik = zawodnik;
            Minuta = minuta;
            Kolor = kolor;
            Mecz = mecz;
        }

        public override string ToString()
        {
            if (this.kolor == TypKartki.czerwona)
            {
                return $"{this.minuta}, {this.zawodnik.Imie.Substring(0, 1)}.{this.zawodnik.Nazwisko} czerwona kartka";
            } else
            {
                return $"{this.minuta}, {this.zawodnik.Imie.Substring(0, 1)}.{this.zawodnik.Nazwisko} żółta kartka";
            }
            
        }
    }
}

public enum TypKartki
{
    czerwona,
    zolta
}
