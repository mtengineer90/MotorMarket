using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MotorMarket.AppDbContext
{
    public class MgaleriDbContext:DbContext
    {
        public MgaleriDbContext(DbContextOptions<MgaleriDbContext> options):base(options)
        {

        }
    }
}
