using System.Collections.Generic;
using Catalyte.Apparel.DTOs.Products;
using Catalyte.Apparel.Utilities;
using System.Threading.Tasks;

namespace Catalyte.Apparel.Providers.Interfaces
{
    public interface IPurchaseProvider
    {

        Task<ProviderResponse<PurchaseDTO>> GetPurchaseByIdAsync(int purchaseId);

        Task<ProviderResponse<List<PurchaseDTO>>> GetPurchasesAsync(int page, int size);

    }
}
