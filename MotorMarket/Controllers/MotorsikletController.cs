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
using System.IO;
using Microsoft.Extensions.Hosting.Internal;
using Microsoft.AspNetCore.Hosting;

namespace MotorMarket.Controllers
{
    [Authorize(Roles = Roller.Admin + "," + Roller.Executive)]
    public class MotorsikletController : Controller
    {
        private readonly MgaleriDbContext _db;
        private readonly IWebHostEnvironment _hostingEnvironment; 
        
        [BindProperty]
        public MotorViewModel MotorVM { get; set; }
        public MotorsikletController(MgaleriDbContext db, IWebHostEnvironment hostingEnvironment)
        {
            _db = db;
            _hostingEnvironment = hostingEnvironment;
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
                MotorVM.Mains = _db.Mains.ToList();
                MotorVM.Models = _db.Models.ToList();
                return View(MotorVM);
            }
            _db.Motorsiklets.Add(MotorVM.Motorsiklet);
            _db.SaveChanges();

            //Motorsiklet ID
            var MotorID = MotorVM.Motorsiklet.Id;

            //wwwroot path 
            string wwrootPath = _hostingEnvironment.WebRootPath;

            //Upload files
            var dosyalar = HttpContext.Request.Form.Files;

            //Motor DbSet Referans
            var kayitliMotor = _db.Motorsiklets.Find(MotorID);

            //Upload Dosya
            if (dosyalar.Count != 0)
            {
                var ImagePath = @"images\motors\";
                var Extension = Path.GetExtension(dosyalar[0].FileName);
                var DigerImagePath = ImagePath + MotorID + Extension;
                var AbsImagePath = Path.Combine(wwrootPath, DigerImagePath);

                //Upload Server
                using (var fileStream=new FileStream(
                   AbsImagePath, FileMode.Create ))
                {
                    dosyalar[0].CopyTo(fileStream);
                }

                //Image Path on DB
                kayitliMotor.ImagePath = DigerImagePath;
                _db.SaveChanges();

            }


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
        [HttpPost]
        public IActionResult Delete(int id)
        {
            Motorsiklet motorsiklet = _db.Motorsiklets.Find(id);
            if (motorsiklet == null)
            {
                return NotFound();
            }
            _db.Motorsiklets.Remove(motorsiklet);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
