using System.Threading;
using System.Threading.Tasks;
using Catalyte.Apparel.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace Catalyte.Apparel.Data.Context
{

    public interface IApparelCtx
    {

        public DbSet<Product> Products { get; set; }

        public DbSet<LineItem> LineItems { get; set; }

        public DbSet<Purchase> Purchases { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
    }

}
