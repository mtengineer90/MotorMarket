using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MotorMarket.AppDbContext;
using MotorMarket.Helpers;
using MotorMarket.Models;
using MotorMarket.Models.ViewModels;

namespace MotorMarket.Controllers
{
    [Authorize(Roles = Roller.Admin + "," + Roller.Executive)]
    public class MotorsikletController : Controller
    {
        private readonly MgaleriDbContext _db;
        [BindProperty]
        public MotorViewModel MotorVM { get; set; }
        public MotorsikletController(MgaleriDbContext db)
        {
            _db = db;
            MotorVM = new MotorViewModel()
            {
                Mains = _db.Mains.ToList(),
                Models = _db.Models.ToList(),
                Motorsiklet = new Models.Motorsiklet()
            };
        }

        public IActionResult Index()
        {
            var Motors = _db.Motorsiklets.Include(x => x.Main).Include(x => x.Model);
            return View(Motors.ToList());
        }
        //Get Metod
        public IActionResult Create()
        {
            return View(MotorVM);
        }
        //Post Metod
        [HttpPost, ActionName("Create")]
        public IActionResult CreatePost()
        {
            if (!ModelState.IsValid)
            {
                return View(MotorVM);
            }
            _db.Motorsiklets.Add(MotorVM.Motorsiklet);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
//        public IActionResult Edit(int id)
//        {
//            MotorVM.Model = _db.Models.Include(x => x.Main).SingleOrDefault(x => x.Id == id);
//            if (MotorVM.Model == null)
//            {
//                return NotFound();
//            }
//            return View(MotorVM);
//        }
//        [HttpPost, ActionName("Edit")]
//        public IActionResult EditPost()
//        {
//            if (!ModelState.IsValid)
//            {
//                return View(MotorVM);
//            }
//            _db.Update(MotorVM.Model);
//            _db.SaveChanges();
//            return RedirectToAction(nameof(Index));
//        }
//        [HttpPost]
//        public IActionResult Delete(int id)
//        {
//            Model model = _db.Models.Find(id);
//            if (model == null)
//            {
//                return NotFound();
//            }
//            _db.Models.Remove(model);
//            _db.SaveChanges();
//            return RedirectToAction(nameof(Index));
//        }
    }
}
