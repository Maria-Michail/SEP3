using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Impl;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class ValidateController : ControllerBase
    {
        private IAccountService accountService;

        public ValidateController(IAccountService accountService)
        {
            this.accountService = accountService;
        }


        [HttpGet]
        public async Task<ActionResult<Account>> ValidateUser([FromQuery] string username, [FromQuery] string password)
        {
            Console.WriteLine("Here");
            try
            {
                var user = await accountService.ValidateUser(username, password);
                Console.WriteLine("console is sending " + user.username);
                return Ok(user);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }   
}