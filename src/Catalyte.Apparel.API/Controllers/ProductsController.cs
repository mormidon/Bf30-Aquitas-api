using System.Collections.Generic;
using Catalyte.Apparel.Providers.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Catalyte.Apparel.Data.Model;

namespace Catalyte.Apparel.API.Controllers
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
        public async Task<ActionResult<List<Product>>> GetProductsAsync()
        {

            try
            {
                var response = await _productProvider.GetProductsAsync();
                return response.ToActionResult();
            }
            catch
            {
                return BadRequest();
            }

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProductByIdAsync(int id)
        {

            try
            {
                var response = await _productProvider.GetProductByIdAsync(id);
                return response.ToActionResult();
            }
            catch
            {
                return BadRequest();
            }

        }

    }

}
