using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektPO
{
    public class Gol
    {
        Pilkarz strzelec;
        Pilkarz asystujacy;
        string minuta;
        TypBramki typ;

        public string Minuta { get => minuta; set => minuta = value; }
        public Pilkarz Strzelec { get => strzelec; set => strzelec = value; }
        public Pilkarz? Asystujacy { get => asystujacy; set => asystujacy = value; }
        public TypBramki Typ { get => typ; set => typ = value; }

        public Gol()
        {

        }

        public Gol(Pilkarz strzelec, string minuta, TypBramki typ)
        {
            Strzelec = strzelec;
            Minuta = minuta;
            Typ = typ;
        }

        public Gol(Pilkarz strzelec, Pilkarz asystujacy, string minuta, TypBramki typ)
        {
            Strzelec = strzelec;
            Asystujacy = asystujacy;
            Minuta = minuta;
            Typ = typ;
        }

        public override string ToString()
        {
            if (this.typ == TypBramki.zGry)
            {
                return $"{this.minuta}' {this.strzelec.Imie.Substring(0, 1)}.{this.strzelec.Nazwisko} asysta: {this.asystujacy.Imie.Substring(0, 1)}.{this.asystujacy.Nazwisko}";
            } else
            {
                return $"{this.minuta}' {this.strzelec.Imie.Substring(0,1)}.{this.strzelec.Nazwisko} (karny)";
            }
        }
    }
}

public enum TypBramki
{
    zGry,
    Karny
}
