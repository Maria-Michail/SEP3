using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Database.Model;
using Microsoft.AspNetCore.Mvc;
using Model;
using WebApi.Networking;

namespace Data.Impl
{
    public class RecipeService : IRecipeService
    {
        
        ISocketsToDatabase so;
        private IList<Recipe> recipes;
        private IList<Ingredient> ingredients;

        public RecipeService(){
            so = new SocketsToDatabase();
            recipes = new List<Recipe>();
            ingredients = new List<Ingredient>();
        }
        
        
        public async Task<IList<Recipe>> getRecipesAsync()
        {
            recipes = (IList<Recipe>) so.getRecipes();
            Console.WriteLine(recipes.ToString() + "--> WebApi/Data/Impl/RecipeService.cs");
            return recipes;
        }
        
        public async Task<IList<Ingredient>> GetIngredientsAsync(int id)
        {
            //maybe later make a class that uses the recipe id to make the ingredients that of the id
            ingredients =  (List<Ingredient>) so.getIngredients(id);
            return ingredients;
        }
        public async Task SetIngredientsAsync(IList<Ingredient> ingredients)
        {
            this.ingredients = ingredients;
        }
        public async Task<IList<OrderedShopIngredients>> GetShopIngredientsAsync(int id)
        {
            IList<ShopIngredient> allShopIngredients =  (List<ShopIngredient>) so.getShopIngredients();
            Console.WriteLine(allShopIngredients[0].name);
            ingredients = (List<Ingredient>) so.getIngredients(id);
            Console.WriteLine(ingredients[0].ingredientName);
            IList<OrderedShopIngredients> orderedShopIngredientses = new List<OrderedShopIngredients>();
            ShopIngredient temporaryIngredient = null;
            foreach (var ingredient in ingredients)
            {
                foreach (var shopIng in allShopIngredients)
                {
                    if (ingredient.ingredientName.Equals(shopIng.name))
                    {
                        if (temporaryIngredient == null)
                        {
                            temporaryIngredient = shopIng;
                        }
                        else
                        {
                            double tempPriceIncrease = temporaryIngredient.price;
                            double tempAmountIncrease = temporaryIngredient.amount;
                            double tempIngPrice = temporaryIngredient.price;
                            double tempIngAmount = temporaryIngredient.amount;
                            while (tempIngAmount<ingredient.number)
                            {
                                tempIngAmount = tempIngAmount + tempPriceIncrease;
                                tempIngPrice = tempIngPrice + tempAmountIncrease;
                            }

                            double newPriceIncrease = shopIng.price;
                            double newAmountIncrease = shopIng.amount;
                            double newIngPrice = shopIng.price;
                            double newIngAmount = shopIng.amount;
                            while (newIngAmount<ingredient.number)
                            {
                                newIngAmount = newIngAmount + newAmountIncrease;
                                newIngPrice = newIngPrice + newPriceIncrease;
                            }

                            if (tempIngAmount > newIngAmount)
                            {
                                temporaryIngredient = shopIng;
                            }
                        }
                    }
                }
                double priceIncrease = temporaryIngredient.price;
                
                double amountIncrease = temporaryIngredient.amount;
                double temporaryIngPrice = temporaryIngredient.price;
                double temporaryIngAmount = temporaryIngredient.amount;
                while (temporaryIngAmount<ingredient.number)
                {
                    temporaryIngAmount = temporaryIngAmount + amountIncrease;
                    temporaryIngPrice = temporaryIngPrice + priceIncrease;
                }
                OrderedShopIngredients newOrd = new OrderedShopIngredients();
                double totalAmount = temporaryIngAmount;
                totalAmount = Math.Round(totalAmount, 2);
                newOrd.amount = (int)Math.Round(totalAmount/amountIncrease);
                newOrd.totalPrice = temporaryIngPrice;
                newOrd.totalPrice = Math.Round(newOrd.totalPrice, 2);
                newOrd.shopIngredient = temporaryIngredient;
                newOrd.osId = 0;
                orderedShopIngredientses.Add(newOrd);
                temporaryIngredient = null;
            }
            Console.WriteLine(orderedShopIngredientses[0].shopIngredient.name);
            return orderedShopIngredientses;
        }
    }
}