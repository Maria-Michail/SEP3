using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Impl;
using Database.Model;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace WebApi.Controllers
{
    
    [ApiController]
    [Route("[Controller]")]
    public class RecipeController : ControllerBase
    {
        private IRecipeService recipeService;

        public RecipeController(IRecipeService recipeService)
        {
            this.recipeService = recipeService;
        }


        [HttpGet("ing/{recipeId:int}")] //int value for route
        public async Task<ActionResult<IList<Ingredient>>> GetById(int recipeId) {
            Console.WriteLine("hhhhh");
            IList<Ingredient> ingredients = await recipeService.GetIngredientsAsync(recipeId);
            return Ok(ingredients); 
        }

        
        [HttpGet]
        public async Task<ActionResult<IList<Recipe>>> getRecipesAsync()
        {
                    try
                    {
                        Console.WriteLine("The recipe with this name does not exist");
                        IList<Recipe> recipes = await recipeService.getRecipesAsync();
                        return Ok(recipes);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Wrong name of the recipe");
                        return BadRequest(e.Message);
                    }
                }
    }
}