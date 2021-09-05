using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catalyte.Apparel.DTOs.Products;
using Microsoft.AspNetCore.Mvc;

namespace Catalyte.Apparel.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {

        public ProductController()
        {
            
        }

        [HttpGet]
        public ActionResult<List<ProductDTO>> GetProducts()
        {
            return new OkResult();
        }

        [HttpGet("{id}")]
        public ActionResult<List<ProductDTO>> GetProduct(int id)
        {
            return new OkResult();
        }

    }

}
