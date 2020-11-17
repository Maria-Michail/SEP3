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
    public class AccountsController : ControllerBase{
        private IAccountService accountService;

        public AccountsController(IAccountService accountService){
            this.accountService = accountService;
        }


        [HttpGet]
        public async Task<ActionResult<IList<Account>>> getAccounts(){
            try{
                IList<Account> accounts = await accountService.getAccountsAsync();
                return Ok(accounts);
            }catch(Exception e){
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        public async Task<ActionResult<Account>> ValidateUser([FromQuery] string username, [FromQuery] string password)
        {
            Console.WriteLine("Here");
            try
            {
                var user = await accountService.ValidateUser(username, password);
                return Ok(user);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }   
}