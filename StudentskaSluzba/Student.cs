using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentskaSluzba
{
    internal class Student
    {
        public int Id { get; set; }
        public string BrIndexa { get; set; }
        public string Prezime { get; set; }
        public string Ime { get; set; }
        public string Grad { get; set; }
        public Student(int id, string brIndexa, string prezime, string ime, string grad)
        {
            Id = id;
            BrIndexa = brIndexa;
            Prezime = prezime;
            Ime = ime;
            Grad = grad;
        }
    }
}
