using Catalyte.Aquitas.DTOs.Purchases;
using Catalyte.Aquitas.Utilities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalyte.Aquitas.Providers.Interfaces
{
    public interface IPurchaseProvider
    {

        Task<ProviderResponse<PurchaseDTO>> GetPurchaseByIdAsync(int purchaseId);

        Task<ProviderResponse<List<PurchaseDTO>>> GetPurchasesAsync(int page, int pageSize);

        Task<ProviderResponse<PurchaseDTO>> CreatePurchasesAsync(CreatePurchaseDTO model);

    }
}
