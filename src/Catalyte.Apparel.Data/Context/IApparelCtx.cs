using Catalyte.Apparel.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace Catalyte.Apparel.Data.Context
{

    public interface IApparelCtx
    {

        public DbSet<Product> Products { get; set; }

        public DbSet<Log> Logs { get; set; }

    }

}
