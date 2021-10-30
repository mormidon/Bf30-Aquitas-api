using Catalyte.Aquitas.Data.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalyte.Aquitas.Data.Interfaces
{

    public interface IProductRepository
    {
        Task<Product> GetProductByIdAsync(int productId);

        Task<IEnumerable<Product>> GetProductsAsync();
    }
}
