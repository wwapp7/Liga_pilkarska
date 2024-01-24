using System;
using System.Runtime.CompilerServices;

namespace ProjektPO
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Pilkarz p1 = new Pilkarz("Iker", "Cassilas", new DateTime(2000, 12, 11), 1, Pozycja.Bramkarz, "Real Madryt", new List<string>());
            Pilkarz p2 = new Pilkarz("Sergio", "Ramos", new DateTime(2001, 10, 9), 2, Pozycja.SrodkowyObronca, "Real Madryt", new List<string>());
            Pilkarz p3 = new Pilkarz("David", "Alaba", new DateTime(1999, 1, 1), 3, Pozycja.SrodkowyObronca, "Real Madryt", new List<string>());
            Pilkarz p4 = new Pilkarz("Dani", "Carvajal", new DateTime(2002, 2, 20), 4, Pozycja.PrawyObronca, "Real Madryt", new List<string>());
            Pilkarz p5 = new Pilkarz("Ferland", "Mendy", new DateTime(2003, 4, 30), 5, Pozycja.LewyObronca, "Real Madryt", new List<string>());
            Pilkarz p6 = new Pilkarz("Fede", "Valverde", new DateTime(2004, 7, 16), 6, Pozycja.SrodkowyPomocnik, "Real Madryt", new List<string>());
            Pilkarz p7 = new Pilkarz("Luka", "Modric", new DateTime(1990, 10, 11), 7, Pozycja.SrodkowyPomocnik, "Real Madryt", new List<string>());
            Pilkarz p8 = new Pilkarz("Jude", "Bellingham", new DateTime(2004, 8, 7), 8, Pozycja.SrodkowyPomocnik, "Real Madryt", new List<string>());
            Pilkarz p9 = new Pilkarz("Vinicius", "Junior", new DateTime(2003, 12, 1), 9, Pozycja.LewySkrzydlowy, "Real Madryt", new List<string>());
            Pilkarz p10 = new Pilkarz("Karim", "Benzema", new DateTime(1995, 1, 19), 10, Pozycja.SrodkowyNapastnik, "Real Madryt", new List<string>());
            Pilkarz p11 = new Pilkarz("Rodrygo", "Goes", new DateTime(2003, 9, 11), 11, Pozycja.PrawySkrzydlowy, "Real Madryt", new List<string>());

            Pilkarz p12 = new Pilkarz("Marc Andre", "Ter Stegen", new DateTime(2001, 1, 11), 1, Pozycja.Bramkarz, "Barcelona", new List<string>());
            Pilkarz p13 = new Pilkarz("Gerard", "Pique", new DateTime(1998, 5, 9), 2, Pozycja.SrodkowyObronca, "Barcelona", new List<string>());
            Pilkarz p14 = new Pilkarz("Carles", "Puyol", new DateTime(1990, 10, 19), 3, Pozycja.SrodkowyObronca, "Barcelona", new List<string>());
            Pilkarz p15 = new Pilkarz("Dani", "Alves", new DateTime(1989, 3, 20), 4, Pozycja.PrawyObronca, "Barcelona", new List<string>());
            Pilkarz p16 = new Pilkarz("Sergi", "Roberto", new DateTime(2003, 7, 30), 5, Pozycja.LewyObronca, "Barcelona", new List<string>());
            Pilkarz p17 = new Pilkarz("Frankie", "de Jong", new DateTime(2004, 8, 20), 6, Pozycja.SrodkowyPomocnik, "Barcelona", new List<string>());
            Pilkarz p18 = new Pilkarz("Ilkay", "Gundogan", new DateTime(1996, 11, 11), 7, Pozycja.SrodkowyPomocnik, "Barcelona", new List<string>());
            Pilkarz p19 = new Pilkarz("Andres", "Iniesta", new DateTime(1988, 12, 1), 8, Pozycja.SrodkowyPomocnik, "Barcelona", new List<string>());
            Pilkarz p20 = new Pilkarz("Ansu", "Fati", new DateTime(2005, 10, 17), 9, Pozycja.LewySkrzydlowy, "Barcelona", new List<string>());
            Pilkarz p21 = new Pilkarz("Robert", "Lewandowski", new DateTime(1995, 6, 16), 10, Pozycja.SrodkowyNapastnik, "Barcelona", new List<string>());
            Pilkarz p22 = new Pilkarz("Lionel", "Messi", new DateTime(1996, 9, 4), 11, Pozycja.PrawySkrzydlowy, "Barcelona", new List<string>());

            Pilkarz p23 = new Pilkarz("Manuel", "Neuer", new DateTime(2000, 1, 11), 1, Pozycja.Bramkarz, "Bayern Monachium", new List<string>());
            Pilkarz p24 = new Pilkarz("Jerome", "Boateng", new DateTime(1995, 5, 9), 2, Pozycja.SrodkowyObronca, "Bayern Monachium", new List<string>());
            Pilkarz p25 = new Pilkarz("Nicholas", "Sule", new DateTime(1992, 10, 19), 3, Pozycja.SrodkowyObronca, "Bayern Monachium", new List<string>());
            Pilkarz p26 = new Pilkarz("Raphael", "Guerreiro", new DateTime(1999, 3, 20), 4, Pozycja.PrawyObronca, "Bayern Monachium", new List<string>());
            Pilkarz p27 = new Pilkarz("Alphonso", "Davis", new DateTime(2003, 7, 30), 5, Pozycja.LewyObronca, "Bayern Monachium", new List<string>());
            Pilkarz p28 = new Pilkarz("Joshua", "Kimmich", new DateTime(2005, 8, 20), 6, Pozycja.SrodkowyPomocnik, "Bayern Monachium", new List<string>());
            Pilkarz p29 = new Pilkarz("Leon", "Goretzka", new DateTime(1997, 11, 11), 7, Pozycja.SrodkowyPomocnik, "Bayern Monachium", new List<string>());
            Pilkarz p30 = new Pilkarz("Thomas", "Mueller", new DateTime(1987, 12, 1), 8, Pozycja.PomocnikOfensywny, "Bayern Monachium", new List<string>());
            Pilkarz p31 = new Pilkarz("Jamal", "Musiala", new DateTime(2006, 10, 17), 9, Pozycja.LewySkrzydlowy, "Bayern Monachium", new List<string>());
            Pilkarz p32 = new Pilkarz("Harry", "Kane", new DateTime(1994, 6, 16), 10, Pozycja.SrodkowyNapastnik, "Bayern Monachium", new List<string>());
            Pilkarz p33 = new Pilkarz("Leroy", "Sane", new DateTime(1999, 9, 4), 11, Pozycja.PrawySkrzydlowy, "Bayern Monachium", new List<string>());

            Pilkarz p34 = new Pilkarz("Stefan", "Ortega", new DateTime(1995, 1, 11), 1, Pozycja.Bramkarz, "Manchester City", new List<string>());
            Pilkarz p35 = new Pilkarz("Ruben", "Dias", new DateTime(1999, 5, 9), 2, Pozycja.SrodkowyObronca, "Manchester City", new List<string>());
            Pilkarz p36 = new Pilkarz("John", "Stones", new DateTime(1991, 10, 19), 3, Pozycja.SrodkowyObronca, "Manchester City", new List<string>());
            Pilkarz p37 = new Pilkarz("Nathan", "Ake", new DateTime(2000, 3, 20), 4, Pozycja.PrawyObronca, "Manchester City", new List<string>());
            Pilkarz p38 = new Pilkarz("Kyle", "Walker", new DateTime(2001, 7, 30), 5, Pozycja.LewyObronca, "Manchester City", new List<string>());
            Pilkarz p39 = new Pilkarz("Matheus", "Luiz", new DateTime(2002, 8, 20), 6, Pozycja.SrodkowyPomocnik, "Manchester City", new List<string>());
            Pilkarz p40 = new Pilkarz("Kevin", "de Bruyne", new DateTime(1997, 11, 11), 7, Pozycja.SrodkowyPomocnik, "Manchester City", new List<string>());
            Pilkarz p41 = new Pilkarz("Bernardo", "Silva", new DateTime(1989, 12, 1), 8, Pozycja.PomocnikOfensywny, "Manchester City", new List<string>());
            Pilkarz p42 = new Pilkarz("Phil", "Foden", new DateTime(2002, 10, 17), 9, Pozycja.LewySkrzydlowy, "Manchester City", new List<string>());
            Pilkarz p43 = new Pilkarz("Erling", "Haaland", new DateTime(1991, 6, 16), 10, Pozycja.SrodkowyNapastnik, "Manchester City", new List<string>());
            Pilkarz p44 = new Pilkarz("Jack", "Grealish", new DateTime(1998, 9, 4), 11, Pozycja.PrawySkrzydlowy, "Manchester City", new List<string>());

            List<Pilkarz> sklad1 = new List<Pilkarz>(new Pilkarz[] { p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11 });
            List<Pilkarz> sklad2 = new List<Pilkarz>(new Pilkarz[] { p12, p13, p14, p15, p16, p17, p18, p19, p20, p21, p22 });
            List<Pilkarz> sklad3 = new List<Pilkarz>(new Pilkarz[] { p23, p24, p25, p26, p27, p28, p29, p30, p31, p32, p33 });
            List<Pilkarz> sklad4 = new List<Pilkarz>(new Pilkarz[] { p34, p35, p36, p37, p38, p39, p40, p41, p42, p43, p44 });

            //List<Pilkarz> sklad5 = new List<Pilkarz>(new Pilkarz[] { p12, p13, p14, p15, p16, p17, p18, p19, p20, p21 });

            Trener trener1 = new Trener("Carlo", "Ancelotii", new DateTime(1977, 10, 12), new List<string>(), "Real Madryt");
            Trener trener2 = new Trener("Xavi", "Hernandez", new DateTime(1985, 1, 11), new List<string>(), "Barcelona");
            Trener trener3 = new Trener("Thomas", "Tuchel", new DateTime(1979, 5, 13), new List<string>(), "Bayern Monachium");
            Trener trener4 = new Trener("Pep", "Guardiola", new DateTime(1978, 7, 22), new List<string>(), "Manchester City");

            List<DateTime> terminy = new List<DateTime>(new DateTime[] { new DateTime(2021, 1, 6, 18, 0, 0), new DateTime(2021, 1, 7, 18, 0, 0),
                new DateTime(2021, 1, 13, 18, 0, 0), new DateTime(2021, 1, 14, 18, 0, 0), new DateTime(2021, 1, 20, 18, 0, 0), 
                new DateTime(2021, 1, 21, 18, 0, 0), new DateTime(2021, 1, 27, 18, 0, 0), new DateTime(2021, 1, 28, 18, 0, 0),
                new DateTime(2021, 2, 3, 18, 0, 0), new DateTime(2021, 2, 4, 18, 0, 0), new DateTime(2021, 2, 10, 18, 0, 0), 
                new DateTime(2021, 2, 11, 18, 0, 0)} );

            Stadion s1 = new Stadion("Estadio Santiago Bernabeu", "Real Madryt", 80000, terminy);
            Stadion s2 = new Stadion("Camp Nou", "Barcelona", 79000, terminy);
            Stadion s3 = new Stadion("Allianz Arena", "Bayern Monachium", 70000, terminy);
            Stadion s4 = new Stadion("Ettihad Stadium", "Manchester City", 77000, terminy);

            Druzyna d1 = new Druzyna("Real Madryt", sklad1, trener1, s1, terminy);
            Druzyna d2 = new Druzyna("Barcelona", sklad2, trener2, s2, terminy);
            Druzyna d3 = new Druzyna("Bayern Monachium", sklad3, trener3, s3, terminy);
            Druzyna d4 = new Druzyna("Manchester City", sklad4, trener4, s4, terminy);

            List<Druzyna> zespoly = new List<Druzyna>(new Druzyna[] { d1, d2, d3, d4});    

            List<DateTime> terminys1 = new List<DateTime>(new DateTime[] { new DateTime(2021, 1, 6, 18, 0, 0),
                new DateTime(2021, 1, 13, 18, 0, 0), new DateTime(2021, 1, 20, 18, 0, 0),
                new DateTime(2021, 1, 27, 18, 0, 0),
                new DateTime(2021, 2, 3, 18, 0, 0),new DateTime(2021, 2, 10, 18, 0, 0), });

            List<DateTime> terminys2 = new List<DateTime>(new DateTime[] { new DateTime(2021, 1, 7, 18, 0, 0),
                new DateTime(2021, 1, 14, 18, 0, 0), new DateTime(2021, 1, 21, 18, 0, 0),
                new DateTime(2021, 1, 28, 18, 0, 0),
                new DateTime(2021, 2, 4, 18, 0, 0),new DateTime(2021, 2, 11, 18, 0, 0), });

            SedziaGlowny sg1 = new SedziaGlowny("Szymon", "Marciniak", new DateTime(1990, 12, 1), terminys1);
            SedziaGlowny sg2 = new SedziaGlowny("Kevin", "Ortega", new DateTime(1980, 1, 19), terminys2);

            List<SedziaGlowny> sedziowieGlowni = new List<SedziaGlowny>(new SedziaGlowny[] { sg1, sg2 });

            SedziaBoczny sb1 = new SedziaBoczny("Adam", "Nowak", new DateTime(1986, 12, 19), terminys1);
            SedziaBoczny sb2 = new SedziaBoczny("Jan", "Kowalski", new DateTime(1991, 5, 19), terminys1);
            SedziaBoczny sb3 = new SedziaBoczny("Piotr", "Kowal", new DateTime(1997, 1, 5), terminys2);
            SedziaBoczny sb4 = new SedziaBoczny("Zbigniew", "Stonoga", new DateTime(1969, 4, 27), terminys2);

            List<SedziaBoczny> sedziowieBoczni = new List<SedziaBoczny> { sb1, sb2, sb3, sb4 };

            Liga liga = new Liga(zespoly, sedziowieGlowni, sedziowieBoczni, terminy);



            liga.WyswietlTabele();


            liga.GenerujTerminarz();
            liga.WyswietlTerminarz();

            /*liga.DodajWynik(new Wynik(liga.Terminarz[0], new List<int>(new int[] { 1, 0 }),
                new List<Gol>(new Gol[] { new Gol(p20, p17, "81", TypBramki.zGry) }), new List<Kartka>(), new List<Zmiana>(), 15000, sklad2, sklad3));
            liga.ZapisXml("serializacjaPO");*/

            //liga.PrzelozMecz(liga.Terminarz[0], new DateTime(2021, 2, 12, 18, 0, 0));

            //liga.WyswietlTerminarz();

            //liga.ZapisXml("serializacjaPO");

            /*Liga? kopiaKlasy = Liga.OdczytXml("serializacjaPO"); if (kopiaKlasy is not null)
            {
                kopiaKlasy.Zespoly.ForEach(el => Console.Write($"{el.Nazwa} "));
            }*/

            liga.DodajWynik(new Wynik(liga.Terminarz[0], new List<int>(new int[] { 0, 3 }),
            new List<Gol>(new Gol[] { new Gol(p8, p7, "10", TypBramki.zGry), new Gol(p8, "46", TypBramki.Karny), new Gol(p11, p10, "87", TypBramki.zGry) }), 
            new List<Kartka>(), new List<Zmiana>(), 10000, sklad4, sklad1));

            //Console.WriteLine(liga.Wyniki[1].DokladniejszyWynik());

            liga.DodajWynik(new Wynik(liga.Terminarz[0], new List<int>(new int[] { 0, 1 }),
            new List<Gol>(new Gol[] { new Gol(p31, p32, "66", TypBramki.zGry)}),
            new List<Kartka>(), new List<Zmiana>(), 7000, sklad2, sklad3));

            //liga.DodajWynik(new Wynik(liga.Terminarz[0], new List<int>(new int[] { 0, 1 }),
            //new List<Gol>(new Gol[] { new Gol(p8, "66", TypBramki.Karny) }),
            //new List<Kartka>(), new List<Zmiana>(), 79000, sklad3, sklad1));

            //liga.DodajWynik(new Wynik(liga.Terminarz[0], new List<int>(new int[] { 1, 2 }),
            //new List<Gol>(new Gol[] { new Gol(p8, p9, "66", TypBramki.zGry), new Gol(p9, p8, "70", TypBramki.zGry), new Gol(p20, "85", TypBramki.Karny) }),
            //new List<Kartka>(), new List<Zmiana>(), 79000, sklad2, sklad1));


            liga.WyswietlTabele();
            //liga.WyswietlKlasyfikacjeStrzelcow();
            //liga.WyswietlKlasyfikacjeAsystentow();
            //liga.WyswietlWyniki();
            //liga.WyswietlTerminarz();
            /*Druzyna d5 = new Druzyna("Cocojambo Warszawa", sklad1, trener1, s1, terminy);

            List<DateTime> terminy2 = new List<DateTime>(new DateTime[] { new DateTime(2021, 1, 6, 18, 0, 0), new DateTime(2021, 1, 7, 18, 0, 0),
                new DateTime(2021, 1, 13, 18, 0, 0), new DateTime(2021, 1, 14, 18, 0, 0), new DateTime(2021, 1, 20, 18, 0, 0),
                new DateTime(2021, 1, 21, 18, 0, 0), new DateTime(2021, 1, 27, 18, 0, 0), new DateTime(2021, 1, 28, 18, 0, 0),
                new DateTime(2021, 2, 3, 18, 0, 0), new DateTime(2021, 2, 4, 18, 0, 0), new DateTime(2021, 2, 10, 18, 0, 0),
                new DateTime(2021, 2, 11, 18, 0, 0)});

            List<DateTime> terminys3 = new List<DateTime>(new DateTime[] { new DateTime(2021, 1, 6, 18, 0, 0),
                new DateTime(2021, 1, 13, 18, 0, 0), new DateTime(2021, 1, 20, 18, 0, 0),
                new DateTime(2021, 1, 27, 18, 0, 0),
                new DateTime(2021, 2, 3, 18, 0, 0),new DateTime(2021, 2, 10, 18, 0, 0), });

            List<DateTime> terminys4 = new List<DateTime>(new DateTime[] { new DateTime(2021, 1, 7, 18, 0, 0),
                new DateTime(2021, 1, 14, 18, 0, 0), new DateTime(2021, 1, 21, 18, 0, 0),
                new DateTime(2021, 1, 28, 18, 0, 0),
                new DateTime(2021, 2, 4, 18, 0, 0),new DateTime(2021, 2, 11, 18, 0, 0), });

            SedziaGlowny sg3 = new SedziaGlowny("Szymon", "Marciniak", new DateTime(1990, 12, 1), terminys3);
            SedziaGlowny sg4 = new SedziaGlowny("Kevin", "Ortega", new DateTime(1980, 1, 19), terminys4);

            List<SedziaGlowny> sedziowieGlowni2 = new List<SedziaGlowny>(new SedziaGlowny[] { sg3, sg4 });

            SedziaBoczny sb5 = new SedziaBoczny("Adam", "Nowak", new DateTime(1986, 12, 19), terminys3);
            SedziaBoczny sb6 = new SedziaBoczny("Jan", "Kowalski", new DateTime(1991, 5, 19), terminys3);
            SedziaBoczny sb7 = new SedziaBoczny("Piotr", "Kowal", new DateTime(1997, 1, 5), terminys4);
            SedziaBoczny sb8 = new SedziaBoczny("Zbigniew", "Stonoga", new DateTime(1969, 4, 27), terminys4);

            List<SedziaBoczny> sedziowieBoczni2 = new List<SedziaBoczny> { sb5, sb6, sb7, sb8 };

            liga.NowySezon(new List<Druzyna>(new Druzyna[] {d5}), terminy2, sedziowieGlowni2, sedziowieBoczni2);

            liga.GenerujTerminarz();
            liga.WyswietlTabele();
            liga.WyswietlTerminarz();
            //liga.WyswietlTabele();
            */


        }
    }
}
