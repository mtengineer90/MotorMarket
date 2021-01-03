using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MotorMarket.Models
{
    public class Motorsiklet
    {
        public int Id { get; set; }
        public Main Main { get; set; }
        public int MainID { get; set; }
        public Model Model { get; set; }
        public int ModelID { get; set; }

        [Required]
        public int Yil { get; set; }
        [Required]
        public int KM { get; set; }
        public string Ozellikler { get; set; }
        [Required]
        public string SaticiName { get; set; }
        public string SaticiEmail { get; set; }
        [Required]
        public string SaticiTelefon { get; set; }
        [Required]
        public int Fiyat { get; set; }
        [Required]
        public string Para { get; set; }
        public string ImagePath { get; set; }


    }
}
