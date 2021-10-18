using Catalyte.Aquitas.DTOs.Purchases;
using Catalyte.Aquitas.Providers.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Catalyte.Aquitas.Utilities;

namespace Catalyte.Aquitas.API.Controllers
{
    [ApiController]
    [Route("api/purchases")]
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

        [HttpGet("{id}")]
        public async Task<ActionResult<PurchaseDTO>> GetPurchaseByIdAsync(int id)
        {
            var response = await _purchaseProvider.GetPurchaseByIdAsync(id);
            return response.ToActionResult();
        }

        [HttpGet]
        public async Task<ActionResult<List<PurchaseDTO>>> GetPurchasesAsync([FromQuery] int page = 1, int pageSize = 50)
        {
            if (page < 1 || pageSize < 1)
                return new BadRequestObjectResult("Page and Page Size cannot be less than 1.");

            try
            {
                var response = await _purchaseProvider.GetPurchasesAsync(page, pageSize);
                return response.ToActionResult();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex}");
                return StatusCode(500, ex);
            }
            
        }

        [HttpPost]
        public async Task<ActionResult<List<PurchaseDTO>>> CreatePurchase([FromBody] CreatePurchaseDTO model)
        {
            var result = await _purchaseProvider.CreatePurchasesAsync(model);

            //checks the model
            if (!ModelState.IsValid)
            {
                // return an error result
            }

            if (result.ResponseType == ResponseTypes.Created)
            {
                return new CreatedResult($"/purchases/{result.ResponseObject.Id}", result.ResponseObject);
            }

            return result.ToActionResult();
        }
    }
}
