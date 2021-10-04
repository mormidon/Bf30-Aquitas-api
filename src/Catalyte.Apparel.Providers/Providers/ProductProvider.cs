using Catalyte.Apparel.Data.Interfaces;
using Catalyte.Apparel.Data.Model;
using Catalyte.Apparel.Providers.Interfaces;
using Catalyte.Apparel.Utilities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Catalyte.Apparel.DTOs.Products;

namespace Catalyte.Apparel.Providers.Providers
{
    public class ProductProvider : IProductProvider
    {
        private readonly IProductRepository _productRepository;
        private readonly Mapper _mapper;

        public ProductProvider(IProductRepository productRepository)
        {
            _productRepository = productRepository;
            _mapper = InitializeMapper();
        }

        public async Task<ProviderResponse<ProductDTO>> GetProductByIdAsync(int productId)
        {
            var product = await _productRepository.GetProductByIdAsync(productId);

            return product == default
                ? new ProviderResponse<ProductDTO>(
                    null,
                    ResponseTypes.NotFound,
                    $"Product with Id:{productId} not found")
                : new ProviderResponse<ProductDTO>(
                    _mapper.Map<ProductDTO>(product),
                    ResponseTypes.Success,
                    Constants.Success);
        }

        public async Task<ProviderResponse<List<ProductDTO>>> GetProductsAsync()
        {
            var products = await _productRepository.GetProductsAsync();
            return new ProviderResponse<List<ProductDTO>>(
                _mapper.Map<List<ProductDTO>>(products.ToList()),
                ResponseTypes.Success,
                Constants.Success);
        }

        private Mapper InitializeMapper()
        {
            return new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Product, ProductDTO>();
            }));
        }
    }
}
