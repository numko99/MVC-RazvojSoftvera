using Microsoft.EntityFrameworkCore;
using SeminarskiTemp.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SeminarskiTemp
{
    public class MojDBcontext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Opstina> Opstinas { get; set; }
        public DbSet<Fakultet> Fakultets { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@" Server=.;
                                        Database=MVC_Modeli;   
                                        Trusted_Connection=true;
                                        MultipleActiveResultSets=true; ");



        }
    }
}