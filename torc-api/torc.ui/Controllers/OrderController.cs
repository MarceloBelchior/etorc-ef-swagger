using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using torc.Iface;
using torc.model;


namespace torc.ui.Properties
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {

        private readonly IOrderBusiness orderBusiness;
        public OrderController(IOrderBusiness _orderBusiness) => orderBusiness = _orderBusiness;


        [HttpPost]
        [SwaggerResponse(200, "Return Order submiteed and Id of database", typeof(Order))]

        public async Task<IActionResult> PostOrder([FromBody] Order entity)
        {
            if (entity.Quantity <= 0)
                return BadRequest("Invalid quantity");
            if (entity.ProductId <= 0)
                return BadRequest("Product Invalid");


            var query = await orderBusiness.CreateOrder(entity);
            if (query == null)
                return BadRequest("Error to create order - Check Product Id Exists");
            return Ok(query);
        }



        [HttpGet]
        [SwaggerResponse(200, "Return Order submiteed and Id of database", typeof(List<Order>))]

        public async Task<IActionResult> GetOrder()
        {
          

            var query = await orderBusiness.GetOrders();
            if (query == null)
                return BadRequest("Error to create order");
            return Ok(query);
        }



    }
}

 