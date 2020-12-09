using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeminarskiTemp1.Models
{
    public class StudentDetaljiVM
    {
        public int ID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string DatumRodjenja { get; set; }
        public string Opstina { get; set; }
        public string Fakultet { get; set; }
        public string BrojIndeksa { get; set; }
    }
}
