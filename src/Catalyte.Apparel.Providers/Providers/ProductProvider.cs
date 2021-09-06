using Catalyte.Apparel.Data.Interfaces;
using Catalyte.Apparel.Data.Model;
using Catalyte.Apparel.Providers.Filters;
using Catalyte.Apparel.Providers.Interfaces;
using System.Linq;

namespace Catalyte.Apparel.Providers.Providers
{
    public class ProductProvider : IProductProvider
    {
        private readonly IProductRepository _productRepository;

        public ProductProvider(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Product GetProductById(int productId)
        {
            return _productRepository.GetProducts()
                .WhereProductIdEquals(productId)
                .FirstOrDefault();
        }
    }
}
