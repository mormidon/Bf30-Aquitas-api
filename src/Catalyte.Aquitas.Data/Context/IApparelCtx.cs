using Catalyte.Aquitas.Data.Model;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Catalyte.Aquitas.Data.Context
{

    public interface IApparelCtx
    {

        public DbSet<Company> Companies { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
    }

}
