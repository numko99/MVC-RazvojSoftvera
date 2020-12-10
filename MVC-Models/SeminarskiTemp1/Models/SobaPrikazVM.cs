using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeminarskiTemp1.Models
{
    public class SobaPrikazVM
    {
        public class Row
        {
            public int ID { get; set; }
            public int BrojSobe { get; set; }
            public int BrojKreveta { get; set; }
            public List<string> stanari { get; set; }
        }
        public List<Row> sobe { get; set; }
    }
}
