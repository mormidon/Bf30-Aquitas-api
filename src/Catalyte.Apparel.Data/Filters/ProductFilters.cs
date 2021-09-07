using Catalyte.Apparel.Data.Model;
using System.Collections.Generic;
using System.Linq;

namespace Catalyte.Apparel.Data.Filters
{
    public static class ProductFilters
    {
        public static IQueryable<Product> WhereProductIdEquals(this IEnumerable<Product> products, int productId)
        {
            return products.Where(i => i.Id == productId).AsQueryable();
        }
    }
}
