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
using System.Threading.Tasks;
using Database.Model.Order;
using Model;

namespace Server
{
    class Server{

        private IDbAccountService accountService;
        private IDbRecipeService recipeService;
        private IDbAddressService addresService;
        private IDbShopIngrService shopIngrService;
        private IDbBankInfoService bankInfoService;
        private IDbIngredientService ingredientService;
        private IDbOrderedShopIngreService orderedShopIngService;
        private IDbOrderService orderService;
        private string content;
        public Server(IDbAccountService accountService, IDbRecipeService recipeService, IDbAddressService addresService, IDbShopIngrService shopIngrService, IDbBankInfoService bankInfoService, IDbIngredientService ingredientService, IDbOrderedShopIngreService orderedShopIngService, IDbOrderService orderService){
            this.accountService = accountService;
            this.recipeService = recipeService;
            this.addresService = addresService;
            this.shopIngrService = shopIngrService;
            this.bankInfoService = bankInfoService;
            this.ingredientService = ingredientService;
            this.orderedShopIngService = orderedShopIngService;
            this.orderService = orderService;
        }
        public async Task start(){
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
                // read
                byte[] dataFromClient = new byte[1024];
                int bytesRead = stream.Read(dataFromClient, 0, dataFromClient.Length);
                string s = Encoding.ASCII.GetString(dataFromClient, 0, bytesRead);
                Console.WriteLine(s);

                switch(s){
                    case "GetAccounts":
                    {
                        content = await getAccounts();
                        Console.WriteLine(content);
                        break;
                    }
                    case "GetAddresses":
                    {
                        content = await getAddresses();
                        Console.WriteLine(content);
                        break;
                    }
                    case "GetBankInfos":
                    {
                        content = await getBankInfos();
                        Console.WriteLine(content);
                        break;
                    }
                    case "Register":
                    {
                        byte[] data1ToClient = Encoding.ASCII.GetBytes("Received");
                        stream.Write(data1ToClient, 0, data1ToClient.Length);
                        byte[] objectFromClient = new byte[1024];
                        int objectRead = stream.Read(objectFromClient, 0, objectFromClient.Length);
                        string objectString = Encoding.ASCII.GetString(objectFromClient, 0, objectRead);
                        Register addAccount= JsonSerializer.Deserialize<Register>(objectString);
                        Account newAccount = addAccount.account;
                        Address newaddress = addAccount.address;
                        BankInfo newbankInfo = addAccount.bankInfo;
                        await accountService.addAccountAsync(newAccount);
                        await addresService.saveAddressAsync(newaddress);
                        await bankInfoService.addBankInfoAsync(newbankInfo);
                        await accountService.LinkAddress(newAccount, newaddress);
                        await accountService.LinkBankInfo(newAccount, newbankInfo);
                        
                        content = JsonSerializer.Serialize(newAccount);
                        break;
                    }
                    case "GetRecipes":
                    {
                        content = await getRecipies();
                        Console.WriteLine(content + "-->Database/Networking/Server.cs");
                        break;
                    }
                    case "GetIngredients":
                    {
                        byte[] data1ToClient = Encoding.ASCII.GetBytes("Received");
                        stream.Write(data1ToClient, 0, data1ToClient.Length);
                        byte[] objectFromClient = new byte[1024];
                        int objectRead = stream.Read(objectFromClient, 0, objectFromClient.Length);
                        string objectString = Encoding.ASCII.GetString(objectFromClient, 0, objectRead);
                        int recipeint = JsonSerializer.Deserialize<int>(objectString);

                        content = await getIngredientsForRecipe(recipeint);
                        break;
                    }
                    case "GetAllIngredients":
                    {
                        content = await getAllIngredients();
                        Console.WriteLine(content);
                        break;
                    }
                    case "GetShopIngredients":
                    {
                        content = await getShopIngredients();
                        break;
                    }
                    case "Order":
                    {
                        byte[] data1ToClient = Encoding.ASCII.GetBytes("Received");
                        stream.Write(data1ToClient, 0, data1ToClient.Length);
                        byte[] objectFromClient = new byte[1024];
                        Console.WriteLine(1);
                        int objectRead = stream.Read(objectFromClient, 0, objectFromClient.Length);
                        string objectString = Encoding.ASCII.GetString(objectFromClient, 0, objectRead);
                        Order addOrder= JsonSerializer.Deserialize<Order>(objectString);
                        Console.WriteLine(objectString);
                        IList<OrderedShopIngredients> newOrderedShopIngredients =
                            addOrder.OrderedShopIngredients;
                        await addNewOrder(addOrder, newOrderedShopIngredients);
                        content = JsonSerializer.Serialize(addOrder);
                        break;
                    }
                    
                    /*case "removeAccount":
                    {
                        Account temp = (Account)getClientsObject(stream);
                        await accountService.removeAccountAsync(temp);
                        content = "Account " + temp.username + " removed";
                        break;
                    }
                    case "updateAccount":
                    {
                        Account temp = (Account)getClientsObject(stream);
                        await accountService.updateAccountAsync(temp);
                        content = "Account " + temp.username + " updated";
                        break;
                    }
                    
                    case "getRecipe":
                    {
                        byte[] data1ToClient = Encoding.ASCII.GetBytes("Received");
                        stream.Write(data1ToClient, 0, data1ToClient.Length);
                        byte[] objectFromClient = new byte[20480];
                        int objectRead = stream.Read(objectFromClient, 0, objectFromClient.Length);
                        string recipeName = Encoding.ASCII.GetString(objectFromClient, 0, objectRead);
                        Recipe temp = await recipeService.getRecipeAsync(recipeName);
                        content = JsonSerializer.Serialize(temp);
                        break;
                    }
                    case "addRecipe":
                    {
                        Recipe temp = (Recipe) getClientsObject(stream);
                        await recipeService.addRecipeAsync(temp);
                        content = "Recipe " + temp.recipeName + " added";
                        break;
                    }
                    case "removeRecipe":
                    {
                        Recipe temp = (Recipe) getClientsObject(stream);
                        await recipeService.removeRecipeAsync(temp.recipeName);
                        content = "Recipe" + temp.recipeName + " removed";
                        break;
                    }
                    case "updateRecipe":
                    {
                        Recipe temp = (Recipe) getClientsObject(stream);
                        await recipeService.updateRecipeAsync(temp);
                        content = "Recipe " + temp.recipeName + " updated";
                        break;
                    }
                    case "saveAddress":
                    {
                        Address temp = (Address) getClientsObject(stream);
                        await addresService.saveAddressAsync(temp);
                        content = "Address " + temp.ToString() + " added";
                        break;
                    }
                    case "removeAddress":
                    {
                        Address temp = (Address) getClientsObject(stream);
                        await addresService.removeAddressAsync(temp);
                        content = "Address " + temp.ToString() + " removed";
                        break;
                    }
                    case "updateAddress":
                    {
                        Address temp = (Address) getClientsObject(stream);
                        await addresService.updateAddressAsync(temp);
                        content = "Address " + temp.ToString() + " updated";
                        break;
                    }
                    
                    case "getShopIngredient":
                    {
                        byte[] data1ToClient = Encoding.ASCII.GetBytes("Received");
                        stream.Write(data1ToClient, 0, data1ToClient.Length);
                        byte[] objectFromClient = new byte[1024];
                        int objectRead = stream.Read(objectFromClient, 0, objectFromClient.Length);
                        int shopIngrId = int.Parse(Encoding.ASCII.GetString(objectFromClient, 0, objectRead));
                        ShopIngredient temp = await shopIngrService.getShopIngredientAsync(shopIngrId);
                        content = JsonSerializer.Serialize(temp);
                        break;
                    }
                    case "saveShopIngredient":
                    {
                        ShopIngredient temp = (ShopIngredient) getClientsObject(stream);
                        await shopIngrService.addShopIngredientAsync(temp);
                        content = "ShopIngredient " + temp.name + " added";
                        break;
                    }
                    case "updateShopIngredient":
                    {
                        ShopIngredient temp = (ShopIngredient) getClientsObject(stream);
                        await shopIngrService.updateShopIngredientAsync(temp);
                        content = "ShopIngredient " + temp.name + " updated";
                        break;
                    }
                    case "removeShopIngredient":
                    {
                        ShopIngredient temp = (ShopIngredient) getClientsObject(stream);
                        await shopIngrService.removeShopIngredientAsync(temp);
                        content = "ShopIngredient " + temp.name + " removed";
                        break;
                    }
                    case "ValidateUser":{
                        byte[] data1ToClient = Encoding.ASCII.GetBytes("Received");
                        stream.Write(data1ToClient, 0, data1ToClient.Length);
                        byte[] usernameFromClient = new byte[1024];
                        int usernameRead = stream.Read(usernameFromClient, 0, usernameFromClient.Length);
                        string username = Encoding.ASCII.GetString(usernameFromClient, 0, usernameRead);
                        byte[] data2ToClient = Encoding.ASCII.GetBytes("Received");
                        stream.Write(data2ToClient, 0, data2ToClient.Length);
                        byte[] passwordFromClient = new byte[1024];
                        int passwordRead = stream.Read(passwordFromClient, 0, passwordFromClient.Length);
                        string password = Encoding.ASCII.GetString(passwordFromClient, 0, passwordRead);
                        Account account = await dbService.ValidateUser(username, password);
                        content = JsonSerializer.Serialize(account);
                        Console.WriteLine(content);
                        break;
                    }*/
                }
                
                // respond
                byte[] dataToClient = Encoding.ASCII.GetBytes(content);
                stream.Write(dataToClient, 0, dataToClient.Length);
                
                // close connection
                client.Close();
            }
        }

        private Object getClientsObject(NetworkStream stream)
        {
            byte[] data1ToClient = Encoding.ASCII.GetBytes("Received");
            stream.Write(data1ToClient, 0, data1ToClient.Length);
            byte[] objectFromClient = new byte[1024];
            int objectRead = stream.Read(objectFromClient, 0, objectFromClient.Length);
            string objectString = Encoding.ASCII.GetString(objectFromClient, 0, objectRead);
            Object objectToReturn = JsonSerializer.Deserialize<Object>(objectString);
            return objectToReturn;
        }

        private async Task<string> getAccounts()
        {
            List<Account> accounts = await accountService.GetAccountsAcyns();
            return JsonSerializer.Serialize(accounts);
        }
        private async Task<string> getAddresses()
        {
            List<Address> addresses = await addresService.GetAddressesAcyns();
            return JsonSerializer.Serialize(addresses);
        }
        private async Task<string> getBankInfos()
        {
            List<BankInfo> bankInfos = await bankInfoService.GetBankInfosAcyns();
            return JsonSerializer.Serialize(bankInfos);
        }
        private async Task<string> getRecipies()
        {
            List<Recipe> recipes = await recipeService.getRecipiesAsync();
            return JsonSerializer.Serialize(recipes);
        }
        private async Task<string> getIngredientsForRecipe(int receipeint)
        {
            List<Ingredient> recipes = await ingredientService.getIngredientsOfRecipeAsync(receipeint);
            return JsonSerializer.Serialize(recipes);
        }
        private async Task<string> getAllIngredients()
        {
            List<Ingredient> recipes = await ingredientService.getIngredientsAsync();
            return JsonSerializer.Serialize(recipes);
        }

        private async Task<string> getShopIngredients()
        {
            List<ShopIngredient> shopIngredients = await shopIngrService.getShopIngredientsAsync();
            return JsonSerializer.Serialize(shopIngredients);
        }

        public async Task addNewOrder(Order order, IList<OrderedShopIngredients> orderedShopIngredients)
        {
            OrderTable orderTable = new OrderTable();
            orderTable.dateTime = order.dateTime;
            orderTable.orderPrice = order.orderPrice;
            Account user = await accountService.GetAccountAcyns(order.userName);
            Console.WriteLine(user.username);
            orderTable.Account = user;
            Console.WriteLine(orderTable.ToString());
            
            IList<OrderedIngredient> orderedIngredients = new List<OrderedIngredient>();
            foreach (var orderedShop in orderedShopIngredients)
            {
                OrderedIngredient orderedIngredient = new OrderedIngredient();
                orderedIngredient.totalPrice = orderedShop.totalPrice;
                orderedIngredient.amount = orderedShop.amount;
                orderedIngredient.ShopIngredient = orderedShop.ShopIngredient;
                orderedIngredient.OrderTable = orderTable;
                orderedIngredients.Add(orderedIngredient);
            }
            await orderService.addOrderAsync(orderTable);
            await orderedShopIngService.addOrderedShopIngredientsAsync(orderedIngredients);
            
        }
    }
}