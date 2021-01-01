using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MotorMarket.AppDbContext;
using MotorMarket.Models;

namespace MotorMarket.Controllers
{
    public class MainController : Controller
    {
        private readonly MgaleriDbContext _db;

        public MainController(MgaleriDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View(_db.Mains.ToList());
        }

        ////main/motors
        //[Route("main")]
        //[Route("main/motors")]
        //public IActionResult Motors()
        //{
        //    Main main = new Main { Id = 1, Name = "Harley Davidson" };

        //    return View(main);
        //}

        //[Route("main/motors/{year:int:length(4)}/{month:int:range(1,12)}")]
        //public IActionResult ByYearMonth(int year, int month)
        //{
        //    return Content(year + ";" + month);
        //}
   
    }
}
