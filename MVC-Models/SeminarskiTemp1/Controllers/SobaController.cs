using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SeminarskiTemp1.EF;
using SeminarskiTemp1.Models;

namespace SeminarskiTemp1.Controllers
{
    public class SobaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Prikazi()
        {
            MojDBContext dBContext = new MojDBContext();
            var m = dBContext.Sobas.Select(a => new SobaPrikazVM.Row
            {
                ID = a.ID,
                BrojKreveta = a.BrojKreveta,
                BrojSobe = a.BrojSobe

            }).ToList();
           
            SobaPrikazVM vm = new SobaPrikazVM();
            vm.sobe = m;
            return View(vm);
        }
    }
}
