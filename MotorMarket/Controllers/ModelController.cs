using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MotorMarket.AppDbContext;
using MotorMarket.Models;
using MotorMarket.Models.ViewModels;

namespace MotorMarket.Controllers
{
    public class ModelController : Controller
    {
        private readonly MgaleriDbContext _db;
        [BindProperty]
        public ModelViewModel ModelVM { get; set; }
        public ModelController(MgaleriDbContext db)
        {
            _db = db;
            ModelVM = new ModelViewModel()
            {
                Mains = _db.Mains.ToList(),
                Model = new Models.Model()
            };
        }

        public IActionResult Index()
        {
            var model = _db.Models.Include(x => x.Main);
            return View(model);
        }
        public IActionResult Create()
        {
            return View(ModelVM);
        }
        [HttpPost, ActionName("Create")]
        public IActionResult CreatePost()
        {
            if (!ModelState.IsValid)
            {
                return View (ModelVM);
            }
            _db.Models.Add(ModelVM.Model);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
