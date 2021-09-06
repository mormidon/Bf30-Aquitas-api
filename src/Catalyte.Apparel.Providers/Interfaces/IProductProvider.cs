using Catalyte.Apparel.Data.Model;

namespace Catalyte.Apparel.Providers.Interfaces
{
    public interface IProductProvider
    {
        Product GetProductById(int productId);
    }
}
