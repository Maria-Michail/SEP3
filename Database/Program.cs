﻿using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using Database.Model;
using System.Threading.Tasks;
using Db;
using System.Collections.Generic;
using System.Linq;
using Database.Networking;
using Microsoft.EntityFrameworkCore;
using Model;

namespace Server
{
    class Program
    {
        async static Task Main(string[] args)
        {
            using (DatabaseContext dataContext = new DatabaseContext())
            {
                if (!dataContext.accounts.Any())
                {
                    Seed(dataContext);
                }
            }
            IDbAccountService accountService = new DbAccountService();
            IDbRecipeService recipeService = new DbRecipeService();
            IDbAddressService addresService = new DbAddressService();
            IDbShopIngrService shopIngrService = new DbShopIngreService();
            IDbBankInfoService bankInfoService = new DbBankInfoService();
            IDbIngredientService ingredientService = new DbIngredientService();
            IDbShopService shopService = new DbShopService();

            /*
            List<ShopIngredient> shopIngredients = await shopIngrService.getShopIngredientsAsync();
            List<Shop> shops = await shopService.getShopsAsync();

            ShopIngredient shopIngredient = new ShopIngredient();
            Shop shop = new Shop();
            if (shopIngredients.Count < 1)
            {
                Amount amount = new Amount();
                amount.number = 1;
                amount.unitType = "kg";
                shopIngredient.id = shopIngredients.Count + 1;
                shopIngredient.name = "Danish Potatoes";
                shopIngredient.price = 20;
                shopIngredient.ShopVares = new List<ShopVare>();
                shopIngredient.unitType = "DKK";
                await shopIngrService.addShopIngredientAsync(shopIngredient);
            }

            if (shops.Count < 1)
            {
                Address address = new Address();
                address.city = "Horsens";
                address.street = "Kollegievænget 3";
                address.zipCode = 8700;
                address.AccountAddresses = new List<AccountAddress>();
                shop.shopAddress = address;
                shop.shopId = shops.Count + 1;
                shop.shopName = "Rema";
                shop.shopVares = new List<ShopVare>();
                shop.vares = new List<ShopIngredient>();
                await shopService.addShopAsync(shop);
            }

            if (shops.Count == 1 && shopIngredients.Count == 1)
            {
                await shopService.linkShopVareAsync(shops[0].shopId, shopIngredients[0].id);
            }*/

            
            List<Recipe> recipes = await recipeService.getRecipiesAsync();
            Ingredient ingredient1 = new Ingredient();
            Ingredient ingredient2 = new Ingredient();
            Recipe recipe = new Recipe();
            ingredient1.number = 2;
            ingredient1.unitType = "slice";
            ingredient1.ingredientId = 1;
            ingredient1.ingredientName = "Toast";
            ingredient2.number = 1;
            ingredient2.unitType = "medium";
            ingredient2.ingredientId = 2;
            ingredient2.ingredientName = "Eggs";
            List<Ingredient> ingredients = new List<Ingredient>();
            ingredients.Add(ingredient1);
            ingredients.Add(ingredient2);
            
            recipe.description = "French toast easy enough";
            recipe.instructions = "Just do it";
            recipe.IngredientRecipes = new List<IngredientRecipe>();
            recipe.Category = new Category()
            {
                categoryName = "Very Easy"
            };
            recipe.recipeId = 1;
            recipe.recipeName = "French Toast";
            recipe.imageName = "no Clue yet here";
            recipe.ingredients = ingredients;
            await recipeService.addRecipeAsync(recipe);


                //Server server = new Server(accountService,recipeService,addresService,shopIngrService, bankInfoService);
            //ServerToJava toJava = new ServerToJava(accountService,recipeService,ingredientService,shopService,shopIngrService);
            /*
            FirstSetup setup = new FirstSetup();
            List<Account> accounts = setup.GetAccounts();
            await tmp.saveAccountAsync(accounts[0]);
            await tmp.saveAccountAsync(accounts[1]);
            */
            //toJava.start();
        }

        private static async Task Seed(DatabaseContext databaseContext)
        {
            Address[] addresses = {
                new Address{
                    street = "Solvgade 1, 3tv",
                    city = "Horsens",
                    zipCode = 8700,
                },
            };
            foreach (var address in addresses)
            {
                databaseContext.addresses.Add(address);
            }
            
            BankInfo[] bankInfos = {
                new BankInfo{
                    cardNumber = 1234123412341234,
                    cardHolder = "Pawel Skrzypkowski"
                },
            };
            foreach (var bankInfo in bankInfos)
            {
                databaseContext.bankInfos.Add(bankInfo);
            }

            
            Account[] acs = {
                new Account{
                    username = "Jannik",
                    password = "12345",
                    email = "Jannik@viauc.dk",
                },
                
                
            };
            foreach (var account in acs)
            {
                databaseContext.accounts.Add(account);
            }
            
            
            Recipe[] recipes = {
                new Recipe(){
                    recipeName = "Arrabbiata",
                    instructions = "Sauté the crushed red pepper flakes: Heat the butter (or olive oil) in a large saucepan or deep sauté pan.  Add the crushed red pepper flakes and sauté for about 2 minutes, to help toast and bring out their flavor.\nAdd onion and garlic: Add in the onions and sauté until softened, followed by the garlic.\nAdd tomatoes:  Then add in the cans of whole tomatoes, juices included.  And as they begin to heat up, use a wooden spoon or a potato masher to carefully break up the tomatoes.  (Just wear an apron so that those juices inside of the tomatoes don’t accidentally splatter you!)\nSimmer: Continue heating the sauce until it comes to a simmer.  Then reduce heat to medium (or medium-low) to maintain a low simmer, and let the sauce cook for about 30 minutes, or until it reaches your desired consistency.\nStir in the basil, salt and pepper.  Then taste the sauce, and season with any extra salt, pepper and/or crushed red pepper flakes as needed.\nServe warm.  Or let the sauce cool and then refrigerate it in a sealed container for up to 4 days.",
                    cookingTime = 40,
                },
                
                new Recipe(){
                    recipeName = "Pizza",
                    instructions = "Add warm water to the bowl of a stand mixer with the dough attachment, and sprinkle the yeast on top of the water.  Give the yeast a quick stir to mix it in with the water.  Then let it sit for 5-10 minute until the yeast is foamy.\nTurn the mixer onto low speed, and add gradually flour, honey, olive oil and salt.  Increase speed to medium-low, and continue mixing the dough for 5 minutes.\nRemove dough from the mixing bowl, and use your hands to shape it into a ball.  Grease the mixing bowl (or a separate bowl) with olive oil or cooking spray, then place the dough ball back in the bowl and cover it with a damp towel.  Place in a warm location (I set mine by the window) and let it rise for 30-45 minutes until the dough has nearly doubled in size.\nPreheat oven to 450 degrees F.  Turn the dough onto a floured surface, and roll the dough into a 12- to 14-inch round for a thick-crusted pizza.  (Or cut the dough in half, and roll it into two 12-inch rounds for two thin crust pizzas.)  Sprinkle a baking sheet or pizza stone evenly with the cornmeal, then place the dough on the baking sheet.\nTop the dough with your desired sauce and toppings.  (And for extra-golden crust, brush the crust with an extra few teaspoons of olive oil or butter.)\nFor thick crust, bake for 16-18 minutes, or until the crust is golden brown and the toppings are melted and cooked.  For the (two) thin crusts, bake for 14-16 minutes, or until the crust is golden brown and the toppings are melted and cooked.\nSlice and serve pizza warm.",
                    cookingTime = 75,
                },
                
                
            };
            foreach (var rec in recipes)
            {
                databaseContext.recipes.Add(rec);
            }

            Category[] categories = {
                new Category(){
                    categoryName= "Italian",
                },
                new Category()
                {
                    categoryName = "Very Easy",
                },
                new Category()
                {
                    categoryName = "Easy",
                },
                new Category()
                {
                    categoryName = "Medium",
                },
                new Category()
                {
                    categoryName = "Hard",
                },
                new Category()
                {
                    categoryName = "Very Hard"
                }
            };
            foreach (var cat in categories)
            {
                databaseContext.categories.Add(cat);
            }
            
            
            
            databaseContext.SaveChanges();
            
            Account steve = await databaseContext.accounts.FirstAsync(s => s.username.Equals("Jannik") );
            Address tek = await databaseContext.addresses.FirstAsync(c => c.street.Equals("Solvgade 1, 3tv"));
            AccountAddress sc = new AccountAddress()
            {
                address = tek,
                account = steve
            };
            
            steve.AccountAddresses = new List<AccountAddress>();
            steve.AccountAddresses.Add(sc);
            databaseContext.Update(steve);
            
            // ctx.Set<StudentCourse>().Add(sc); This is an alternative
            await databaseContext.SaveChangesAsync();
            
            Account steve2 = await databaseContext.accounts.FirstAsync(s => s.username.Equals("Jannik") );
            BankInfo bankInfo2 = await databaseContext.bankInfos.FirstAsync(c => c.cardNumber == 1234123412341234);
            AccountBankInfo sc2 = new AccountBankInfo()
            {
               account = steve2,
               bankInfo = bankInfo2
            };
            
            steve.AccountBankInfos = new List<AccountBankInfo>();
            steve.AccountBankInfos.Add(sc2);
            databaseContext.Update(steve2);
            
            // ctx.Set<StudentCourse>().Add(sc); This is an alternative
            await databaseContext.SaveChangesAsync();
            
        }
    }
}