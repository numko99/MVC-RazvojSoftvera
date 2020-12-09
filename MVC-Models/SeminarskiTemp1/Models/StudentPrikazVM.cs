using SeminarskiTemp1.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeminarskiTemp1.Models
{
    public class StudentPrikazVM
    {
        public class Row
        {
            public Row(Student x)
            {
                ID = x.ID;
                Ime = x.Ime;
                Prezime = x.Prezime;

            }
            public int ID { get; set; }
            public string Ime { get; set; }
            public string Prezime { get; set; }
        }
        public string q { get; set; }
        public List<Row> studenti { get; set; }
    }
}
