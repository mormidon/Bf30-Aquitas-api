using System.Threading.Tasks;
using Catalyte.Apparel.DTOs.Products;
using Catalyte.Apparel.Utilities;

namespace Catalyte.Apparel.Providers.Interfaces
{
    public interface IPurchaseProvider
    {

        Task<ProviderResponse<PurchaseDTO>> GetPurchaseByIdAsync(int purchaseId);

    }
}
