using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentskaSluzba
{
    internal class Program
    {
        static void Main()
        {
            string nastavniciTxt = "1,Petar,Petrović,Docent\n2,Jovan,Jovanović,Docent\n3,Marko,Marković,Asistent\n4,Nikola,Nikolić,Redovni Profesor\n5,Lazar,Lazić,Asistent";
            string predmetiTxt = "1,Matematika\n2,Fizika\n3,Elektrotehnika\n4,Informatika";
            string studentiTxt = "1,E1 01 / 2016,Jovanović,Zarko,Loznica\n2,E2 02 / 2015,Prosinečki,Strahinja,NoviSad\n3,E2 33 / 2016,Savić,Nebojša,Inđija\n4,SW 36 / 2013,Sekulić,Ana,Niš\n5,E2 157 / 2013,Nedeljković,Vuk,NoviSad\n6,E1 183 / 2013,Klainić,Jovana,Sombor\n7,E2 44 / 2015,Bojana,Panić,Sr.Mitrovica";

            Nastavnik[] nastavnici;
            Predmet[] predmeti;
            Student[] studenti;

            UcitajNastavnike(nastavniciTxt, out nastavnici);
            Console.WriteLine("----------------------------------------------------------");
            UcitajPredmete(predmetiTxt, out predmeti);
            Console.WriteLine("----------------------------------------------------------");
            UcitajStudente(studentiTxt, out studenti);
            Console.WriteLine("----------------------------------------------------------");
            IspisivanjeSvihNastavnika(nastavnici);
            Console.WriteLine("----------------------------------------------------------");
            IspisivanjeSvihPredmeta(predmeti);
            Console.WriteLine("----------------------------------------------------------");
            IspisivanjeSvihStudenata(studenti);
            Console.WriteLine("----------------------------------------------------------");
            IspisivanjeNastavnikaPoIdentifikatoru(nastavnici, 1);
            Console.WriteLine("----------------------------------------------------------");
            IspisivanjePredmetaPoIndikatoru(predmeti, 2);
            Console.WriteLine("----------------------------------------------------------");
            IspisivanjeStudenataPoSmeru(studenti, "E2");
            Console.WriteLine("----------------------------------------------------------");
            StatistikaUpisaPoGodinama(studenti);

            Console.ReadKey();
        }

        public static void UcitajNastavnike(string nastavniciTxt, out Nastavnik[] nastavnici)
        {
            string[] nastavniciNiz = nastavniciTxt.Split('\n');
            nastavnici = new Nastavnik[nastavniciNiz.Length];
            for (int i = 0; i < nastavniciNiz.Length; i++)
            {
                string[] temp = nastavniciNiz[i].Split(',');
                Nastavnik nastavnik = new Nastavnik(int.Parse(temp[0]), temp[1], temp[2], temp[3]);
                nastavnici[i] = nastavnik;
            }
        }
        public static void UcitajStudente(string studentiTxt, out Student[] studenti)
        {
            string[] studentiNiz = studentiTxt.Split('\n');
            studenti = new Student[studentiNiz.Length];
            for (int i = 0; i < studentiNiz.Length; i++)
            {
                string[] temp = studentiNiz[i].Split(',');
                Student student = new Student(int.Parse(temp[0]), temp[1], temp[2], temp[3], temp[4]);
                studenti[i] = student;
            }
        }

        public static void UcitajPredmete(string predmetiTxt, out Predmet[] predmeti)
        {
            string[] predmetiNiz = predmetiTxt.Split('\n');
            predmeti = new Predmet[predmetiNiz.Length];
            for (int i = 0; i < predmetiNiz.Length; i++)
            {
                string[] temp = predmetiNiz[i].Split(',');
                Predmet predmet = new Predmet(int.Parse(temp[0]), temp[1]);
                predmeti[i] = predmet;
            }
        }

        public static void IspisivanjeSvihNastavnika(Nastavnik[] nastavnici)
        {
            foreach (Nastavnik nastavnik in nastavnici)
            {
                Console.WriteLine($"ID: {nastavnik.Id}\nIme i prezime: {nastavnik.Ime} {nastavnik.Prezime}");
            }
        }

        public static void IspisivanjeSvihPredmeta(Predmet[] predmeti)
        {
            foreach (Predmet predmet in predmeti)
            {
                Console.WriteLine($"ID predmeta: {predmet.Id}\nNaziv predmeta: {predmet.NazivPredmeta}");
            }
        }
        public static void IspisivanjeSvihStudenata(Student[] studenti)
        {
            foreach (Student student in studenti)
            {
                Console.WriteLine($"ID: {student.Id}\nIndex: {student.BrIndexa}\nIme i prezime: {student.Ime} {student.Prezime}\nGrad: {student.Grad}");
            }
        }
        public static void IspisivanjeNastavnikaPoIdentifikatoru(Nastavnik[] nastavnici, int id)
        {
            foreach (Nastavnik nastavnik in nastavnici)
            {
                if (nastavnik.Id == id)
                    Console.WriteLine($"Nastavnik sa ID brojem {id} je {nastavnik.Ime} {nastavnik.Prezime}");
            }
        }
        public static void IspisivanjePredmetaPoIndikatoru(Predmet[] predmeti, int id)
        {
            foreach (Predmet predmet in predmeti)
            {
                if (predmet.Id == id)
                    Console.WriteLine($"Predmet sa ID brojem {id} je {predmet.NazivPredmeta}");
            }
        }
        public static void IspisivanjeStudenataPoSmeru(Student[] studenti, string smer)
        {
            Console.WriteLine($"Studenti na smeru {smer} su:");
            foreach (Student student in studenti)
            {
                if (student.BrIndexa.Contains(smer))
                    Console.WriteLine($"ID: {student.Id}\nIndex: {student.BrIndexa}\nIme i prezime: {student.Ime} {student.Prezime}\nGrad: {student.Grad}");
            }
        }
        public static void StatistikaUpisaPoGodinama(Student[] studenti)
        {
            // Ovu funkciju jos trebam doraditi, ne izbacuje mi kako valja.
            string[] godineUpisa = new string[studenti.Length];
            string[] godineUpisaTest = { "2013", "2014", "2015", "2016" };
            int[] brojUpisa = new int[godineUpisaTest.Length];
            
            for (int i = 0; i < studenti.Length; i++)
            {
                godineUpisa[i] = studenti[i].BrIndexa.Split('/')[1];
            }

            for (int i = 0; i < godineUpisaTest.Length; i++)
            {
                for (int j = 0; j < godineUpisa.Length;j++)
                {
                    if (godineUpisaTest[i].Equals(godineUpisa[j]))
                    {
                        Console.WriteLine("u testu sam");
                        brojUpisa[i] += 1;
                    }
                }
            }
            for (int i = 0; i < godineUpisaTest.Length; i++)
            {
                if (brojUpisa[i] == 0)
                    Console.WriteLine($"{godineUpisaTest[i]} nije bilo upisanih studenata.");
                Console.WriteLine($"{godineUpisaTest[i]}. godine je upisano {brojUpisa[i]} studenata");
            }
        }
    }
}
