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
    }   
}