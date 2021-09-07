using Catalyte.Apparel.Providers.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

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

        //[HttpGet]
        //public ActionResult<ProviderResponse<ProductDTO>> GetProducts()
        //{
        //    _logger.LogInformation("logged");

        //    return new OkObjectResult();
        //}

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductByIdAsync(int id)
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
