using Microsoft.EntityFrameworkCore;
using SeminarskiTemp1.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeminarskiTemp1.EF
{
    public class MojDBContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Opstina> Opstinas { get; set; }
        public DbSet<Fakultet> Fakultets { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@" Server=.;
                                        Database=Mvc_Dot_Net;   
                                        Trusted_Connection=true;
                                        MultipleActiveResultSets=true; ");
        


        }
    }
}

