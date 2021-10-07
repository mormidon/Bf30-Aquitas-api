using Catalyte.Apparel.Data.Context;
using Catalyte.Apparel.Data.Interfaces;
using Catalyte.Apparel.Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalyte.Apparel.Data.Repositories
{
    public class PurchaseRepository : IPurchaseRepository
    {
        private readonly ILogger<PurchaseRepository> _logger;
        private readonly IApparelCtx _ctx;

        public PurchaseRepository(ILogger<PurchaseRepository> logger, IApparelCtx ctx)
        {
            _logger = logger;
            _ctx = ctx;
        }

        public async Task<Purchase> GetPurchaseByIdAsync(int purchaseId)
        {
            return await _ctx.Purchases
                .Include(p => p.LineItems)
                .ThenInclude(p => p.Product)
                .FirstOrDefaultAsync(p => p.Id == purchaseId);
        }

        public async Task<List<Purchase>> GetPurchasesAsync(int page, int pageSize)
        {
            return await _ctx.Purchases
                .Include(p => p.LineItems)
                .ThenInclude(p => p.Product)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<Purchase> CreatePurchaseAsync(Purchase purchase)
        { 
            await _ctx.Purchases.AddAsync(purchase);
            await _ctx.SaveChangesAsync();

            return purchase;
        }
    }
}
