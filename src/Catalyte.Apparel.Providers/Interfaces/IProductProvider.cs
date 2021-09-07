using System.Threading.Tasks;
using Catalyte.Apparel.Data.Model;
using Catalyte.Apparel.Utilities;

namespace Catalyte.Apparel.Providers.Interfaces
{
    public interface IProductProvider
    {
        Task<ProviderResponse<Product>> GetProductByIdAsync(int productId);
    }
}
