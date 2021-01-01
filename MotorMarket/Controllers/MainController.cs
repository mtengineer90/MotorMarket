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
        [Route("main")]
        [Route("main/motors")]
        public IActionResult Motors()
        {
            Main main = new Main { Id = 1, Name = "Harley Davidson" };

            return View(main);
        }

        [Route("main/motors/{year:int:length(4)}/{month:int:range(1,12)}")]
        public IActionResult ByYearMonth(int year, int month)
        {
            return Content(year + ";" + month);
        }
    }
}
