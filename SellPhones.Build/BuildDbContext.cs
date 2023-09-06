using Microsoft.EntityFrameworkCore;
using SellPhones.Data.EF;

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