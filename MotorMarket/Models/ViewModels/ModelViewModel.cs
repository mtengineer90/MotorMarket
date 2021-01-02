using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MotorMarket.Models.ViewModels
{
    public class ModelViewModel
    {
        public Model Model { get; set; }
        public IEnumerable<Main> Mains { get; set; }
        public IEnumerable<SelectListItem> CSelectListItem(IEnumerable<Main> Items)
        {
            List<SelectListItem> MainList = new List<SelectListItem>();
            SelectListItem sli = new SelectListItem
            {
                Text = "---Seç---",
                Value = "0"
            };
            MainList.Add(sli);
            foreach (Main main in Items)
            {
                sli = new SelectListItem
                {
                    Text = main.Name,
                    Value = main.Id.ToString()
                };
                MainList.Add(sli);
            }
            return MainList;

        }
    }
}
