using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MotorMarket.Models;

namespace MotorMarket.Controllers
{
    public class MainController : Controller
    {
        //main/motors
        public IActionResult Motors()
        {
            Main main = new Main { Id = 1, Name = "Harley Davidson" };

            return View(main);
        }
    }
}
