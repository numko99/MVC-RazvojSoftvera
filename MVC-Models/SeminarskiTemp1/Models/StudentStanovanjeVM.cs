using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeminarskiTemp1.Models
{
    public class StudentStanovanjeVM
    {
        public string ImeStudenta { get; set; }
        public int BrojSobe { get; set; }
        public string AkademskaGodina { get; set; }
        public class Row
        {
            public string Imecimera { get; set; }
        }
        public List<Row> cimeri { get; set; }
    }
}
