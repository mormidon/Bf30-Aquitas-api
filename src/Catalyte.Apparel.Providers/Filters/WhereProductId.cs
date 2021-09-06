using Catalyte.Apparel.Data.Model;
using System.Collections.Generic;
using System.Linq;

namespace Catalyte.Apparel.Providers.Filters
{

    public static class WhereProductId
    {

        public static IEnumerable<Product> WhereProductIdEquals(this IEnumerable<Product> products, int productId)
        {
            return products.Where(i => i.Id == productId);
        }

    }

}
