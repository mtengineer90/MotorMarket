using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MotorMarket.AppDbContext;
using MotorMarket.Controllers.Resources;
using MotorMarket.Helpers;
using MotorMarket.Models;
using MotorMarket.Models.ViewModels;

namespace MotorMarket.Controllers
{
    [Authorize(Roles = Roller.Admin + "," + Roller.Executive)]
    public class ModelController : Controller
    {
        private readonly MgaleriDbContext _db;
        private readonly IMapper _mapper;
        [BindProperty]
        public ModelViewModel ModelVM { get; set; }
        public ModelController(MgaleriDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
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
        public IActionResult Edit(int id)
        {
            ModelVM.Model = _db.Models.Include(x => x.Main).SingleOrDefault(x => x.Id == id);
            if(ModelVM.Model==null)
            {
                return NotFound();
            }
            return View(ModelVM);
        }
        [HttpPost, ActionName("Edit")]
        public IActionResult EditPost()
        {
            if (!ModelState.IsValid)
            {
                return View(ModelVM);
            }
            _db.Update(ModelVM.Model);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            Model model = _db.Models.Find(id);
            if (model == null)
            {
                return NotFound();
            }
            _db.Models.Remove(model);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        [AllowAnonymous]
        [HttpGet("api/models/{MainID}")]
        public IEnumerable<Model> Models(int MainID)
        {
            return _db.Models.ToList()
                .Where(x => x.MainId == MainID);
        }

        [AllowAnonymous]
        [HttpGet("api/models")]
        public IEnumerable<ModelResources> Models()
        {
            var models = _db.Models.ToList();
            return _mapper.Map<List<Model>, List<ModelResources>>(models);


            //var modelResources = models.Select(x => new ModelResources
            //{
            //    Id = x.Id,
            //    Name = x.Name,
            //}).ToList();
        }
    }
}
