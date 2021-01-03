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

        [Required(ErrorMessage = "Yıl Gerekli")]

        public int Yil { get; set; }
        [Required(ErrorMessage = "KM Gerekli")]
        public int KM { get; set; }
        public string Ozellikler { get; set; }
        [Required(ErrorMessage ="Satıcı Adı Gerekli")]
        public string SaticiName { get; set; }
        [EmailAddress(ErrorMessage ="Geçerli Email Adresi Giriniz")]
        public string SaticiEmail { get; set; }
        [Required(ErrorMessage = "Satıcı Telefon Numarası Gerekli")]
        public string SaticiTelefon { get; set; }
        [Required(ErrorMessage = "Fiyat Gerekli")]
        public int Fiyat { get; set; }
        [Required(ErrorMessage = "Para Birimi Gerekli")]
        public string Para { get; set; }
        public string ImagePath { get; set; }


    }
}
