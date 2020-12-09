using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeminarskiTemp1.EntityModels
{
    public class Student
    {
        public int ID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string DatumRodjenja { get; set; }

        public int OpstinaID { get; set; }
        public Opstina Opstina { get; set; }

        public int FakultetID { get; set; }
        public Fakultet Fakultet { get; set; }

        public string BrojIndeksa { get; set; }
    }
}
