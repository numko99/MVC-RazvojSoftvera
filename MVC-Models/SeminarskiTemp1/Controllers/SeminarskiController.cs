using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SeminarskiTemp1.EF;
using SeminarskiTemp1.EntityModels;
using SeminarskiTemp1.Models;

namespace SeminarskiTemp1.Controllers
{
    public class SeminarskiController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public ActionResult Prikaz(string student)
        {
            MojDBContext dBcontext = new MojDBContext();
            var studenti = dBcontext.Students.
                Where(x => student == null || x.Ime.StartsWith(student))
            .Select(x => new StudentPrikazVM.Row(x)).ToList();

            StudentPrikazVM m = new StudentPrikazVM();
            m.studenti = studenti;
            m.q = student;
            return View(m);
        }


        public ActionResult Uredi(int StudentID)
        {
            MojDBContext mojDBcontext = new MojDBContext();
            List<SelectListItem> opstine = mojDBcontext.Opstinas.Select(a => new SelectListItem
            {

                Text = a.Naziv,
                Value = a.ID.ToString()
            }).ToList();
            List<SelectListItem> fakulteti = mojDBcontext.Fakultets.Select(a => new SelectListItem
            {
                Text = a.Naziv,
                Value = a.ID.ToString()
            }).ToList();


            StudentDodajVM studenti = StudentID == 0 ? new StudentDodajVM() : mojDBcontext.Students.Where(a => StudentID == a.ID).
                Select(a => new StudentDodajVM
                {

                    ID = a.ID,
                    Ime = a.Ime,
                    Prezime = a.Prezime,
                    OpstinaID = a.OpstinaID,
                    FakultetID = a.FakultetID,
                    BrojIndeksa = a.BrojIndeksa,
                    Datum = Convert.ToDateTime(a.DatumRodjenja)
                }).Single();
            studenti.Opstine = opstine;
            studenti.Fakulteti = fakulteti;
            return View(studenti);
        }

        public ActionResult Snimi(StudentDodajVM admir)
        {
            MojDBContext dbContext = new MojDBContext();
            Student student;
            if (admir.ID == 0)
            {
                student = new Student();
                dbContext.Add(student);
                TempData["Ime"] = "Uspjesno ste dodali studenta " + admir.Ime;
            }
            else
            {
                student = dbContext.Students.Find(admir.ID);
                TempData["Ime"] = "Uspjesno ste UREDILI studenta " + admir.Ime;

            }
            student.Ime = admir.Ime;
            student.Prezime = admir.Prezime;
            student.OpstinaID = admir.OpstinaID;
            student.FakultetID = admir.FakultetID;
            student.BrojIndeksa = admir.BrojIndeksa;
            student.DatumRodjenja = admir.Datum.ToString();

            dbContext.SaveChanges();
            return Redirect(url: "/Seminarski/Poruka");
        }
        public ActionResult Detalji(int student)
        {
            MojDBContext mojDBcontext = new MojDBContext();

            StudentDetaljiVM studenti = mojDBcontext.Students.Where(a => student == a.ID).
                Select(x => new StudentDetaljiVM
                {
                    ID = x.ID,
                    Ime = x.Ime,
                    Prezime = x.Prezime,
                    DatumRodjenja = x.DatumRodjenja,
                    Opstina = x.Opstina.Naziv,
                    Fakultet = x.Fakultet.Naziv,
                    BrojIndeksa = x.BrojIndeksa

                }).Single();
            

            return View(studenti);
        }
        public IActionResult Stanovanje(int StudentID)
        {
            MojDBContext dBContext = new MojDBContext();
            StudentStanovanjeVM student = dBContext.Stanovanjes.Where(a => a.studentID == StudentID).Select(x => new StudentStanovanjeVM
            {
                ImeStudenta=x.student.Ime+" "+x.student.Prezime,
                BrojSobe = x.soba.BrojSobe,
                AkademskaGodina = x.AkademskaGodina
            }).Single();
            var studenti = dBContext.Stanovanjes.Where(a=>student.BrojSobe==a.soba.BrojSobe && a.student.ID!=StudentID).Select(x => new StudentStanovanjeVM.Row
            {
                Imecimera = x.student.Ime +" "+ x.student.Prezime+" "
            }).ToList();
            student.cimeri = studenti;
            return View(student);
        }


        public ActionResult Obrisi(int ID)
        {

            MojDBContext dBcontext = new MojDBContext();

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
