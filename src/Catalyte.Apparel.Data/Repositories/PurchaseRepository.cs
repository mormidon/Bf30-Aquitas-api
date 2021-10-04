using Catalyte.Apparel.Data.Context;
using Catalyte.Apparel.Data.Interfaces;
using Catalyte.Apparel.Data.Model;
using System.Threading.Tasks;

namespace Catalyte.Apparel.Data.Repositories
{
    public class PurchaseRepository : IPurchaseRepository
    {
        private readonly IApparelCtx _ctx;

        public PurchaseRepository(IApparelCtx ctx)
        {
            _ctx = ctx;
        }

        public async Task<Purchase> GetPurchaseByIdAsync(int purchaseId)
        {
            return await _ctx.Purchases.FindAsync(purchaseId);
        }
    }
}
