using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvidencijaArtikala
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StavkaRacuna stavka1 = new StavkaRacuna("Laptop", 1, 98456.88);
            StavkaRacuna stavka2 = new StavkaRacuna("USB flash drive 16GB", 3, 1024);
            StavkaRacuna stavka3 = new StavkaRacuna("Podloga za misa", 8, 386.99);

            StavkaRacuna[] stavke = new StavkaRacuna[] {stavka1, stavka2, stavka3};
            int pdv = 23;

            double ukupnaCena = 0.0;

            foreach (StavkaRacuna stavka in stavke)
            {
                ukupnaCena += stavka.Kolicina * stavka.CenaPoKomadu;
            }

            double ukupnaCenaPDV = ukupnaCena + ukupnaCena * pdv / 100;

            Racun racun1 = new Racun(args[0], stavke, ukupnaCena, ukupnaCenaPDV);

            Ispis(racun1);

            Console.ReadKey();
        }

        public static void Ispis(Racun racun)
        {
            Console.WriteLine(racun.Prodavnica);
            Console.WriteLine("--------------------------------------------");
            foreach (StavkaRacuna stavka in racun.StavkeRacuna)
            {
                Console.WriteLine($"{stavka.NazivArtikla} -> {stavka.CenaPoKomadu}RSD x {stavka.Kolicina}");
            }
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine($"Ukupno bez PDV-a: {racun.UkupnaCena:0.##} RSD");
            Console.WriteLine($"Ukupno sa PDV-om: {racun.UkupnaCenaPDV:0.##} RSD");
        }
    }
}
