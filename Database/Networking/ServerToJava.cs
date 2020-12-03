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

                // Receiving
                //byte[] rcvLen = new byte[1024];
                //int i = stream.Read(rcvLen);
                //Console.Write(1);
                byte[] rcvBytes = new byte[1024];
                stream.Read(rcvBytes);
                String rcv = System.Text.Encoding.ASCII.GetString(rcvBytes);

                if (rcv.Contains("getAccounts"))
                {
                    List<Account> accounts = await accountService.GetAccountsAcyns();
                    content = JsonSerializer.Serialize(accounts);
                }
                else if (rcv.Contains("getRecipes"))
                {
                    List<Recipe> recipes = await recipeService.getRecipiesAsync();
                    content = JsonSerializer.Serialize(recipes);
                }
                else if (rcv.Contains("getIngredients"))
                {
                    List<Ingredient> ingredients = await ingredientService.getIngredientsAsync();
                    content = JsonSerializer.Serialize(ingredients);
                }
                else if (rcv.Contains("getShops"))
                {
                    List<Shop> shops = await shopService.getShopsAsync();
                    content = JsonSerializer.Serialize(shops);
                }
                else if (rcv.Contains("getShopIngredients"))
                {
                    List<ShopIngredient> shopIngredients = await shopIngrService.getShopIngredientsAsync();
                    content = JsonSerializer.Serialize(shopIngredients);
                }
                else if (rcv.Contains("addShop"))
                {
                    Shop fromClient = (Shop)getClientsObject(stream, "Shop");
                    Console.WriteLine(fromClient.shopName);
                    //await shopService.addShopAsync(fromClient);
                    Shop temp = new Shop();
                    Console.WriteLine("Fail1");    
                    temp.vares = new List<ShopIngredient>();
                    Console.WriteLine("Fail2");
                    temp.shopName = "Fakta";
                    Console.WriteLine("Fail3");
                    temp.shopAddress.city = "Horsens";
                    Console.WriteLine("Fail4");
                    temp.shopAddress.street = "Langmarksvej 105";
                    Console.WriteLine("Fail5");
                    temp.shopAddress.zipCode = 8700;
                    Console.WriteLine("Fail6");
                    temp.vares = new List<ShopIngredient>();
                    Console.WriteLine("Fail7");
                    temp.shopVares = new List<ShopVare>();
                    Console.WriteLine("Fail8");
                    Console.WriteLine(JsonSerializer.Serialize(temp));
                    content = fromClient.shopName + " added";
                }
                else if (rcv.Contains("removeShop"))
                {
                    Shop fromClient = (Shop) getClientsObject(stream, "Shop");
                    await shopService.removeShopAsync(fromClient.shopName);
                    content = fromClient.shopName + " removed";
                }
                else if (rcv.Contains("updateShop"))
                {
                    Shop fromClient = (Shop) getClientsObject(stream, "Shop");
                    await shopService.updateShopAsync(fromClient);
                    content = fromClient.shopName + " updated";
                }
                else if (rcv.Contains("addIngredient"))
                {
                    Ingredient fromClient = (Ingredient) getClientsObject(stream, "Ingredient");
                    await ingredientService.addIngredientAsync(fromClient);
                    content = fromClient.ingredientName + " added";
                }
                else if (rcv.Contains("removeIngredient"))
                {
                    Ingredient fromClient = (Ingredient) getClientsObject(stream, "Ingredient");
                    await ingredientService.removeIngredientAsync(fromClient);
                    content = fromClient.ingredientName + " removed";
                }
                else if (rcv.Contains("updateIngredient"))
                {
                    Ingredient fromClient = (Ingredient) getClientsObject(stream, "Ingredient");
                    await ingredientService.updateIngredientAsync(fromClient);
                    content = fromClient.ingredientName + " updated";
                }
                else if (rcv.Contains("addRecipe"))
                {
                    
                }
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
                    Console.WriteLine(objectString);
                    Shop objectToReturn = JsonSerializer.Deserialize<Shop>(objectString);
                    Console.WriteLine(objectToReturn.ToString());
                    return objectToReturn;
                }
                case "Recipe":
                {
                    Console.WriteLine(objectString);
                    Recipe objectToReturn = JsonSerializer.Deserialize<Recipe>(objectString);
                    return objectToReturn;
                }
                case "Ingredient":
                {
                    Ingredient objectToReturn = JsonSerializer.Deserialize<Ingredient>(objectString);
                    return objectToReturn;
                }
            }
            return null;
        }
    }
}