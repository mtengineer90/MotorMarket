using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MotorMarket.Extensions
{
    public static class ExtensionSinif
    {
        public static string GetPropertyValue<T>(this T item, string propertyName)
        {
            return item.GetType().GetProperty(propertyName).GetValue(item, null).ToString();
        }
    }
}
