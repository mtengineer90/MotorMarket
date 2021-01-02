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
        //HTTP Get
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreaOte(Main main)
        {
            if (ModelState.IsValid)
            {
                _db.Add(main);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(main);
        }
   
    }
}
