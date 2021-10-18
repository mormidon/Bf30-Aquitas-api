using Catalyte.Aquitas.Data.Model;
using System.Collections.Generic;
using System.Linq;

namespace Catalyte.Aquitas.Data.Filters
{
    public static class ProductFilters
    {
        public static IQueryable<Product> WhereProductIdEquals(this IEnumerable<Product> products, int productId)
        {
            return products.Where(i => i.Id == productId).AsQueryable();
        }
    }
}
