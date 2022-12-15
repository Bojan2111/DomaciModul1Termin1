using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentskaSluzba
{
    public class Nastavnik
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Zvanje { get; set; }

        public Nastavnik(int id, string ime, string prezime, string zvanje)
        {
            Id = id;
            Ime = ime;
            Prezime = prezime;
            Zvanje = zvanje;
        }
    }
}
