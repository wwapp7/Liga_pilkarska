using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using ConsoleTables;

namespace ProjektPO
{
    public class Liga
    {
        int liczbaZespolowSpadajacych;
        
        List<Pilkarz> klasyfikacjaStrzelcow = new List<Pilkarz>();
        List<Pilkarz> klasyfikacjaAsystentow = new List<Pilkarz>();
        List<Pilkarz> klasyfikacjaCzystychKont = new List<Pilkarz>();
        List<Pilkarz> klasyfikacjaCzerwonychKartek = new List<Pilkarz>();
        List<Pilkarz> klasyfikacjaZoltychKartek = new List<Pilkarz>();
        List<Mecz> terminarz = new List<Mecz>();
        List<Druzyna> tabela = new List<Druzyna>();
        List<Wynik> wyniki = new List<Wynik>();


        List<Druzyna> zespoly = new List<Druzyna>();
        List<SedziaGlowny> sedziowieGlowni = new List<SedziaGlowny>();
        List<SedziaBoczny> sedziowieBoczni = new List<SedziaBoczny>();
        List<DateTime> terminyMeczy = new List<DateTime>();

        public int LiczbaZespolowSpadajacych { get => liczbaZespolowSpadajacych; set => liczbaZespolowSpadajacych = value; }
        public List<Pilkarz> KlasyfikacjaStrzelcow { get => klasyfikacjaStrzelcow; set => klasyfikacjaStrzelcow = value; }
        public List<Pilkarz> KlasyfikacjaAsystentow { get => klasyfikacjaAsystentow; set => klasyfikacjaAsystentow = value; }
        public List<Pilkarz> KlasyfikacjaCzystychKont { get => klasyfikacjaCzystychKont; set => klasyfikacjaCzystychKont = value; }
        public List<Pilkarz> KlasyfikacjaCzerwonychKartek { get => klasyfikacjaCzerwonychKartek; set => klasyfikacjaCzerwonychKartek = value; }
        public List<Pilkarz> KlasyfikacjaZoltychKartek { get => klasyfikacjaZoltychKartek; set => klasyfikacjaZoltychKartek = value; }
        public List<Mecz> Terminarz { get => terminarz; set => terminarz = value; }
        public List<Druzyna> Tabela { get => tabela; set => tabela = value; }
        public List<Wynik> Wyniki { get => wyniki; set => wyniki = value; }

        public List<Druzyna> Zespoly 
        { 
            get => zespoly; 
            set
            {
                if (value.Count % 2 != 0)
                {
                    throw new BlednaLiczbaZespolowException("Liczba zespołów w lidze musi być parzysta.");
                } else
                {
                    zespoly = value;
                }
            }
        }
        public List<SedziaGlowny> SedziowieGlowni 
        { 
            get => sedziowieGlowni; 
            set
            {
                foreach (var sg in value)
                {
                    sg.Terminy.Sort();
                    int currentIndex = 0;
                    foreach (var termin in sg.Terminy)
                    {
                        if (currentIndex + 1 >= sg.Terminy.Count)
                        {
                            break;
                        }
                        if (DataWtymSamymTygodniu(termin, sg.Terminy[currentIndex + 1]))
                        {
                            throw new NieprawidlowyTerminarzSedziegoException("Sędzia może sędziować tylko jeden mecz w tygodniu.");
                        }
                        currentIndex++;
                    }
                }

                foreach (var termin in this.terminyMeczy)
                {
                    if (!CzySedziaGlownyDostepny(value, termin))
                    {
                        throw new BrakPotrzebnychTerminowException("W którymś z meczy nie będzie dostępnego sędziego głównego.");
                    }
                }
                sedziowieGlowni = value;
            }
        }
        public List<SedziaBoczny> SedziowieBoczni 
        { 
            get => sedziowieBoczni; 
            set
            {
                foreach (var termin in this.terminyMeczy)
                {
                    if (!CzySedziowieBoczniDostepnie(value, termin))
                    {
                        throw new BrakPotrzebnychTerminowException("W którymś z meczy nie będzie dostępnych 2 sędziów bocznych.");
                    }
                }
                sedziowieBoczni = value;
            }
        }
        public List<DateTime> TerminyMeczy 
        { 
            get => terminyMeczy; 
            set
            {
                value.Sort();
                if (value.Count != this.zespoly.Count * (this.zespoly.Count - 1))
                {
                    throw new BrakPotrzebnychTerminowException("Niewystarczająca liczba terminów meczy.");
                } else
                {
                    for (int i = 0;  i < value.Count; i = i + (this.zespoly.Count / 2)) 
                    {
                        for (int j = 1; j < this.zespoly.Count / 2; j++)
                        {
                            if (!DataWtymSamymTygodniu(value[i], value[i + j]))
                            {
                                throw new BrakPotrzebnychTerminowException("Zbyt mała liczba terminów meczy w tym samym tygodniu.");
                            }
                        }
                    }
                    terminyMeczy = value;
                }
            }
        }

        public Liga()
        {

        }

        public Liga(List<Druzyna> zespoly, List<SedziaGlowny> sedziowieGlowni, List<SedziaBoczny> sedziowieBoczni, List<DateTime> terminyMeczy)
        {
            Zespoly = zespoly;
            SedziowieGlowni = sedziowieGlowni;
            SedziowieBoczni = sedziowieBoczni;
            TerminyMeczy = terminyMeczy;

            this.zespoly.Sort(new Comparison<Druzyna>((x, y) => string.Compare(x.Nazwa, y.Nazwa)));

            foreach (var zespol in  zespoly)
            {
                this.tabela.Add(zespol);
            }

            this.liczbaZespolowSpadajacych = (int)Math.Ceiling((double)this.zespoly.Count / 10);
        }

        private bool DataWtymSamymTygodniu(DateTime data1, DateTime data2)
        {
            var cal = System.Globalization.DateTimeFormatInfo.CurrentInfo.Calendar;
            var d1 = data1.Date.AddDays(-1 * (int)cal.GetDayOfWeek(data1));
            var d2 = data2.Date.AddDays(-1 * (int)cal.GetDayOfWeek(data2));

            return d1 == d2;
        }

        private bool CzySedziaGlownyDostepny(List<SedziaGlowny> sedziowie, DateTime termin) 
        {
            foreach (var sedzia in sedziowie)
            {
                if (sedzia.Terminy.Contains(termin))
                {
                    return true;
                }
            }
            return false;
        }

        private bool CzySedziowieBoczniDostepnie(List<SedziaBoczny> sedziowie, DateTime termin)
        {
            int liczbaDostepnychSedziowBocznych = 0;
            foreach (var sedzia in sedziowie)
            {
                if (sedzia.Terminy.Contains(termin))
                {
                    liczbaDostepnychSedziowBocznych++;
                }
                if (liczbaDostepnychSedziowBocznych < 2)
                {
                    return false;
                }
            }
            return true;
        }

        public void GenerujTerminarz()
        {
            List<List<Druzyna>> temp = new List<List<Druzyna>>();
            int current = 1;

            foreach (var zespol in this.zespoly)
            {
                for (int i = current; i < this.zespoly.Count; i++)
                {
                    List<Druzyna> starcie = new List<Druzyna>();
                    starcie.Add(zespol);
                    starcie.Add(this.zespoly[i]);
                    temp.Add(starcie);
                }
                current++;
            }

            List<List<Druzyna>> starcia = new List<List<Druzyna>>();

            for (int i = 0; i < temp.Count / 2; i++)
            {
                starcia.Add(temp[i]);
                starcia.Add(temp[temp.Count - 1 - i]);
            }

            this.terminyMeczy.Sort();

            foreach (var starcie in starcia)
            {
                DateTime dataMeczu = this.terminyMeczy[0];
                DateTime dataRewanzu = this.terminyMeczy[this.terminyMeczy.Count - 1];

                foreach (var sedzia in this.sedziowieGlowni)
                {
                    if (sedzia.Terminy.Contains(dataMeczu))
                    {
                        SedziaGlowny sg = sedzia;
                        List<SedziaBoczny> sb = new List<SedziaBoczny>();
                        foreach (var sedziaBoczny in this.sedziowieBoczni)
                        {
                            if (sedziaBoczny.Terminy.Contains(dataMeczu))
                            {
                                sb.Add(sedziaBoczny);
                                if (sb.Count == 2)
                                {
                                    this.terminarz.Add(new Mecz(starcie[0], starcie[1], dataMeczu, sg, sb));
                                    break;
                                }
                            }
                        }
                        break;
                    }
                }

                foreach (var sedzia in this.sedziowieGlowni)
                {
                    if (sedzia.Terminy.Contains(dataRewanzu))
                    {
                        SedziaGlowny sg = sedzia;
                        List<SedziaBoczny> sb = new List<SedziaBoczny>();
                        foreach (var sedziaBoczny in this.sedziowieBoczni)
                        {
                            if (sedziaBoczny.Terminy.Contains(dataRewanzu))
                            {
                                sb.Add(sedziaBoczny);
                                if (sb.Count == 2)
                                {
                                    Mecz mecz = new Mecz(starcie[1], starcie[0], dataRewanzu, sg, sb);
                                    this.terminarz.Add(mecz);
                                    break;
                                }
                            }
                        }
                        break;
                    }
                }

            }

            this.terminarz.Sort(new Comparison<Mecz>((x, y) => DateTime.Compare(x.Termin, y.Termin)));
        }

        public void PrzelozMecz(Mecz mecz, DateTime nowyTermin)
        {
            mecz.Termin = nowyTermin;
            Aktualizuj();
        }

        public void UsunZespol(Druzyna druzyna)
        {
            this.zespoly.Remove(druzyna);
            this.tabela.Remove(druzyna);
        }

        public void DodajZespol(Druzyna druzyna)
        {
            this.zespoly.Add(druzyna);
        }

        public void DodajWynik(Wynik wynik)
        {
            this.wyniki.Add(wynik);
            
            foreach (var mecz in this.terminarz)
            {
                if (mecz.Id == wynik.Mecz.Id)
                {
                    this.terminarz.Remove(mecz);
                    break;
                }
            }


            wynik.Mecz.Gospodarz.BilansBramek += wynik.WynikMeczu[0] - wynik.WynikMeczu[1];
            wynik.Mecz.Przyjezdny.BilansBramek += wynik.WynikMeczu[1] - wynik.WynikMeczu[0];
            wynik.Mecz.Gospodarz.GoleStrzelone += wynik.WynikMeczu[0];
            wynik.Mecz.Gospodarz.GoleStracone += wynik.WynikMeczu[1];
            wynik.Mecz.Przyjezdny.GoleStrzelone += wynik.WynikMeczu[1];
            wynik.Mecz.Przyjezdny.GoleStracone += wynik.WynikMeczu[0];

            foreach (var gol in wynik.Gole)
            {
                gol.Strzelec.LiczbaGoli++;
                if (gol.Typ == TypBramki.zGry)
                {
                    gol.Asystujacy.LiczbaAsyst++;
                }
            }

            foreach (var kartka in wynik.Kartki)
            {
                if (kartka.Kolor == TypKartki.zolta)
                {
                    kartka.Zawodnik.LiczbaZoltychKartek++;
                    kartka.Mecz.SedziaGlowny.DaneZolteKartki++;
                }
                else
                {
                    kartka.Zawodnik.LiczbaCzerwonychKartek++;
                    kartka.Mecz.SedziaGlowny.DaneCzerwoneKartki++;
                }
            }

            if (wynik.WynikMeczu[1] == 0)
            {
                foreach (var zawodnik in wynik.Mecz.Gospodarz.Zawodnicy)
                {
                    if (zawodnik.Rola == Pozycja.Bramkarz)
                    {
                        zawodnik.LiczbaCzystychKont++;
                    }
                }
            }

            if (wynik.WynikMeczu[0] == 0)
            {
                foreach (var zawodnik in wynik.Mecz.Przyjezdny.Zawodnicy)
                {
                    if (zawodnik.Rola == Pozycja.Bramkarz)
                    {
                        zawodnik.LiczbaCzystychKont++;
                    }
                }
            }

            if (wynik.WynikMeczu[0] > wynik.WynikMeczu[1])
            {
                wynik.Mecz.Gospodarz.Punkty += 3;
            }
            else if (wynik.WynikMeczu[0] == wynik.WynikMeczu[1])
            {
                wynik.Mecz.Gospodarz.Punkty += 1;
                wynik.Mecz.Przyjezdny.Punkty += 1;
            }
            else
            {
                wynik.Mecz.Przyjezdny.Punkty += 3;
            }

            wynik.Mecz.Gospodarz.LiczbaRozegranychMeczow++;
            wynik.Mecz.Przyjezdny.LiczbaRozegranychMeczow++;

            foreach (var bramka in wynik.Gole)
            {
                if (!klasyfikacjaStrzelcow.Contains(bramka.Strzelec))
                {
                    klasyfikacjaStrzelcow.Add(bramka.Strzelec);
                }
                if (bramka.Typ == TypBramki.zGry)
                {
                    if (!klasyfikacjaAsystentow.Contains(bramka.Asystujacy))
                    {
                        klasyfikacjaAsystentow.Add(bramka.Asystujacy);
                    }
                }
            }

            foreach(var kartka in wynik.Kartki)
            {
                if (kartka.Kolor == TypKartki.czerwona)
                {
                    if (!klasyfikacjaCzerwonychKartek.Contains(kartka.Zawodnik))
                    {
                        klasyfikacjaCzerwonychKartek.Add(kartka.Zawodnik);
                    }
                } else
                {
                    if (!klasyfikacjaZoltychKartek.Contains(kartka.Zawodnik))
                    {
                        klasyfikacjaZoltychKartek.Add(kartka.Zawodnik);
                    }
                }
            }

            foreach (var zawodnik in wynik.Wyjsciowa11Gospodarza)
            {
                if (zawodnik.Rola == Pozycja.Bramkarz)
                {
                    if (!this.klasyfikacjaCzystychKont.Contains(zawodnik) & zawodnik.LiczbaCzystychKont > 0)
                    {
                        this.klasyfikacjaCzystychKont.Add(zawodnik);
                    }
                }
            }

            foreach (var zawodnik in wynik.Wyjsciowa11Przyjezdnego)
            {
                if (zawodnik.Rola == Pozycja.Bramkarz)
                {
                    if (!this.klasyfikacjaCzystychKont.Contains(zawodnik) & zawodnik.LiczbaCzystychKont > 0)
                    {
                        this.klasyfikacjaCzystychKont.Add(zawodnik);
                    }
                }
            }


            Aktualizuj();
        }

        public void Aktualizuj()
        {
            this.zespoly.Sort();
            this.tabela = this.tabela.OrderByDescending(x => x.Punkty).ThenByDescending(x => x.BilansBramek).ToList();
            this.klasyfikacjaAsystentow = this.klasyfikacjaAsystentow.OrderByDescending(x => x.LiczbaAsyst).ToList();
            this.klasyfikacjaStrzelcow = this.klasyfikacjaStrzelcow.OrderByDescending(x => x.LiczbaGoli).ToList();
            this.klasyfikacjaCzerwonychKartek = this.klasyfikacjaCzerwonychKartek.OrderByDescending(x => x.LiczbaCzerwonychKartek).ToList();
            this.klasyfikacjaZoltychKartek = this.klasyfikacjaZoltychKartek.OrderByDescending(x => x.LiczbaZoltychKartek).ToList();
            this.terminarz.Sort(new Comparison<Mecz>((x, y) => DateTime.Compare(x.Termin, y.Termin)));
        }

        public void DodajSedziegoGlownego(SedziaGlowny sedziaGlowny)
        {
            this.sedziowieGlowni.Add(sedziaGlowny);
        }

        public void UsunSedziegoGlownego(SedziaGlowny sedziaGlowny)
        {
            if (this.sedziowieGlowni.Contains(sedziaGlowny))
            {
                this.sedziowieGlowni.Remove(sedziaGlowny);
            } else
            {
                throw new BrakTakiejOsobyNaLiscieException("Nie ma takiego sędziego głównego na liście.");
            }
            
        }

        public void DodajSedziegoBocznego(SedziaBoczny sedziaBoczny)
        {
            this.sedziowieBoczni.Add(sedziaBoczny);
        }

        public void UsunSedziegoBocznego(SedziaBoczny sedziaBoczny)
        {
            if (this.sedziowieBoczni.Contains(sedziaBoczny))
            {
                this.sedziowieBoczni.Remove(sedziaBoczny);
            }
            else
            {
                throw new BrakTakiejOsobyNaLiscieException("Nie ma takiego sędziego bocznego na liście.");
            }
        }
        
        public void WyswietlTabele()
        {
            int pozycjaWtabeli = 1;
            var aktualnaTabela = new ConsoleTable("Pozycja", "Nazwa", "Liczba meczy", "Punkty", "Bramki strzelone", "Bramki stracone", "Bilans Bramek");

            foreach (var druzyna in this.tabela)
            {
                aktualnaTabela.AddRow(pozycjaWtabeli, druzyna.Nazwa, druzyna.LiczbaRozegranychMeczow, druzyna.Punkty, druzyna.GoleStrzelone, druzyna.GoleStracone, druzyna.BilansBramek);
                pozycjaWtabeli++;
            }
            aktualnaTabela.Write();
        }

        public void WyswietlKlasyfikacjeStrzelcow()
        {
            int pozycjaWtabeli = 1;
            int aktualnaLiczba = this.klasyfikacjaStrzelcow[0].LiczbaGoli;
            var aktualnaTabela = new ConsoleTable("Pozycja", "Piłkarz", "Drużyna", "Liczba bramek");

            foreach (var pilkarz in this.klasyfikacjaStrzelcow)
            {
                if (pilkarz.LiczbaGoli == aktualnaLiczba)
                {
                    aktualnaTabela.AddRow(pozycjaWtabeli, $"{pilkarz.Imie.Substring(0, 1)}.{pilkarz.Nazwisko}", pilkarz.Druzyna, pilkarz.LiczbaGoli);
                } else
                {
                    aktualnaLiczba = pilkarz.LiczbaGoli;
                    pozycjaWtabeli++;
                    aktualnaTabela.AddRow(pozycjaWtabeli, $"{pilkarz.Imie.Substring(0, 1)}.{pilkarz.Nazwisko}", pilkarz.Druzyna, pilkarz.LiczbaGoli);
                }
            }
            aktualnaTabela.Write();
        }

        public void WyswietlKlasyfikacjeAsystentow()
        {
            int pozycjaWtabeli = 1;
            int aktualnaLiczba = this.klasyfikacjaAsystentow[0].LiczbaAsyst;
            var aktualnaTabela = new ConsoleTable("Pozycja", "Piłkarz", "Drużyna", "Liczba asyst");

            foreach (var pilkarz in this.klasyfikacjaAsystentow)
            {
                if (pilkarz.LiczbaAsyst == aktualnaLiczba)
                {
                    aktualnaTabela.AddRow(pozycjaWtabeli, $"{pilkarz.Imie.Substring(0, 1)}.{pilkarz.Nazwisko}", pilkarz.Druzyna, pilkarz.LiczbaAsyst);
                } else
                {
                    aktualnaLiczba = pilkarz.LiczbaAsyst;
                    pozycjaWtabeli++;
                    aktualnaTabela.AddRow(pozycjaWtabeli, $"{pilkarz.Imie.Substring(0, 1)}.{pilkarz.Nazwisko}", pilkarz.Druzyna, pilkarz.LiczbaAsyst);
                    
                }
                
            }
            aktualnaTabela.Write();
        }

        public void WyswietlKlasyfikacjeCzerwonychKartek()
        {
            int pozycjaWtabeli = 1;
            int aktualnaLiczba = this.klasyfikacjaCzerwonychKartek[0].LiczbaCzerwonychKartek;
            var aktualnaTabela = new ConsoleTable("Pozycja", "Piłkarz", "Drużyna", "Liczba czerwonych kartek");

            foreach (var pilkarz in this.klasyfikacjaCzerwonychKartek)
            {
                if (pilkarz.LiczbaCzerwonychKartek == aktualnaLiczba)
                {
                    aktualnaTabela.AddRow(pozycjaWtabeli, $"{pilkarz.Imie.Substring(0, 1)}.{pilkarz.Nazwisko}", pilkarz.Druzyna, pilkarz.LiczbaCzerwonychKartek);
                } else
                {
                    aktualnaLiczba = pilkarz.LiczbaCzerwonychKartek;
                    pozycjaWtabeli++;
                    aktualnaTabela.AddRow(pozycjaWtabeli, $"{pilkarz.Imie.Substring(0, 1)}.{pilkarz.Nazwisko}", pilkarz.Druzyna, pilkarz.LiczbaCzerwonychKartek);
                }
            }
            aktualnaTabela.Write();
        }

        public void WyswietlKlasyfikacjeZoltychKartek()
        {
            int pozycjaWtabeli = 1;
            int aktualnaLiczba = this.KlasyfikacjaZoltychKartek[0].LiczbaZoltychKartek;
            var aktualnaTabela = new ConsoleTable("Pozycja", "Piłkarz", "Drużyna", "Liczba żółtych kartek");

            foreach (var pilkarz in this.klasyfikacjaZoltychKartek)
            {
                if (pilkarz.LiczbaZoltychKartek == aktualnaLiczba)
                {
                    aktualnaTabela.AddRow(pozycjaWtabeli, $"{pilkarz.Imie.Substring(0, 1)}.{pilkarz.Nazwisko}", pilkarz.Druzyna, pilkarz.LiczbaZoltychKartek);
                } else
                {
                    aktualnaLiczba = pilkarz.LiczbaZoltychKartek;
                    pozycjaWtabeli++;
                    aktualnaTabela.AddRow(pozycjaWtabeli, $"{pilkarz.Imie.Substring(0, 1)}.{pilkarz.Nazwisko}", pilkarz.Druzyna, pilkarz.LiczbaZoltychKartek);
                } 
            }
            aktualnaTabela.Write();
        }

        public void WyswietlKlasyfikacjeCzystychKont()
        {
            int pozycjaWtabeli = 1;
            int aktualnaLiczba = this.KlasyfikacjaCzystychKont[0].LiczbaCzystychKont;
            var aktualnaTabela = new ConsoleTable("Pozycja", "Piłkarz", "Drużyna", "Liczba czystych kont");

            foreach (var pilkarz in this.klasyfikacjaCzystychKont)
            {
                if (pilkarz.LiczbaCzystychKont == aktualnaLiczba)
                {
                    aktualnaTabela.AddRow(pozycjaWtabeli, $"{pilkarz.Imie.Substring(0, 1)}.{pilkarz.Nazwisko}", pilkarz.Druzyna, pilkarz.LiczbaCzystychKont);
                } else
                {
                    aktualnaLiczba = pilkarz.LiczbaCzystychKont;
                    pozycjaWtabeli++;
                    aktualnaTabela.AddRow(pozycjaWtabeli, $"{pilkarz.Imie.Substring(0, 1)}.{pilkarz.Nazwisko}", pilkarz.Druzyna, pilkarz.LiczbaCzystychKont);
                }
            }
            aktualnaTabela.Write();
        }

        public void WyswietlTerminarz()
        {
            var aktualnaTabela = new ConsoleTable("Data", "Gospodarz", "Przyjezdny", "Stadion");

            foreach (var mecz in this.terminarz)
            {
                aktualnaTabela.AddRow(mecz.Termin, mecz.Gospodarz, mecz.Przyjezdny, mecz.Stadion);
            }
            aktualnaTabela.Write();
        }

        public void WyswietlWyniki()
        {
            var aktualnaTabela = new ConsoleTable("Wyniki");

            foreach (var mecz in this.wyniki)
            {
                aktualnaTabela.AddRow(mecz.ToString());
            }
            aktualnaTabela.Write();
        }

        public void NowySezon(List<Druzyna> druzynyZawansem, List<DateTime> noweTerminyMeczow, List<SedziaGlowny> sedziowieGlowni, List<SedziaBoczny> sedziowieBoczni)
        {
            Aktualizuj();
            int n = this.zespoly.Count;

            if (druzynyZawansem.Count != liczbaZespolowSpadajacych)
            {
                throw new BlednaLiczbaZespolowException("Zespołów awansujących musi być tyle ile spadających.");
            }

            for (int i = this.zespoly.Count - 1; i > n - 1 - this.liczbaZespolowSpadajacych; i--)
            {
                UsunZespol(this.tabela[i]);
            }

            foreach (var zespol in druzynyZawansem)
            {
                DodajZespol(zespol);
            }

            this.sedziowieBoczni.Clear();
            this.sedziowieGlowni.Clear();
            this.terminyMeczy.Clear();
            this.tabela.Clear();
            this.terminarz.Clear();
            this.klasyfikacjaAsystentow.Clear();
            this.klasyfikacjaCzerwonychKartek.Clear();
            this.klasyfikacjaStrzelcow.Clear();
            this.klasyfikacjaZoltychKartek.Clear();
            this.klasyfikacjaCzystychKont.Clear();
            this.wyniki.Clear();

            this.zespoly.Sort(new Comparison<Druzyna>((x, y) => string.Compare(x.Nazwa, y.Nazwa)));

            foreach (var zespol in this.zespoly)
            {
                this.tabela.Add(zespol);
                zespol.Terminarz = noweTerminyMeczow;
                zespol.LiczbaRozegranychMeczow = 0;
                zespol.Punkty = 0;
                zespol.BilansBramek = 0;
                zespol.GoleStracone = 0;
                zespol.GoleStrzelone = 0;

                foreach (var pilkarz in zespol.Zawodnicy) 
                {
                    pilkarz.LiczbaAsyst = 0;
                    pilkarz.LiczbaCzerwonychKartek = 0;
                    pilkarz.LiczbaCzystychKont = 0;
                    pilkarz.LiczbaGoli = 0;
                    pilkarz.LiczbaZoltychKartek = 0;
                }
                foreach (var data in zespol.Terminarz)
                {
                    Console.WriteLine(data);
                }
            }
            foreach (var data in noweTerminyMeczow)
            {
                this.terminyMeczy.Add(data);
            }

            foreach (var sg in sedziowieGlowni)
            {
                this.sedziowieGlowni.Add(sg);
            }

            foreach (var sb in sedziowieBoczni)
            {
                this.sedziowieBoczni.Add(sb);
            }
        }

        public void ZapisXml(string nazwaPliku)
        {
            using StreamWriter sw = new(nazwaPliku); XmlSerializer xs =
            new(typeof(Liga)); xs.Serialize(sw, this);
        }

        public static Liga? OdczytXml(string nazwaPliku)
        {
            using StreamReader sr = new(nazwaPliku); XmlSerializer xs = new(typeof(Liga));
            return (Liga?)xs.Deserialize(sr);
        }
    }
}
