using Catalyte.Apparel.Data.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Catalyte.Apparel.Data.Interfaces
{

    public interface IProductRepository
    {
        Task<Product> GetProductByIdAsync(int productId);
    }

}
