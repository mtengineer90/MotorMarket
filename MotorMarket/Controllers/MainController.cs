using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MotorMarket.AppDbContext;
using MotorMarket.Helpers;
using MotorMarket.Models;

namespace MotorMarket.Controllers
{
    [Authorize(Roles = Roller.Admin + "," + Roller.Executive)]
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
        public IActionResult Create(Main main)
        {
            if (ModelState.IsValid)
            {
                _db.Add(main);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(main);
        }
        //Post Method
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var main = _db.Mains.Find(id);
            if (main == null)
            {
                return NotFound();
            }
            _db.Mains.Remove(main);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            var main = _db.Mains.Find(id);
            if (main == null)
            {
                return NotFound();
            }
            return View(main);
        }

        [HttpPost]
        public IActionResult Edit(Main main)
        {
            if (ModelState.IsValid)
            {
                _db.Update(main);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(main);
        }

    }
}
