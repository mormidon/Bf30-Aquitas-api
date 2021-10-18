using Catalyte.Aquitas.DTOs.Products;
using Catalyte.Aquitas.Providers.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalyte.Aquitas.API.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger<ProductsController> _logger;
        private readonly IProductProvider _productProvider;

        public ProductsController(ILogger<ProductsController> logger, IProductProvider productProvider)
        {
            _logger = logger;
            _productProvider = productProvider;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductDTO>>> GetProductsAsync()
        {
            var response = await _productProvider.GetProductsAsync();
            return response.ToActionResult();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDTO>> GetProductByIdAsync(int id)
        {
            var response = await _productProvider.GetProductByIdAsync(id);
            return response.ToActionResult();
        }
    }
}
