using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using Database.Model;
using System.Text.Json;
using System.IO;
using Db;
using Model;
using System.Text.Json;

namespace Database.Networking{
    class ServerToJava{

        private string content;
        private IDbAccountService accountService;
        private IDbRecipeService recipeService;
        private IDbIngredientService ingredientService;
        private IDbShopService shopService;
        private IDbShopIngrService shopIngrService;
        private Shop shopToLink = new Shop();

        public ServerToJava(IDbAccountService accountService, IDbRecipeService recipeService, IDbIngredientService ingredientService, IDbShopService shopService, IDbShopIngrService shopIngrService)
        {
            this.accountService = accountService;
            this.recipeService = recipeService;
            this.ingredientService = ingredientService;
            this.shopService = shopService;
            this.shopIngrService = shopIngrService;
        }
        public async void start(){
            Console.WriteLine("Starting server...");

            IPAddress ip = IPAddress.Parse("127.0.0.1");

            TcpListener listener = new TcpListener(ip, 2920);
            listener.Start();

            Console.WriteLine("Server started...");
            while (true)
            {
                TcpClient client = listener.AcceptTcpClient();
                Console.WriteLine("Client connected");
                NetworkStream stream = client.GetStream();

                byte[] rcvBytes = new byte[1024];
                stream.Read(rcvBytes);
                String rcv = System.Text.Encoding.ASCII.GetString(rcvBytes);
                
                //Get methods
                if (rcv.Contains("get"))
                {
                    if (rcv.Contains("Accounts"))
                    {
                        Console.WriteLine("Inside: Get Accounts");
                        List<Account> accounts = await accountService.GetAccountsAcyns();
                        content = JsonSerializer.Serialize(accounts);
                    }else if (rcv.Contains("ShopIngredients"))
                    {
                        Console.WriteLine("Inside: Get ShopIngredients");
                        List<ShopIngredient> shopIngredients = await shopIngrService.getShopIngredientsAsync();
                        content = JsonSerializer.Serialize(shopIngredients);

                    }else if (rcv.Contains("Shops"))
                    {
                        Console.WriteLine("Inside: Get Shops");
                        List<Shop> shops = await shopService.getShopsAsync();
                        content = JsonSerializer.Serialize(shops);
                    }else if (rcv.Contains("Ingredients"))
                    {
                        Console.WriteLine("Inside: Get Ingredients");
                        List<Ingredient> ingredients = await ingredientService.getIngredientsAsync();
                        content = JsonSerializer.Serialize(ingredients);
                    }else if (rcv.Contains("Recipes"))
                    {
                        Console.WriteLine("Inside: Get Recipes");
                        List<Recipe> recipes = await recipeService.getRecipiesAsync();
                        content = JsonSerializer.Serialize(recipes);
                    }
                 //Add methods    
                }else if (rcv.Contains("add"))
                {
                    string subString = rcv.Substring(3);
                    if (rcv.Contains("ShopIngredient"))
                    {
                        Console.WriteLine("Inside: Add ShopIngredient");
                        ShopIngredient fromClient = (ShopIngredient) getClientsObject(stream, "ShopIngredient");
                        await shopIngrService.addShopIngredientAsync(fromClient);
                        content = fromClient.name + " added";
                    }else if (rcv.Contains("Ingredient"))
                    {
                        Console.WriteLine("Inside: Add Ingredient");
                        Ingredient fromClient = (Ingredient) getClientsObject(stream, "Ingredient");
                        await ingredientService.addIngredientAsync(fromClient);
                        content = fromClient.ingredientName + " added";
                    }else if (rcv.Contains("Shop"))
                    {
                        Console.WriteLine("Inside: Add Shop");
                        Shop fromClient = (Shop)getClientsObject(stream, "Shop");
                        await shopService.addShopAsync(fromClient);
                        content = fromClient.shopName + " added";
                    }else if (rcv.Contains("Recipe"))
                    {
                        Console.WriteLine("Inside: Add Shop");
                        Recipe fromClient = (Recipe) getClientsObject(stream, "Recipe");
                        await recipeService.addRecipeAsync(fromClient);
                        content = fromClient.recipeName + " added";
                    }
                 //Remove methods   
                }else if (rcv.Contains("remove"))
                {
                    if (rcv.Contains("ShopIngredient"))
                    {
                        Console.WriteLine("Inside: Remove ShopIngredient");
                        ShopIngredient fromClient = (ShopIngredient) getClientsObject(stream, "ShopIngredient");
                        Console.WriteLine(fromClient);
                        await shopIngrService.removeShopIngredientAsync(fromClient);
                        content = fromClient.name + " removed";
 
                    }
                    else if (rcv.Contains("Ingredient"))
                    {
                        Console.WriteLine("Inside: Remove ingredient");
                        Ingredient fromClient = (Ingredient) getClientsObject(stream, "Ingredient");
                        await ingredientService.removeIngredientAsync(fromClient);
                        content = fromClient.ingredientName + " removed";
                    }
                    else if (rcv.Contains("Shop"))
                    {
                        Console.WriteLine("Inside: Remove Shop");
                        Shop fromClient = (Shop) getClientsObject(stream, "Shop");
                        await shopService.removeShopAsync(fromClient.shopName);
                        content = fromClient.shopName + " removed";
                    }
                  //Update methods  
                }else if (rcv.Contains("update"))
                {
                    if (rcv.Contains("Shop"))
                    {
                        Console.WriteLine("Inside: update Shop");
                        Shop fromClient = (Shop) getClientsObject(stream, "Shop");
                        await shopService.updateShopAsync(fromClient);
                        content = fromClient.shopName + " updated";
                    }else if (rcv.Contains("Ingredient"))
                    {
                        Console.WriteLine("Inside: update Ingredient");
                        Shop fromClient = (Shop) getClientsObject(stream, "Shop");
                        await shopService.updateShopAsync(fromClient);
                        content = fromClient.shopName + " updated";
                    }
                }else if (rcv.Contains("link"))
                {
                    Console.WriteLine("Inside: Link");
                    if (rcv.Contains("ShopIngredientToShop1"))
                    {
                        shopToLink = (Shop) getClientsObject(stream, "Shop");
                        content = "received";
                    }else if (rcv.Contains("ShopIngredientToShop2"))
                    {
                        ShopIngredient shopIngredientToLink =(ShopIngredient) getClientsObject(stream, "ShopIngredient");
                        if (shopToLink != null && shopIngredientToLink != null)
                        {
                            await shopService.linkShopVareAsync(shopToLink.shopId, shopIngredientToLink.id);
                            content = "linked";
                        }
                        else
                        {
                            content = "null error";
                        }
                    }
                }
                
                Console.WriteLine("End of If: " + content);
                // Sending
                byte[] toSendBytes = System.Text.Encoding.ASCII.GetBytes(content);
                stream.Write(toSendBytes);

                client.Close();
            }
        }
        
        private Object getClientsObject(NetworkStream stream, String toConvert)
        {
            byte[] data1ToClient = Encoding.ASCII.GetBytes("Ready");
            stream.Write(data1ToClient, 0, data1ToClient.Length);
            byte[] objectFromClient = new byte[1024];
            int objectRead = stream.Read(objectFromClient, 0, objectFromClient.Length);
            string objectString = Encoding.ASCII.GetString(objectFromClient, 0, objectRead);
            switch (toConvert)
            {
                case "Shop":
                {
                    Shop objectToReturn = JsonSerializer.Deserialize<Shop>(objectString);
                    Console.WriteLine(objectToReturn.ToString());
                    return objectToReturn;
                }
                case "Recipe":
                {
                    Recipe objectToReturn = JsonSerializer.Deserialize<Recipe>(objectString);
                    return objectToReturn;
                }
                case "Ingredient":
                {
                    Ingredient objectToReturn = JsonSerializer.Deserialize<Ingredient>(objectString);
                    return objectToReturn;
                }
                case "ShopIngredient":
                {
                    ShopIngredient objectToReturn = JsonSerializer.Deserialize<ShopIngredient>(objectString);
                    return objectToReturn;
                }
            }
            return null;
        }
    }
}