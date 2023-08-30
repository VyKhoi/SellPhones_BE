using SellPhones.Data.EF;
using Microsoft.EntityFrameworkCore;
using SellPhones.Data.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellPhones.Build
{
    internal class BuildDbContext : SellPhonesContext
    {
        public BuildDbContext(DbContextOptions<SellPhonesContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
