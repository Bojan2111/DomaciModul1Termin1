using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace OglasiPolovniAuti
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var oglasi = new ArrayList();
            oglasi.Add(new Oglas(1, Guid.NewGuid(), "Odlican porodicni auto", 3000, 2011, OdabirOpreme(3)));
            oglasi.Add(new Oglas(2, Guid.NewGuid(), "Gradski auto u perfektnom stanju", 8000, 2013, OdabirOpreme(10)));
            oglasi.Add(new Oglas(3, Guid.NewGuid(), "Oldtimer na prodaju", 22300, 1955, OdabirOpreme(12)));
            oglasi.Add(new Oglas(4, Guid.NewGuid(), "Rashodovan vojni dzip", 5800, 1993, OdabirOpreme(0)));
            oglasi.Add(new Oglas(5, Guid.NewGuid(), "Rashodovan vojni kamion", 15800, 1993, OdabirOpreme(0)));
            oglasi.Add(new Oglas(6, Guid.NewGuid(), "Oklopno vozilo - antikvitet", 25400, 1943, OdabirOpreme(13)));

            var modeli = new ArrayList();
            modeli.Add(new ModelVozila(1, "BMW"));
            modeli.Add(new ModelVozila(2, "Audi"));
            modeli.Add(new ModelVozila(3, "Toyota"));
            modeli.Add(new ModelVozila(4, "FAP"));
            modeli.Add(new ModelVozila(5, "VW"));
            modeli.Add(new ModelVozila(6, "Nissan"));

            IspisSvihOglasa(oglasi);
            IspisDetaljaOVozilu(1, oglasi);
            IspisDetaljaOVozilu(4, oglasi);
            IspisOglasaPoGodini(1943, oglasi);
            IspisOglasaPoGodini(1993, oglasi);
            IspisVozilaOpsegCene(oglasi, 2500, 10000);
            IspisVozilaOpsegCene(oglasi, 3700, "veca");
            IspisVozilaOpsegCene(oglasi, 13700, "manja");
            IspisVozilaSaOpremom("klima", oglasi);
            IzmenaOsnovnihDetalja(oglasi, 5, "Super izdrzljivi kamion", 15700, 1993);
            IzmenaOpremeVozila(oglasi, 2, "servo volan", "automatski menjac");
            PromenaSkupaOpreme(oglasi, 3, OdabirOpreme(4));
            DodavanjeOpreme(oglasi, 3, "manuelni brisaci");
            BrisanjeOglasa(oglasi, 5);

            /*
Zadatak 2. Potrebno je izmeniti postojeću aplikaciju tako da se oglas sadrži informacije o modelu vozila
koje se prodaje. Model vozila predstavlja klasifikaciju polovnih vozila unutar informacionog sistema, pri
čemu je pomenuta klasifikacija opisana: šifrom i nazivom. Svojstvo šifra predstavlja jedinstveni
identifikator modela.
Programu je potrebno dodati sledeće funkcionalnosti:

izmena postojećeg oglasa
unos novog oglasa
izmena postojeće klasifikacije za marku i model
unos nove klasifikacije za model
brisanje klasifikacije za model
             */
            Console.ReadKey();
        }
        public static ArrayList OdabirOpreme(int start)
        {
            string opremaTekst = "ABS,ESP,alarm,airbag,klima,servo volan,putni računar,tempomat,zatamljena stakla,maglenke,CD,DVD,parking senzori,električna stakla";
            string[] opremaNiz = opremaTekst.Split(',');
            var opremaAuto = new ArrayList();
            if (start >= opremaNiz.Length - 6)
                start -= 6;
            for (int i = start; i < start + 5; i++)
            {
                opremaAuto.Add(opremaNiz[i]);
            }

            return opremaAuto;
        }
        public static void IspisSvihOglasa(ArrayList oglasi)
        {
            Console.WriteLine("Ispis svih oglasa:\n");
            foreach (Oglas oglas in oglasi)
            {
                Console.WriteLine($"Redni Broj: {oglas.RedniBroj}\n" +
                    $"Sifra: {oglas.Sifra}\n" +
                    $"Naslov: {oglas.Naslov}\n" +
                    $"Cena: {oglas.Cena}EUR\n");
                Console.WriteLine("\n--------------------------------------------------------");
            }
            Console.WriteLine("---------------------- Kraj funkcije --------------\n");
        }
        public static void IspisOglasaPoGodini(int godina, ArrayList oglasi)
        {
            Console.WriteLine($"Oglasi za vozila proizvedena u {godina}. godini:\n");
            foreach (Oglas oglas in oglasi)
            {
                if (oglas.GodinaProizvodnje == godina)
                {
                    Console.WriteLine($"Redni broj: {oglas.RedniBroj}\n" +
                        $"Sifra: {oglas.Sifra}\n" +
                        $"Naslov: {oglas.Naslov}\n" +
                        $"Cena: {oglas.Cena}EUR\n" +
                        $"Godina proizvodnje: {oglas.GodinaProizvodnje}");
                    Console.WriteLine("\n--------------------------------------------------------");
                }
            }
            Console.WriteLine("---------------------- Kraj funkcije --------------\n");
        }
        public static void IspisDetaljaOVozilu(int redniBroj, ArrayList oglasi)
        {
            Console.WriteLine($"Detalji o vozilu iz oglasa pod rednim brojem {redniBroj}:\n");
            foreach (Oglas oglas in oglasi)
            {
                if (oglas.RedniBroj == redniBroj)
                {
                    Console.WriteLine($"Sifra: {oglas.Sifra}\n" +
                        $"Naslov: {oglas.Naslov}\n" +
                        $"Cena: {oglas.Cena}EUR\n" +
                        $"Godina proizvodnje: {oglas.GodinaProizvodnje}");
                    Console.Write($"Oprema: {oglas.Oprema[0]}");
                    for (int i = 1; i < oglas.Oprema.Count; i++)
                    {
                        Console.Write($", {oglas.Oprema[i]}");
                    }
                    Console.WriteLine("\n--------------------------------------------------------");
                    break;
                }
            }
            Console.WriteLine("---------------------- Kraj funkcije --------------\n");
        }
        public static void IzmenaOsnovnihDetalja(ArrayList oglasi, int redniBroj, string naslov, double cena, int godina)
        {
            foreach (Oglas oglas in oglasi)
            {
                if (oglas.RedniBroj == redniBroj)
                {
                    Console.WriteLine("Izmena osnovnih detalja o vozilu:\n");
                    oglas.Naslov = naslov;
                    oglas.Cena = cena;
                    oglas.GodinaProizvodnje = godina;
                    Console.WriteLine($"Podaci oglasa pod rednim brojem {redniBroj} su uspesno izmenjeni:");

                    Console.WriteLine($"Sifra: {oglas.Sifra}\n" +
                        $"Naslov: {oglas.Naslov}\n" +
                        $"Cena: {oglas.Cena}EUR\n" +
                        $"Godina proizvodnje: {oglas.GodinaProizvodnje}");
                    Console.Write($"Oprema: {oglas.Oprema[0]}");
                    for (int i = 1; i < oglas.Oprema.Count; i++)
                    {
                        Console.Write($", {oglas.Oprema[i]}");
                    }
                    Console.WriteLine("\n--------------------------------------------------------");
                    break;
                }
            }
        }
        public static void IzmenaOpremeVozila(ArrayList oglasi, int redniBroj, string staraStavka, string novaStavka)
        {
            foreach (Oglas oglas in oglasi)
            {
                if (oglas.RedniBroj == redniBroj)
                {
                    Console.WriteLine("Izmena opreme:\n");
                    for (int i = 0; i < oglas.Oprema.Count; i++)
                    {
                        if (oglas.Oprema[i].ToString() == staraStavka)
                            oglas.Oprema[i] = novaStavka;
                    }
                    Console.WriteLine($"Podaci oglasa pod rednim brojem {redniBroj} su uspesno izmenjeni:");

                    Console.WriteLine($"Sifra: {oglas.Sifra}\n" +
                        $"Naslov: {oglas.Naslov}\n" +
                        $"Cena: {oglas.Cena}EUR\n" +
                        $"Godina proizvodnje: {oglas.GodinaProizvodnje}");
                    Console.Write($"Oprema: {oglas.Oprema[0]}");
                    for (int i = 1; i < oglas.Oprema.Count; i++)
                    {
                        Console.Write($", {oglas.Oprema[i]}");
                    }
                    Console.WriteLine("\n--------------------------------------------------------");
                    break;
                }
            }
        }
        public static void IspisVozilaOpsegCene(ArrayList oglasi, double cena, string odnos)
        {
            if (odnos == "veca")
            {
                Console.WriteLine($"Oglasi sa cenom vecom od {cena} EUR:\n");
                foreach (Oglas oglas in oglasi)
                {

                    if (oglas.Cena >= cena)
                    {
                        Console.WriteLine($"Redni broj: {oglas.RedniBroj}\n" +
                            $"Sifra: {oglas.Sifra}\n" +
                            $"Naslov: {oglas.Naslov}\n" +
                            $"Cena: {oglas.Cena}EUR\n");
                        Console.WriteLine("\n--------------------------------------------------------");
                    }
                }
            }
            else if (odnos == "manja")
            {
                Console.WriteLine($"Oglasi sa cenom manjom od {cena} EUR:\n");
                foreach (Oglas oglas in oglasi)
                {

                    if (oglas.Cena <= cena)
                    {
                        Console.WriteLine($"Redni broj: {oglas.RedniBroj}\n" +
                            $"Sifra: {oglas.Sifra}\n" +
                            $"Naslov: {oglas.Naslov}\n" +
                            $"Cena: {oglas.Cena}EUR\n");
                        Console.WriteLine("\n--------------------------------------------------------");
                    }
                }
            }
            Console.WriteLine("---------------------- Kraj funkcije --------------\n");
        }
        public static void IspisVozilaOpsegCene(ArrayList oglasi, double cena1, double cena2)
        {
            Console.WriteLine($"Oglasi sa cenom izmedju {cena1} i {cena2} EUR:\n");
            foreach (Oglas oglas in oglasi)
            {
                if (oglas.Cena >= cena1 && oglas.Cena <= cena2)
                {
                    Console.WriteLine($"Redni broj: {oglas.RedniBroj}\n" +
                        $"Sifra: {oglas.Sifra}\n" +
                        $"Naslov: {oglas.Naslov}\n" +
                        $"Cena: {oglas.Cena}EUR\n");
                    Console.WriteLine("\n--------------------------------------------------------");
                }
            }
            Console.WriteLine("---------------------- Kraj funkcije --------------\n");
        }
        public static void IspisVozilaSaOpremom(string oprema, ArrayList oglasi)
        {
            Console.WriteLine($"Oglasi vozila sa {oprema}:\n");
            foreach (Oglas oglas in oglasi)
            {
                if (oglas.Oprema.Contains(oprema))
                {
                    Console.WriteLine($"Redni broj: {oglas.RedniBroj}\n" +
                        $"Sifra: {oglas.Sifra}\n" +
                        $"Naslov: {oglas.Naslov}\n" +
                        $"Cena: {oglas.Cena}EUR\n");
                    Console.WriteLine("\n--------------------------------------------------------");
                }
            }
            Console.WriteLine("---------------------- Kraj funkcije --------------\n");
        }
        public static void PromenaSkupaOpreme(ArrayList oglasi, int redniBroj, ArrayList oprema)
        {
            foreach (Oglas oglas in oglasi)
            {
                if (oglas.RedniBroj == redniBroj)
                {
                    Console.WriteLine("Izmena skupa opreme:\n");
                    oglas.Oprema = oprema;
                    Console.WriteLine($"Podaci oglasa pod rednim brojem {redniBroj} su uspesno izmenjeni:");

                    Console.WriteLine($"Sifra: {oglas.Sifra}\n" +
                        $"Naslov: {oglas.Naslov}\n" +
                        $"Cena: {oglas.Cena}EUR\n" +
                        $"Godina proizvodnje: {oglas.GodinaProizvodnje}");
                    Console.Write($"Oprema: {oglas.Oprema[0]}");
                    for (int i = 1; i < oglas.Oprema.Count; i++)
                    {
                        Console.Write($", {oglas.Oprema[i]}");
                    }
                    Console.WriteLine("\n--------------------------------------------------------");
                    break;
                }
            }
        }
        public static void DodavanjeOpreme(ArrayList oglasi, int redniBroj, string oprema)
        {
            foreach (Oglas oglas in oglasi)
            {
                if (oglas.RedniBroj == redniBroj)
                {
                    Console.WriteLine($"Dodavanje opreme {oprema}:\n");
                    oglas.Oprema.Add(oprema);
                    Console.WriteLine($"Podaci oglasa pod rednim brojem {redniBroj} su uspesno izmenjeni:");

                    Console.WriteLine($"Sifra: {oglas.Sifra}\n" +
                        $"Naslov: {oglas.Naslov}\n" +
                        $"Cena: {oglas.Cena}EUR\n" +
                        $"Godina proizvodnje: {oglas.GodinaProizvodnje}");
                    Console.Write($"Oprema: {oglas.Oprema[0]}");
                    for (int i = 1; i < oglas.Oprema.Count; i++)
                    {
                        Console.Write($", {oglas.Oprema[i]}");
                    }
                    Console.WriteLine("\n--------------------------------------------------------");
                    break;
                }
            }
        }
        public static void BrisanjeOglasa(ArrayList oglasi, int redniBroj)
        {
            foreach (Oglas oglas in oglasi)
            {
                if (oglas.RedniBroj == redniBroj)
                {
                    oglasi.Remove(oglas);
                    break;
                }
            }
        }
        

    }
}
