using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektPO
{
    public class Pilkarz : Osoba
    {
        int liczbaGoli = 0;
        int liczbaAsyst = 0;
        int liczbaCzystychKont = 0;
        int liczbaCzerwonychKartek = 0;
        int liczbaZoltychKartek = 0;

        int numerKoszulki;
        Pozycja rola;
        string druzyna;
        List<string> historiaKlubow = new List<string>();

        public int LiczbaGoli { get => liczbaGoli; set => liczbaGoli = value; }
        public int LiczbaAsyst { get => liczbaAsyst; set => liczbaAsyst = value; }
        public int LiczbaCzystychKont { get => liczbaCzystychKont; set => liczbaCzystychKont = value; }
        public int LiczbaCzerwonychKartek { get => liczbaCzerwonychKartek; set => liczbaCzerwonychKartek = value; }
        public int LiczbaZoltychKartek { get => liczbaZoltychKartek; set => liczbaZoltychKartek = value; }
        public int NumerKoszulki { get => numerKoszulki; set => numerKoszulki = value; }
        public Pozycja Rola { get => rola; set => rola = value; }
        public string Druzyna { get => druzyna; set => druzyna = value; }
        public List<string> HistoriaKlubow { get => historiaKlubow; set => historiaKlubow = value; }



        public Pilkarz()
        {
            
        }

        public Pilkarz(string imie, string nazwisko, DateTime dataUrodzenia, int numerKoszulki, Pozycja rola, string druzyna, List<string> historiaKlubow) 
            : base(imie, nazwisko, dataUrodzenia)
        {
            Imie = imie;
            Nazwisko = nazwisko;
            DataUrodzenia = dataUrodzenia;
            NumerKoszulki = numerKoszulki;
            Rola = rola;
            Druzyna = druzyna;
            HistoriaKlubow = historiaKlubow;
        }

        public void ZmienNumer(int numer)
        {
            this.numerKoszulki = numer;
        }
        public void ZmienPozycje(Pozycja p)
        {
            this.rola = p;
        }
        public void ZmienDruzyne(string d)
        {
            this.historiaKlubow.Add(this.druzyna);
            this.druzyna = d;
        }

        public override string ToString()
        {
            return $"{base.Imie} {base.Nazwisko} (nr {this.numerKoszulki}) {this.rola} {Wiek()} lat";
        }
    }
}

public enum Pozycja
{
    Bramkarz,
    PrawyObronca,
    CofnietyPrawySkrzydlowy,
    LewyObronca,
    CofnietyLewySkrzydlowy,
    SrodkowyObronca,
    PomocnikDefensywny,
    SrodkowyPomocnik,
    PomocnikOfensywny,
    PrawyPomocnik,
    LewyPomocnik,
    PrawySkrzydlowy,
    LewySkrzydlowy,
    SrodkowyNapastnik,
    CofnietyNapastnik
}
