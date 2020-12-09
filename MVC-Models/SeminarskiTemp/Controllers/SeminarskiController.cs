using Microsoft.EntityFrameworkCore;
using SeminarskiTemp.EntityModels;
using SeminarskiTemp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SeminarskiTemp.Controllers
{
    public class SeminarskiController : Controller
    {
        // GET: Seminarski
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Prikaz(string student)
        {
            MojDBcontext dBcontext = new MojDBcontext();
            var studenti = dBcontext.Students.Include("Opstina").Include("Fakultet").
                Where(x => student == null || x.Ime.StartsWith(student)).ToList();
            //ViewData["studenti"] = studenti;
            //ViewData["q"] = student;

            StudentPrikazVM m = new StudentPrikazVM();
            m.studenti = studenti;
            m.q = student;
            return View(m);
        }

    
        public ActionResult Uredi(int StudentID = 0)
        {
            MojDBcontext mojDBcontext = new MojDBcontext();
            var opstine = mojDBcontext.Opstinas.ToList();
            var fakulteti = mojDBcontext.Fakultets.ToList();

            var studenti = StudentID == 0 ? new Student() : mojDBcontext.Students.Find(StudentID);
            ViewData["student"] = studenti;
            ViewData["opstine"] = opstine;
            ViewData["fakulteti"] = fakulteti;

            return View();
        }
        public ActionResult Snimi(int id, string Ime, string Prezime, DateTime Datum, int Opstina, int Fakultet, string Indeks)
        {
            MojDBcontext dbContext = new MojDBcontext();
            Student student;
            if (id == 0)
            {
                student = new Student();
                dbContext.Add(student);
                TempData["Ime"] = "Uspjesno ste DODALI studenta " + Ime;
            }
            else
            {
                student = dbContext.Students.Find(id);
                TempData["Ime"] = "Uspjesno ste UREDILI studenta " + Ime;

            }
            student.Ime = Ime;
            student.Prezime = Prezime;
            student.DatumRodjenja = Datum;
            student.OpstinaID = Opstina;
            student.FakultetID = Fakultet;
            student.BrojIndeksa = Indeks;

            dbContext.SaveChanges();
            return Redirect(url:"/Seminarski/Poruka");
        }
        public ActionResult Detalji(int student)
        {
            MojDBcontext mojDBcontext = new MojDBcontext();
            var opstine = mojDBcontext.Opstinas.ToList();
            var fakulteti = mojDBcontext.Fakultets.ToList();

            Student studenti = mojDBcontext.Students.Find(student);
            ViewData["student"] = studenti;
            ViewData["opstine"] = opstine;
            ViewData["fakulteti"] = fakulteti;

            return View();
        }



        public ActionResult Obrisi(int ID)
        {

            MojDBcontext dBcontext = new MojDBcontext();

            Student student = dBcontext.Students.Find(ID);
            dBcontext.Remove(student);
            dBcontext.SaveChanges();
            TempData["Ime"] = "Uspjesno ste Obrisali studenta " + student.Ime;
            return Redirect(url: "/Seminarski/Poruka");
        }
        public ActionResult Poruka()
        {

            return View();
        }


    }
}