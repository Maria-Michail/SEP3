using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blazor.Data;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace WebApi.Controllers
{
    
    [ApiController]
    [Route("[Controller]")]
    public class IngredientController : ControllerBase
    {
        private IIngredientsService ingredientsService;

        public IngredientController(IIngredientsService ingredientsService)
        {
            this.ingredientsService = ingredientsService;
        }
        
        [HttpGet]
        public async Task<ActionResult<IList<Ingredient>>> getIngredientAsync()
        {
            try
            {
                IList<Ingredient> ingredients = await ingredientsService.GetIngredientsAsync();
                Console.WriteLine(ingredients + "--> WebApi/ingredientController");
                return Ok(ingredients);
            }
            catch (Exception e)
            {
                Console.WriteLine("Wrong name of the recipe");
                return BadRequest(e.Message);
            }
        }
        
        
        
        /*[HttpGet]
        public async Task<ActionResult<IList<Ingredient>>> GetIngredients() {
            try
            {
                IList<Ingredient> ingredients = await ingredientsService.GetAllIngredientsAsync();
                return Ok(ingredients);
            } catch (Exception e) {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }*/
    }
}