using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvidencijaArtikala
{
    internal class Racun
    {
        public string Prodavnica { get; set; }
        public StavkaRacuna[] StavkeRacuna { get; set; }
        public double UkupnaCena { get; set; }
        public double UkupnaCenaPDV { get; set; }

        public Racun(string prodavnica, StavkaRacuna[] stavkeRacuna, double ukupnaCena, double ukupnaCenaPDV)
        {
            Prodavnica = prodavnica;
            StavkeRacuna = stavkeRacuna;
            UkupnaCena = ukupnaCena;
            UkupnaCenaPDV = ukupnaCenaPDV;
        }
    }
}
