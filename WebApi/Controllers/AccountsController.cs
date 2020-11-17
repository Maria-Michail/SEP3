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
        public async Task<ActionResult<IList<Account>>> getAccounts([FromQuery] string username, [FromQuery] string password){
            try{
                if (username == null)
                {
                    IList<Account> accounts = await accountService.getAccountsAsync();
                    return Ok(accounts);
                }
                else
                {
                   return Ok(ValidateUser( username, password));
                }
                
            }catch(Exception e){
                
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        public async Task<ActionResult<Account>> ValidateUser(string username,  string password)
        {
            Console.WriteLine("Here");
            try
            {
                var user = await accountService.ValidateUser(username, password);
                return user;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }   
}