using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvidencijaArtikala2
{
    internal class Racun2
    {
        public string Prodavnica { get; set; }
        public StavkaRacuna2[] StavkeRacuna { get; set; }
        public double UkupnaCena { get; set; }
        public double UkupnaCenaPDV { get; set; }

        public Racun2(string prodavnica, StavkaRacuna2[] stavkeRacuna, double ukupnaCena, double ukupnaCenaPDV)
        {
            Prodavnica = prodavnica;
            StavkeRacuna = stavkeRacuna;
            UkupnaCena = ukupnaCena;
            UkupnaCenaPDV = ukupnaCenaPDV;
        }
    }
}
