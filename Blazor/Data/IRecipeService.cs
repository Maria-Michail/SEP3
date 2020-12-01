<<<<<<< HEAD
﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Model;

namespace Blazor.Data
{
    public interface IRecipeService
    {
        Task<List<Recipe>> GetRecipesAsync();
    }
=======
﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Model;

namespace Blazor.Data
{
    public interface IRecipeService
    {
        public IList<Recipe> Recipes { get; }
        Task<List<Recipe>> GetRecipesAsync();
    }
>>>>>>> 6a52e9e35887e1b725388569f8bc930779bf2f3f
}