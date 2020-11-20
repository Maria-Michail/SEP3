﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Model;

namespace Db
{
    public interface IDbRecipeService
    {
        Task<List<Recipe>> getRecipiesAsync();
        Task<Recipe> getRecipeAsync(string recipeName);
        Task removeRecipeAsync(string recipeName);
        Task addRecipeAsync(Recipe recipe);
        Task updateRecipeAsync(Recipe recipe);
    }
}