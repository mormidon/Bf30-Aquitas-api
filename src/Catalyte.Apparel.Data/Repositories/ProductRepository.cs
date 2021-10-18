using System.Collections.Generic;
using System.Linq;
using Catalyte.Aquitas.Data.Context;
using Catalyte.Aquitas.Data.Interfaces;
using Catalyte.Aquitas.Data.Model;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Catalyte.Aquitas.Data.Repositories
{

    public class ProductRepository : IProductRepository
    {
        private readonly IApparelCtx _ctx;

        public ProductRepository(IApparelCtx ctx)
        {
            _ctx = ctx;
        }

        public async Task<Product> GetProductByIdAsync(int productId)
        {
            return await _ctx.Products.FindAsync(productId);
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _ctx.Products.ToListAsync();
        }
    }

}
