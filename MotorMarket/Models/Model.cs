using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MotorMarket.Models
{
    public class Model
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Main Main { get; set; }
        public int MainId { get; set; }
    }
}
