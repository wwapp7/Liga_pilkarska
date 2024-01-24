using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ProjektPO
{
    public class Mecz
    {
        static int licznik;

        int id;
        Druzyna gospodarz;
        Druzyna przyjezdny;
        DateTime termin;
        SedziaGlowny sedziaGlowny;
        List<SedziaBoczny> sedziowieBoczni = new List<SedziaBoczny>();
        Stadion stadion;

        public static int Licznik { get => licznik; set => licznik = value; }
        public int Id { get => id; set => id = value; }
        public DateTime Termin { get => termin; set => termin = value; }
        public Druzyna Gospodarz { get => gospodarz; set => gospodarz = value; }
        public Druzyna Przyjezdny { get => przyjezdny; set => przyjezdny = value; }
        public SedziaGlowny SedziaGlowny { get => sedziaGlowny; set => sedziaGlowny = value; }
        public List<SedziaBoczny> SedziowieBoczni 
        { 
            get => sedziowieBoczni; 
            set
            {
                if (value.Count != 2)
                {
                    throw new NieprawidlowaLiczbaSedziowBocznychException("W meczu musi uczestniczyć dwóch sędziów bocznych.");
                } else
                {
                    sedziowieBoczni = value;
                }
            }
        }
        public Stadion Stadion { get => stadion; set => stadion = value; }
        

        static Mecz()
        {
            licznik = 1;
        }

        public Mecz()
        {
            
        }

        public Mecz(Druzyna gospodarz, Druzyna przyjezdny, DateTime termin, SedziaGlowny sedziaGlowny, List<SedziaBoczny> sedziowieBoczni)
        {
            Id = licznik;
            Gospodarz = gospodarz;
            Przyjezdny = przyjezdny;
            Termin = termin;
            SedziaGlowny = sedziaGlowny;
            SedziowieBoczni = sedziowieBoczni;

            this.stadion = this.gospodarz.Stadion;

            this.gospodarz.Terminarz.Remove(this.termin);
            this.Przyjezdny.Terminarz.Remove(this.termin);
            this.sedziaGlowny.Terminy.Remove(this.termin);
            foreach (var sedziaboczny in this.sedziowieBoczni)
            {
                sedziaboczny.Terminy.Remove(this.termin);
            }
            this.stadion.Terminy.Remove(this.termin);

            licznik++;
        }

        public string RaportMeczowy()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.gospodarz.ToString()} - {this.Przyjezdny.ToString()}");
            sb.AppendLine($"{this.termin} {this.stadion}");
            sb.AppendLine($"{this.sedziaGlowny.ToString()}");
            sb.Append("Sędziowie boczni: ");
            foreach (var sedziaboczny in this.sedziowieBoczni)
            {
                sb.Append($"{sedziaboczny.ToString()} ");
            }

            return sb.ToString();
        }

        public override string ToString()
        {
            return $"{this.termin.ToString("0:MM / dd / yy H: mm")}: {this.gospodarz.ToString()} - {this.Przyjezdny.ToString()}";
        }
    }
}
