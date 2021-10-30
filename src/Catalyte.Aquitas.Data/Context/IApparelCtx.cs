using System.Threading;
using System.Threading.Tasks;
using Catalyte.Aquitas.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace Catalyte.Aquitas.Data.Context
{

    public interface IApparelCtx
    {

        public DbSet<Product> Products { get; set; }

        public DbSet<LineItem> LineItems { get; set; }

        public DbSet<Purchase> Purchases { get; set; }

        public DbSet<AquitasUser> AquitasUsers { get; set; }

        public DbSet<Company> Companies { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
    }

}
