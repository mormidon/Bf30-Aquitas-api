using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catalyte.Apparel.DTOs.Products;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Catalyte.Apparel.API.Controllers
{

    [ApiController]
    [Route("api/products")]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(ILogger<ProductsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<List<ProductDTO>> GetProducts()
        {
            _logger.LogInformation("logged");
            return new OkResult();
        }

        [HttpGet("{id}")]
        public ActionResult<List<ProductDTO>> GetProduct(int id)
        {
            return new OkResult();
        }

    }

}
