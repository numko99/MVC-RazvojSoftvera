using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeminarskiTemp1.EntityModels
{
    public class Stanovanje
    {
        public int ID { get; set; }
        public Student student { get; set; }
        public int studentID { get; set; }
        public Soba soba { get; set; }
        public int sobaID { get; set; }
        public string AkademskaGodina { get; set; }
    }
}
