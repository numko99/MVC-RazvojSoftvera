using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeminarskiTemp1.Models
{
    public class StudentDodajVM
    {
        public int ID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public int OpstinaID { get; set; }
        public int FakultetID { get; set; }
        public string BrojIndeksa { get; set; }
        public DateTime Datum { get; set; }
        public List<SelectListItem> Opstine;
        public List<SelectListItem> Fakulteti;
    }
}
