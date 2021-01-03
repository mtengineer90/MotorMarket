using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MotorMarket.Models;

namespace MotorMarket.AppDbContext
{
    public class MgaleriDbContext:IdentityDbContext<IdentityUser>
    {
        public MgaleriDbContext(DbContextOptions<MgaleriDbContext> options):base(options)
        {

        }

        public DbSet<Main> Mains { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

    }
}
