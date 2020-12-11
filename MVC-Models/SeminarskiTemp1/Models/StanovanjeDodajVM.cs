using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeminarskiTemp1.Models
{
    public class StanovanjeDodajVM
    {
        public int ID { get; set; }
        public int StudentID { get; set; }
        public List<SelectListItem> studenti { get; set; }

        public int SobaID { get; set; }

        public string AkademskaGodina { get; set; }
        public List<SelectListItem> sobe { get; set; }
    }
}
