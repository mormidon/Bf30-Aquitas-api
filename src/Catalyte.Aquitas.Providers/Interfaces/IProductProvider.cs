using Catalyte.Aquitas.DTOs.Products;
using Catalyte.Aquitas.Utilities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalyte.Aquitas.Providers.Interfaces
{
    public interface IProductProvider
    {
        Task<ProviderResponse<ProductDTO>> GetProductByIdAsync(int productId);

        Task<ProviderResponse<List<ProductDTO>>> GetProductsAsync();
    }
}
