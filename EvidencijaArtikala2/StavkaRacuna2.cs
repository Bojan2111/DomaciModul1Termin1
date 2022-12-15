using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvidencijaArtikala2
{
    internal class StavkaRacuna2
    {
        public string NazivArtikla { get; set; }
        public int Kolicina { get; set; }
        public string JedinicaMere { get; set; }
        public double CenaPoKomadu { get; set; }
        public int PDV { get; set; }
        public bool Akcija { get; set; }

        public StavkaRacuna2(string nazivArtikla, int kolicina, string jedinicaMere, double cenaPoKomadu, int pDV, bool akcija)
        {
            NazivArtikla = nazivArtikla;
            Kolicina = kolicina;
            JedinicaMere = jedinicaMere;
            CenaPoKomadu = cenaPoKomadu;
            PDV = pDV;
            Akcija = akcija;
        }
    }
}
