using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektPO
{
    public class Wynik
    {
        Mecz mecz;
        List<int> wynikMeczu = new List<int>();
        List<Gol> gole = new List<Gol>();
        List<Kartka> kartki = new List<Kartka>();
        List<Zmiana> zmiany = new List<Zmiana>();
        int sprzedaneBilety;
        List<Pilkarz> wyjsciowa11Gospodarza = new List<Pilkarz>();
        List<Pilkarz> wyjsciowa11Przyjezdnego = new List<Pilkarz>();

        public List<int> WynikMeczu 
        { 
            get => wynikMeczu;
            set 
            {
                if (value.Count != 2)
                {
                    throw new NieprawidlowoWprowadzonyWynikException("Zły format wprowadzonego wyniku.");
                } else
                {
                    wynikMeczu = value;
                }
            }
        }
        public Mecz Mecz { get => mecz; set => mecz = value; }
        public List<Gol> Gole 
        { 
            get => gole; 
            set { 
                foreach (Gol gol in value)
                {
                    if (((!this.wyjsciowa11Gospodarza.Contains(gol.Strzelec) 
                        & !this.wyjsciowa11Przyjezdnego.Contains(gol.Strzelec))))
                    {
                        foreach (var zmiana in zmiany)
                        {
                            if (zmiana.Wchodzacy == gol.Strzelec & String.Compare(gol.Minuta, zmiana.Minuta) == 1)
                            {
                                break;
                            } else
                            {
                                throw new ZawodnikaNieByloNaBoiskuException("Strzelca nie było na boisku.");
                            }
                        }
                    }

                    if (((!this.wyjsciowa11Gospodarza.Contains(gol.Asystujacy)
                        & !this.wyjsciowa11Przyjezdnego.Contains(gol.Asystujacy))))
                    {
                        foreach (var zmiana in zmiany)
                        {
                            if (zmiana.Wchodzacy == gol.Asystujacy & String.Compare(gol.Minuta, zmiana.Minuta) == 1)
                            {
                                break;
                            }
                            else
                            {
                                throw new ZawodnikaNieByloNaBoiskuException("Asystującego nie było na boisku.");
                            }
                        }
                    }
                }

                if (value.Count != this.wynikMeczu[0] + this.wynikMeczu[1])
                {
                    throw new NieprawidlowoWprowadzonyWynikException("Liczba wprowadzonych goli nie zgadza się z wynikiem");
                }
                gole = value;
            } 
        }
        public List<Kartka> Kartki
        {
            get => kartki;
            set 
            {
                foreach (Kartka kartka in value)
                {
                    if (((!this.wyjsciowa11Gospodarza.Contains(kartka.Zawodnik)
                        & !this.wyjsciowa11Przyjezdnego.Contains(kartka.Zawodnik))))
                    {
                        foreach (var zmiana in zmiany)
                        {
                            if (zmiana.Wchodzacy == kartka.Zawodnik & String.Compare(kartka.Minuta, zmiana.Minuta) == 1)
                            {
                                break;
                            }
                            else
                            {
                                throw new ZawodnikaNieByloNaBoiskuException("Zawodnika, który otrzymał kartkę nie było na boisku.");
                            }
                        }
                        kartki = value;
                    }
                    kartki = value;
                }
            }
        }
        public List<Zmiana> Zmiany 
        { 
            get => zmiany; 
            set
            {
                foreach (Zmiana zmiana in value)
                {
                    if (((!this.wyjsciowa11Gospodarza.Contains(zmiana.Schodzacy)
                        & !this.wyjsciowa11Przyjezdnego.Contains(zmiana.Schodzacy))))
                    {
                        throw new ZawodnikaNieByloNaBoiskuException("Zawodnika schodzącego nie było na boisku.");
                    }
                }
                zmiany = value;
            } 
        }
        public int SprzedaneBilety
        {
            get => sprzedaneBilety;
            set
            {
                if (value > this.mecz.Stadion.Pojemnosc)
                {
                    throw new BlednaLiczbaSprzedanychBiletowException("Przekroczono pojemność stadionu.");
                } else
                {
                    sprzedaneBilety = value;
                }
            }
        }
        public List<Pilkarz> Wyjsciowa11Gospodarza 
        { 
            get => wyjsciowa11Gospodarza;
            set 
            {
                if (value.Count != 11)
                {
                    throw new BlednieWprowadzonySkladException("Wyjściowy skład musi składać się z 11 zawodników.");
                } else
                {
                    int liczbaBramkarzy = 0;
                    foreach (var item in value)
                    {
                        if (item.Rola == Pozycja.Bramkarz)
                        {
                            liczbaBramkarzy++;
                        }
                    }

                    if (liczbaBramkarzy != 1)
                    {
                        throw new BlednieWprowadzonySkladException("W wyjściowym składzie powinien być jeden bramkarz.");
                    } else
                    {
                        wyjsciowa11Gospodarza = value;
                    }
                }
            } 
        }
        public List<Pilkarz> Wyjsciowa11Przyjezdnego 
        { 
            get => wyjsciowa11Przyjezdnego; 
            set
            {
                {
                    if (value.Count != 11)
                    {
                        throw new BlednieWprowadzonySkladException("Wyjściowy skład musi składać się z 11 zawodników.");
                    }
                    else
                    {
                        int liczbaBramkarzy = 0;
                        foreach (var item in value)
                        {
                            if (item.Rola == Pozycja.Bramkarz)
                            {
                                liczbaBramkarzy++;
                            }
                        }

                        if (liczbaBramkarzy != 1)
                        {
                            throw new BlednieWprowadzonySkladException("W wyjściowym składzie powinien być jeden bramkarz.");
                        }
                        else
                        {
                            wyjsciowa11Przyjezdnego = value;
                        }
                    }
                }
            }
        }

        public Wynik()
        {
            
        }

        public Wynik(Mecz mecz, List<int> wynikMeczu, List<Gol> gole, List<Kartka> kartki, List<Zmiana> zmiany, int sprzedaneBilety, List<Pilkarz> sklad1, List<Pilkarz> sklad2)
        {
            Mecz = mecz;
            this.wynikMeczu = wynikMeczu;
            Gole = gole;
            Kartki = kartki;
            Zmiany = zmiany;
            SprzedaneBilety = sprzedaneBilety;

            Wyjsciowa11Gospodarza = sklad1;
            
            Wyjsciowa11Przyjezdnego = sklad2;
        }

        public string DokladniejszyWynik()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(ToString());
            sb.Append("Gole:\n");
            foreach (var gol in this.gole)
            {
                sb.AppendLine(gol.ToString());
            }
            foreach (var kartka in this.kartki)
            {
                sb.AppendLine(kartka.ToString());
            }
            
            return sb.ToString();

        }

        public override string ToString()
        {
            return $"{this.mecz.Gospodarz} {this.wynikMeczu[0]}:{this.wynikMeczu[1]} {this.mecz.Przyjezdny}";
        }
    }
}
