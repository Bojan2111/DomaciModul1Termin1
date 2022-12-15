using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EvidencijaArtikala
{
    internal class StavkaRacuna
    {
        public string NazivArtikla { get; set; }
        public int Kolicina { get; set; }
        public double CenaPoKomadu { get; set; }

        //public double PDV = 23;

        public StavkaRacuna(string nazivArtikla, int kolicina, double cenaPoKomadu)
        {
            NazivArtikla = nazivArtikla;
            Kolicina = kolicina;
            CenaPoKomadu = cenaPoKomadu;
        }
        
        //public double UkupnaCena()
        //{ return CenaPoKomadu * Kolicina;}

        //public double UkupnaCenaPDV()
        //{ return UkupnaCena() + UkupnaCena() * PDV / 100 ; }
    }
}
