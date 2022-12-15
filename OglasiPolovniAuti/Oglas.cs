using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OglasiPolovniAuti
{
    internal class Oglas
    {
        public int RedniBroj { get; set; }
        public Guid Sifra { get; set; }
        public string Naslov { get; set; }
        public ModelVozila Model { get; set; }
        public double Cena { get; set; }
        public int GodinaProizvodnje { get; set; }
        public ArrayList Oprema { get; set; }

        public Oglas(int redniBroj, Guid sifra, string naslov, double cena, int godinaProizvodnje, ArrayList oprema)
        {
            RedniBroj= redniBroj;
            Sifra = sifra;
            Naslov = naslov;
            Cena = cena;
            GodinaProizvodnje = godinaProizvodnje;
            Oprema = oprema;
        }
        public Oglas(int redniBroj, Guid sifra, string naslov, ModelVozila model, double cena, int godinaProizvodnje, ArrayList oprema)
        {
            RedniBroj = redniBroj;
            Sifra = sifra;
            Naslov = naslov;
            Model = model;
            Cena = cena;
            GodinaProizvodnje = godinaProizvodnje;
            Oprema = oprema;
        }

    }
}
