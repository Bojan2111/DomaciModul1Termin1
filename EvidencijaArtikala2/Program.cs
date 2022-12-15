using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvidencijaArtikala2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StavkaRacuna2 stavka1 = new StavkaRacuna2("Jogurt", 2, "l", 123.45, 13, false);
            StavkaRacuna2 stavka2 = new StavkaRacuna2("Brasno", 3, "kg", 78.99, 10, false);
            StavkaRacuna2 stavka3 = new StavkaRacuna2("Cokolada", 1, "kom", 83.15, 20, true);

            StavkaRacuna2[] stavke = new StavkaRacuna2[] { stavka1, stavka2, stavka3 };

            double ukupnaCena = 0.0;
            double ukupnaCenaPDV = 0.0;

            foreach (StavkaRacuna2 stavka in stavke)
            {
                double akcijskaCena = stavka.Akcija ? stavka.CenaPoKomadu * 0.9 : stavka.CenaPoKomadu;
                double finalnaCena = akcijskaCena * stavka.Kolicina;
                ukupnaCena += finalnaCena;
                ukupnaCenaPDV += finalnaCena + finalnaCena * stavka.PDV / 100;
            }

            Racun2 racun = new Racun2(args[0], stavke, ukupnaCena, ukupnaCenaPDV);

            Ispis(racun);

            Console.ReadKey();
        }

        public static void Ispis(Racun2 racun)
        {
            Console.WriteLine(racun.Prodavnica);
            Console.WriteLine("-----------------------------------");
            foreach (StavkaRacuna2 stavka in racun.StavkeRacuna)
            {
                string akcija = stavka.Akcija ? " akcija -10%" : "";
                Console.WriteLine($"{stavka.NazivArtikla} {stavka.Kolicina}{stavka.JedinicaMere} x {stavka.CenaPoKomadu} +{stavka.PDV}%{akcija}");
            }
            Console.WriteLine("-----------------------------------");
            Console.WriteLine($"Ukupna cena bez PDV-a: {racun.UkupnaCena:0.##} RSD");
            Console.WriteLine($"Ukupna cena sa PDV-om: {racun.UkupnaCenaPDV:0.##} RSD");
        }
    }
}
