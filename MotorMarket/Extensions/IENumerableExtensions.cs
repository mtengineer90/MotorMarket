using Microsoft.AspNetCore.Mvc.Rendering;
using MotorMarket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MotorMarket.Extensions
{
    public static class IENumerableExtensions
    {
        public static IEnumerable<SelectListItem> ToSelectListItem<T>(this IEnumerable<T> Items)
        {
            List<SelectListItem> List = new List<SelectListItem>();
            SelectListItem sli = new SelectListItem
            {
                Text = "-Seçiniz-",
                Value = "0"
            };
            List.Add(sli);
            foreach (var item in Items)
            {
                sli = new SelectListItem
                {
                    Text = item.GetPropertyValue("Name"),
                    Value = item.GetPropertyValue("Id")
                   // Text = item.GetType().GetProperty("Name").GetValue(item, null).ToString(),
                   // Value = item.GetType().GetProperty("Id").GetValue(item, null).ToString(),
                };
                List.Add(sli);
            }
            return List;

        }
    }
}
