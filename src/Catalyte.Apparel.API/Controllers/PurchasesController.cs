using Catalyte.Apparel.API.Helpers;
using Catalyte.Apparel.DTOs.Products;
using Catalyte.Apparel.Providers.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Catalyte.Apparel.API.Controllers
{
    [ApiController]
    [Route("api/purchases")]
    [HttpExceptionFilter]
    public class PurchasesController : ControllerBase
    {
        private readonly ILogger<PurchasesController> _logger;
        private readonly IPurchaseProvider _purchaseProvider;

        public PurchasesController(ILogger<PurchasesController> logger, IPurchaseProvider purchaseProvider)
        {
            _logger = logger;
            _purchaseProvider = purchaseProvider;
            _purchaseProvider = purchaseProvider;
        }

        //[HttpGet]
        //public async Task<ActionResult<List<ProductDTO>>> GetProductsAsync()
        //{

        //    try
        //    {
        //        var response = await _productProvider.GetProductsAsync();
        //        return response.ToActionResult();
        //    }
        //    catch
        //    {
        //        return BadRequest();
        //    }

        //}

        [HttpGet("{id}")]
        public async Task<ActionResult<PurchaseDTO>> GetPurchaseByIdAsync(int id)
        {

            try
            {
                var response = await _purchaseProvider.GetPurchaseByIdAsync(id);
                return response.ToActionResult();
            }
            catch
            {
                return BadRequest();
            }

        }
    }
}
