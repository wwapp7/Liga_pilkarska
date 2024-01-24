using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektPO
{
    public class Druzyna : IComparable<Druzyna>
    {
        int goleStracone = 0;
        int goleStrzelone = 0;
        int bilansBramek = 0;
        int punkty = 0;
        int liczbaRozegranychMeczow = 0;

        string nazwa;
        List<Pilkarz> zawodnicy = new List<Pilkarz>();
        Trener trener;
        Stadion stadion;
        List<DateTime> terminarz = new List<DateTime>();

        public int GoleStracone { get => goleStracone; set => goleStracone = value; }
        public int GoleStrzelone { get => goleStrzelone; set => goleStrzelone = value; }
        public int BilansBramek { get => bilansBramek; set => bilansBramek = value; }
        public int Punkty { get => punkty; set => punkty = value; }
        public int LiczbaRozegranychMeczow { get => liczbaRozegranychMeczow; set => liczbaRozegranychMeczow = value; }
        public string Nazwa { get => nazwa; set => nazwa = value; }
        public List<Pilkarz> Zawodnicy { get => zawodnicy; set => zawodnicy = value; }
        public Trener Trener { get => trener; set => trener = value; }
        public Stadion Stadion { get => stadion; set => stadion = value; }
        public List<DateTime> Terminarz { get => terminarz; set => terminarz = value; }
        

        public Druzyna()
        {
            
        }

        public Druzyna(string nazwa, List<Pilkarz> zawodnicy, Trener trener, Stadion stadion, List<DateTime> terminarz)
        {
            Nazwa = nazwa;
            Zawodnicy = zawodnicy;
            Trener = trener;
            Stadion = stadion;
            Terminarz = terminarz;
        }

        public void ZmienaTrenera(Trener trener)
        {
            this.trener = trener;
        }

        public void DodajZawodnika(Pilkarz pilkarz)
        {
            this.zawodnicy.Add(pilkarz);
        }
        
        public void UsunZawodnika(Pilkarz pilkarz)
        {
            if (this.zawodnicy.Contains(pilkarz))
            {
                this.zawodnicy.Remove(pilkarz);
            } else
            {
                throw new BrakTakiejOsobyNaLiscieException("Nie ma takiego piłkarza w tej drużynie.");
            }
            
        }

        public string WypiszDruzyne()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.Nazwa}");
            sb.AppendLine($"Trener: {this.Trener}");
            sb.AppendLine($"Zawodnicy:");
            foreach (var pilkarz in this.zawodnicy) 
            { 
                sb.AppendLine( pilkarz.ToString() );
            }

            return sb.ToString();
        }

        public override string ToString()
        {
            return $"{this.Nazwa}";
        }

        public int CompareTo(Druzyna? other)
        {
            if (other == null)
            {
                return -1;
            }
            int cmp = Punkty.CompareTo( other.Punkty );
            if (cmp != 0) { return cmp; }
            return BilansBramek.CompareTo( other.BilansBramek );
        }
    }
}
