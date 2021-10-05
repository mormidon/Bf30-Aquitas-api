using Catalyte.Apparel.Data.Context;
using Catalyte.Apparel.Data.Interfaces;
using Catalyte.Apparel.Data.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
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
            return await _ctx.Purchases
                .Include(p => p.LineItems)
                .ThenInclude(p => p.Product)
                .FirstOrDefaultAsync(p => p.Id == purchaseId);
        }

        public async Task<List<LineItem>> GetPurchaseLineItemsAsync(int purchaseId)
        {
            return await _ctx.LineItems.Where(e => e.PurchaseId == purchaseId).ToListAsync();
        }
    }
}
