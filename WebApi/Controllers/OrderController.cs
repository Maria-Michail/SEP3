using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Impl;
using Database.Model;
using Microsoft.AspNetCore.Mvc;
using WebApi.Data.Impl;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class OrderController : ControllerBase
    {
        private IOrderService orderService;

        public OrderController(IOrderService orderService)
        {
            this.orderService = orderService;
        }
        
        [HttpPost]
        public async Task<ActionResult<Order>> SendOrder([FromBody] Order order) {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try {
                Order added = await orderService.AddOrderAsync(order);
                return Created($"/{added.orderId}",added); 
            } catch (Exception e) {
                Console.WriteLine(e); 
                return StatusCode(500, e.Message);
            }
        }
    }
}