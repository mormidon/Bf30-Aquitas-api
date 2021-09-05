using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catalyte.Apparel.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace Catalyte.Apparel.Data.Context
{
    public class ApparelCtx : DbContext
    {

        public ApparelCtx(DbContextOptions<ApparelCtx> options) : base(options)
        {
            
        }

        public DbSet<Product> Products { get; set; }



    }
}
