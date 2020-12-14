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
                Console.WriteLine("som");
                return BadRequest(ModelState);
            }
            try {
                Console.WriteLine("WebApi recieved" );
                await orderService.AddOrderAsync(order);
                return Ok(); 
            } catch (Exception e) {
                Console.WriteLine(e); 
                return StatusCode(500, e.Message);
            }
        }
        
        
        [HttpGet("k/{username}")] 
        public async Task<ActionResult<IList<Order>>> GetOrders(string username) {
            Console.WriteLine("OrderController");
            IList<Order> orders = await orderService.GetOrders(username);
            Console.WriteLine(orders[0].username);
            return Ok(orders); 
        }
    }
}