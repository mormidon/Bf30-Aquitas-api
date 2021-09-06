using Catalyte.Apparel.Data.Context;
using Catalyte.Apparel.Data.Interfaces;
using Catalyte.Apparel.Data.Model;
using System.Collections.Generic;

namespace Catalyte.Apparel.Data.Respositories
{

    public class ProductRepository : IProductRepository
    {
        private readonly IApparelCtx _ctx;

        public ProductRepository(IApparelCtx ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<Product> GetProducts()
        {
            return _ctx.Products;
        }

    }

}
