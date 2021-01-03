﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MotorMarket.Models
{
    public class ApplicationUser:IdentityUser
    {
        [DisplayName("Phone Number")]
        public string PhoneNumber2 { get; set; }
    
        [NotMapped]
        public bool IsAdmin { get; set; }
    }
}
