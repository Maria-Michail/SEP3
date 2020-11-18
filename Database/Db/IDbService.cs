using System.Collections.Generic;
using System.Threading.Tasks;
using Database.Model;
using Model;

namespace Db{
    public interface IDbService
    {
        //Ingredient Calls
        Task<Ingredient> getIngredientAsync(int id);
        Task<IList<Ingredient>> getIngredientsAsync();
        Task<IList<SuperMarket>> getSupermarketsWithIngredientAsync(Ingredient ingredient);
        Task<IList<Recipe>> getRecipiesWithIngredientAsync(Ingredient ingredient);
        Task<int> getIngredientIdAsync(Ingredient ingredient);
        Task addIngredientAsync(Ingredient ingredient);
        Task deleteIngredient(Ingredient ingredient);
        Task updateIngredient(Ingredient ingredient);
        
        
        //Recipy Calls
        Task<List<Recipe>> getRecipiesAsync();
        Task<Recipe> getRecipeAsync(int id);
        Task<IList<Ingredient>> getRecipeIngredientAsync(int id);
        Task addIngredientToRecipy(Ingredient ingredient, int id);
        Task deleteRecipeAsync(Recipe recipe);
        Task updateRecipeAsync(Recipe recipe);
        Task addRecipeAsync(Recipe recipe);

        //SuperMarket Calls
        Task<List<SuperMarket>> getSuperMarketsAsync();
        Task<SuperMarket> getSuperMarketAsync(int id);
        Task<IList<Ingredient>> getSuperMarketsVaresAsync(int id);
        Task addIngredientToSuperMarket(Ingredient ingredient, int id);
        Task deleteSupermarketAsync(SuperMarket superMarket);
        Task updateSupermarketAsync(SuperMarket superMarket);
        Task addSuperMarketAsync(SuperMarket superMarket);
        

        //Account Calls
        Task<List<Account>> GetAccountsAcyns();

        Task saveAccountAsync(Account account);

        Task removeAccountAsync(Account account);

        Task updateAccountAsync(Account account);
    }
}