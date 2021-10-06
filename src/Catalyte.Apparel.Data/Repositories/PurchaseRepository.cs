using System;
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
            try
            {
                return await _ctx.Purchases
                    .Include(p => p.LineItems)
                    .ThenInclude(p => p.Product)
                    .FirstOrDefaultAsync(p => p.Id == purchaseId);
            }
            catch (Exception ex)
            {
                // Log exception.
            }

            return null;
        }

        public async Task<List<Purchase>> GetPurchases(int page, int size)
        {
            try
            {
                return await _ctx.Purchases
                    .Include(p => p.LineItems)
                    .ThenInclude(p => p.Product)
                    .Skip((page - 1) * size)
                    .Take(size)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                // Log exception.
            }

            return null;
        }

        public async Task<List<LineItem>> GetPurchaseLineItemsAsync(int purchaseId)
        {
            return await _ctx.LineItems.Where(e => e.PurchaseId == purchaseId).ToListAsync();
        }
    }
}
