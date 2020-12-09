using SeminarskiTemp.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SeminarskiTemp.Models
{
    public class StudentPrikazVM
    {
        public string q { get; set; }
        public List<Student> studenti { get; set; }
    }
}