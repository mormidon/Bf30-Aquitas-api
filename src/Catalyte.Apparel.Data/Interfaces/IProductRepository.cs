using System.Collections.Generic;
using Catalyte.Apparel.Data.Model;

namespace Catalyte.Apparel.Data.Interfaces
{

    public interface IProductRepository
    {
        IEnumerable<Product> GetProducts();
    }

}
