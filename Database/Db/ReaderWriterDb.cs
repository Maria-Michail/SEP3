﻿using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Database.Model;
using Model;
using System.Text.Json;

namespace Db
{
    public class ReaderWriterDb
    {
        private static ReaderWriterDb instance;
        private Boolean activeWriter;
        private int activeReader;
        private int waitingReaders;
        
        private IDbRecipeService RecipeService = new DbRecipeService();
        private IDbIngredientService IngredientService = new DbIngredientService();
        private IDbAccountService AccountService = new DbAccountService();
        private IDbShopService ShopService = new DbShopService();
        private IDbShopIngrService ShopIngrService = new DbShopIngreService();
        private IDbAddressService AddressService = new DbAddressService();
        private IDbBankInfoService BankInfoService = new DbBankInfoService();
        private IDbOrderService OrderService = new DbOrderService();
        private IDbOrderedShopIngreService OrderedShopIngreService = new DbOrderedShopIngreService();

        private ReaderWriterDb()
        {
        }

        public static ReaderWriterDb getInstance()
        {
            if (instance == null)
            {
                instance = new ReaderWriterDb();
            }

            return instance;
        }

        public async void acquireRead()
        {
            waitingReaders++;
            while (activeWriter)
            {
            }
        }

        public async Task<string> addObjectAsync(Object o, string toAdd)
        {
            switch (toAdd)
            {
                case "recipe":
                {
                    Recipe recipe = (Recipe) o;
                    await RecipeService.addRecipeAsync(recipe);
                    return recipe.recipeName + " added";
                }
                case "ingredient":
                {
                    Ingredient ingredient = (Ingredient) o;
                    await IngredientService.addIngredientAsync(ingredient);
                    return ingredient.ingredientName + " added";
                }
                case "shop":
                {
                    Shop shop = (Shop) o;
                    await ShopService.addShopAsync(shop);
                    return shop.shopName + " added";
                }
                case "shopIngredient":
                {
                    ShopIngredient shopIngredient = (ShopIngredient) o;
                    await ShopIngrService.addShopIngredientAsync(shopIngredient);
                    return shopIngredient.name + " added";
                }
                case "account":
                {
                    Account account = (Account) o;
                    await AccountService.addAccountAsync(account);
                    return account.username + " added";
                }
            }

            return "Error";
        }

        public async Task<string> removeObjectAsync(Object o, string toRemove)
        {
            switch (toRemove)
            {
                case "recipe":
                {
                    Recipe recipe = (Recipe) o;
                    await RecipeService.removeRecipeAsync(recipe.recipeName);
                    return recipe.recipeName + " removed";
                }
                case "ingredient":
                {
                    Ingredient ingredient = (Ingredient) o;
                    await IngredientService.removeIngredientAsync(ingredient);
                    return ingredient.ingredientName + " removed";
                }
                case "shopIngredient":
                {
                    ShopIngredient shopIngredient = (ShopIngredient) o;
                    await ShopIngrService.removeShopIngredientAsync(shopIngredient);
                    return shopIngredient.name + " removed";
                }
                case "shop":
                {
                    Shop shop = (Shop) o;
                    await ShopService.removeShopAsync(shop.shopName);
                    return shop.shopName + " removed";
                }
            }

            return "Error";
        }

        public async Task<string> updateObjectAsync(Object o, string toUpdate)
        {
            switch (toUpdate)
            {
                case "ingredient":
                {
                    Ingredient ingredient = (Ingredient) o;
                    await IngredientService.updateIngredientAsync(ingredient);
                    return ingredient.ingredientName + " updated";
                }
                case "recipe":
                {
                    Recipe recipe = (Recipe) o;
                    await RecipeService.updateRecipeAsync(recipe);
                    return recipe.recipeName + " updated";
                }
                case "shopIngredient":
                {
                    ShopIngredient shopIngredient = (ShopIngredient) o;
                    await ShopIngrService.updateShopIngredientAsync(shopIngredient);
                    return shopIngredient.name + " updated";
                }
                case "shop":
                {
                    Shop shop = (Shop) o;
                    await ShopService.updateShopAsync(shop);
                    return shop.shopName + " updated";
                }
            }

            return "Error";
        }

        public async Task<String> linkObjectsAsync(Object o1, Object o2, string toLink)
        {
            switch (toLink)
            {
                case "ShopIngredientToShop":
                {
                    ShopIngredient shopIngredient = (ShopIngredient) o1;
                    Shop shop = (Shop) o2;
                    await ShopService.linkShopVareAsync(shop.shopId,shopIngredient.id);
                    return "linked";
                }
            }

            return "Error";
        }

        public async Task<string> getIngredientsAsync()
        {
            List<Ingredient> ingredients = await IngredientService.getIngredientsAsync();   
            return JsonSerializer.Serialize(ingredients);
        }

        public async Task<string> getShopsAsync()
        {
            List<Shop> shops = await ShopService.getShopsAsync();
            return JsonSerializer.Serialize(shops);
        }

        public async Task<string> getShopIngredientsAsync()
        {
            List<ShopIngredient> shopIngredients = await ShopIngrService.getShopIngredientsAsync();
            return JsonSerializer.Serialize(shopIngredients);
        }

        public async Task<string> getRecipesAsync()
        {
            List<Recipe> recipes = await RecipeService.getRecipiesAsync();
            return JsonSerializer.Serialize(recipes);;
        }

        public async Task<string> getAccountsAsync()
        {
            List<Account> accounts = await AccountService.GetAccountsAcyns();
            return JsonSerializer.Serialize(accounts);
        }
        
        public async Task<string> getAddresses()
        {
            List<Address> addresses = await AddressService.GetAddressesAcyns();
            return JsonSerializer.Serialize(addresses);
        }
        public async Task<string> getBankInfos()
        {
            List<BankInfo> bankInfos = await BankInfoService.GetBankInfosAcyns();
            return JsonSerializer.Serialize(bankInfos);
        }
        public async Task<string> getIngredientsForRecipe(int receipeint)
        {
            List<Ingredient> recipes = await IngredientService.getIngredientsOfRecipeAsync(receipeint);
            return JsonSerializer.Serialize(recipes);
        }
        
        public async Task addNewOrder(Order order, IList<OrderedShopIngredients> orderedShopIngredients)
        {
            await OrderService.addOrderAsync(order);
            await OrderedShopIngreService.addOrderedShopIngredientsAsync(orderedShopIngredients, order);
        }

        public async Task<Account> Register(Register addAccount)
        {
            Account newAccount = addAccount.account;
            Address newaddress = addAccount.address;
            BankInfo newbankInfo = addAccount.bankInfo;
            await AccountService.addAccountAsync(newAccount);
            await AddressService.saveAddressAsync(newaddress);
            await BankInfoService.addBankInfoAsync(newbankInfo);
            await AccountService.LinkAddress(newAccount, newaddress);
            await AccountService.LinkBankInfo(newAccount, newbankInfo);
            return newAccount;
        }
    }
}