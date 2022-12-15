using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OglasiPolovniAuti
{
    internal class ModelVozila
    {
        public int Sifra { get; set; }
        public string ModelAuta { get; set; }
        public ModelVozila(int sifra, string model)
        {
            Sifra = sifra;
            ModelAuta = model;
        }
    }
}
