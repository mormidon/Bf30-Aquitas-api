using Catalyte.Apparel.Data.Model;
using Catalyte.Apparel.Data.SeedData;
using Microsoft.EntityFrameworkCore;

namespace Catalyte.Apparel.Data.Context
{
    public class ApparelCtx : DbContext, IApparelCtx
    {

        public ApparelCtx(DbContextOptions<ApparelCtx> options) : base(options)
        { }

        public DbSet<Product> Products { get; set; }

        public DbSet<LineItem> LineItems { get; set; }

        public DbSet<Purchase> Purchases { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.SeedData();
        }

    }
}
