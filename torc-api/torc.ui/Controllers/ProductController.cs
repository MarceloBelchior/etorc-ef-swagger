using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using torc.Iface;
using torc.model;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace torc.ui.Properties
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {

        private readonly IProductBusiness productBusiness;
        private readonly ILogger<ProductController> logger;

        public ProductController(ILogger<ProductController> _logger, IProductBusiness _IProductBusiness)
        {
            productBusiness = _IProductBusiness;
            logger = _logger;
        }
   

        [HttpGet, Route("{ProductId}")]
        [SwaggerResponse(200, "List of Account for the user", typeof(IList<Product>))]

        public async Task<IActionResult> GetProductById([FromRoute] string ProductId)
        {

            logger.LogInformation("Request, logging!");
            int validproduct = 0;

            if (!int.TryParse(ProductId, out validproduct))
                return BadRequest("ProductInvalid");
            var query = await productBusiness.GetProdutById(validproduct);
            if (query == null)
                return NotFound();
            return Ok(query);
        }
    }
}

