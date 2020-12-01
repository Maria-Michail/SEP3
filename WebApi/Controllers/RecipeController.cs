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
        
        
        [HttpGet]
        public async Task<ActionResult<IList<Recipe>>> getRecipesAsync([FromQuery] string name)
        {
            try
            {
                if (name == null)
                {
                    Console.WriteLine("The recipe with this name does not exist");
                    IList<Recipe> recipes = await recipeService.getRecipesAsync();
                    return Ok(recipes);
                }
                else
                {
                    try
                    {
                        IList<Recipe> accounts = await recipeService.getRecipesAsync();
                        var recipe = accounts.FirstOrDefault(r =>
                            r.name.Equals(name));
                        
                        Console.WriteLine("console is sending " + recipe.name);
                        IList<Recipe> recipesToSend = new List<Recipe>();
                        recipesToSend.Add(recipe);
                        return Ok(recipesToSend);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Wrong name of the recipe");
                        return BadRequest(e.Message);
                    }
                }

            }
            catch (Exception e)
            {

                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
    }
}