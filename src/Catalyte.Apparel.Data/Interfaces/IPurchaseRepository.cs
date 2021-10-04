using System.Threading.Tasks;
using Catalyte.Apparel.Data.Model;

namespace Catalyte.Apparel.Data.Interfaces
{
    public interface IPurchaseRepository
    {
        Task<Purchase> GetPurchaseByIdAsync(int purchaseId)
    }
}
