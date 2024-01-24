using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektPO
{
    public class Zmiana
    {
        Pilkarz schodzacy;
        Pilkarz wchodzacy;
        string minuta;

        public string Minuta { get => minuta; set => minuta = value; }
        public Pilkarz Schodzacy { get => schodzacy; set => schodzacy = value; }
        public Pilkarz Wchodzacy { get => wchodzacy; set => wchodzacy = value; }

        public Zmiana()
        {
            
        }

        public Zmiana(Pilkarz schodzacy, Pilkarz wchodzacy, string minuta)
        {
            Schodzacy = schodzacy;
            Wchodzacy = wchodzacy;
            Minuta = minuta;
        }

        public override string ToString()
        {
            return $"{minuta}, {this.schodzacy.Imie.Substring(0, 1)}.{this.schodzacy.Nazwisko} <= {this.wchodzacy.Imie.Substring(0, 1)}.{this.wchodzacy.Nazwisko}";
        }
    }
}
