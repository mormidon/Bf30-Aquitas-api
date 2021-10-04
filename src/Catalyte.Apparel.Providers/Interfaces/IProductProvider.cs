using Catalyte.Apparel.DTOs.Products;
using Catalyte.Apparel.Utilities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalyte.Apparel.Providers.Interfaces
{
    public interface IProductProvider
    {
        Task<ProviderResponse<ProductDTO>> GetProductByIdAsync(int productId);

        Task<ProviderResponse<List<ProductDTO>>> GetProductsAsync();
    }
}
