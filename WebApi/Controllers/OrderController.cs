using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Impl;
using Database.Model;
using Microsoft.AspNetCore.Mvc;
using Model;
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
                await orderService.AddOrderAsync(order);
                return Ok(); 
            } catch (Exception e) {
                return StatusCode(500, e.Message);
            }
        }
        
        
        [HttpGet] 
        public async Task<ActionResult<IList<Order>>> GetOrders() {
            IList<Order> orders = await orderService.GetOrders();
            return Ok(orders); 
        }
    }
}