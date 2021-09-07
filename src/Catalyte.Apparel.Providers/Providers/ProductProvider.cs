using Catalyte.Apparel.Data.Filters;
using Catalyte.Apparel.Data.Interfaces;
using Catalyte.Apparel.Data.Model;
using Catalyte.Apparel.Providers.Interfaces;
using Catalyte.Apparel.Utilities;
using System.Threading.Tasks;

namespace Catalyte.Apparel.Providers.Providers
{
    public class ProductProvider : IProductProvider
    {
        private readonly IProductRepository _productRepository;

        public ProductProvider(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ProviderResponse<Product>> GetProductByIdAsync(int productId)
        {
            var product = await _productRepository.GetProductByIdAsync(productId);

            return product == default
                ? new ProviderResponse<Product>(null,
                    ResponseTypes.NotFound,
                    $"Product with Id:{productId} not found")
                : new ProviderResponse<Product>(product,
                    ResponseTypes.Success,
                    Constants.Success);
        }
    }
}
