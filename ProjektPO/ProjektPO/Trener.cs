using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektPO
{
    public class Trener : Osoba
    {
        List<string> historiaTrenowania = new List<string>();
        string druzyna;

        public List<string> HistoriaTrenowania { get => historiaTrenowania; set => historiaTrenowania = value; }
        public string Druzyna { get => druzyna; set => druzyna = value; }

        public Trener()
        {
            
        }

        public Trener(string imie, string nazwisko, DateTime dataUrodzenia, List<string> historiaTrenowania, string druzyna) : base(imie, nazwisko, dataUrodzenia) 
        {
            Imie = imie;
            Nazwisko = nazwisko;
            DataUrodzenia = dataUrodzenia;
            HistoriaTrenowania = historiaTrenowania;
            Druzyna = druzyna;
        }

        public void ZmianaDruzyny(string d)
        {
            this.historiaTrenowania.Add(this.druzyna);
            this.druzyna = d;
        }

        public override string ToString()
        {
            return $"{base.Imie} {base.Nazwisko} {base.Wiek()} lat";
        }
    }
}
