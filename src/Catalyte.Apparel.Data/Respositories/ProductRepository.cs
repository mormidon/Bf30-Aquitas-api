using Catalyte.Apparel.Data.Context;
using Catalyte.Apparel.Data.Interfaces;
using Catalyte.Apparel.Data.Model;
using System.Threading.Tasks;

namespace Catalyte.Apparel.Data.Respositories
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
        
    }

}
