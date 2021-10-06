using Catalyte.Apparel.Data.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalyte.Apparel.Data.Interfaces
{
    public interface IPurchaseRepository
    {
        Task<Purchase> GetPurchaseByIdAsync(int purchaseId);

        Task<List<Purchase>> GetPurchases(int page, int size);
    }
}
