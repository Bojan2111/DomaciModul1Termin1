using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentskaSluzba
{
    public class Predmet
    {
        public int Id { get; set; }
        public string NazivPredmeta { get; set; }
        public Predmet(int id, string nazivPredmeta)
        {
            Id = id;
            NazivPredmeta = nazivPredmeta;
        }
    }
}
