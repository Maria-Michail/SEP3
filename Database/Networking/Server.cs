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

            ReaderWriterDb readerWriterDb = ReaderWriterDb.getInstance();
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

                switch(s){
                    case "GetAccounts":
                    {
                        content = await readerWriterDb.getAccountsAsync();
                        break;
                    }
                    case "GetAddresses":
                    {
                        content = await readerWriterDb.getAddresses();
                        break;
                    }
                    case "GetBankInfos":
                    {
                        content = await readerWriterDb.getBankInfos();
                        break;
                    }
                    case "Register":
                    {
                        string objectString = getClientsObject(stream);
                        Register addAccount= JsonSerializer.Deserialize<Register>(objectString);
                        Account newAccount = await readerWriterDb.Register(addAccount);
                        content = JsonSerializer.Serialize(newAccount);
                        break;
                    }
                    case "GetRecipes":
                    {
                        content = await readerWriterDb.getRecipesAsync();
                        break;
                    }
                    case "GetIngredients":
                    {
                        string objectString = getClientsObject(stream);
                        int recipeint = JsonSerializer.Deserialize<int>(objectString);
                        content = await readerWriterDb.getIngredientsForRecipe(recipeint);
                        break;
                    }
                    case "GetAllIngredients":
                    {
                        content = await readerWriterDb.getIngredientsAsync();
                        break;
                    }
                    case "GetShopIngredients":
                    {
                        content = await readerWriterDb.getShopIngredientsAsync();
                        break;
                    }
                    case "Order":
                    {
                        string objectString = getClientsObject(stream);
                        Order addOrder= JsonSerializer.Deserialize<Order>(objectString);
                        IList<OrderedShopIngredients> newOrderedShopIngredients =
                            addOrder.OrderedShopIngredients;
                        await readerWriterDb.addNewOrder(addOrder, newOrderedShopIngredients);
                        content = JsonSerializer.Serialize("Added order");
                        break;
                    }
                }
                // respond
                byte[] dataToClient = Encoding.ASCII.GetBytes(content);
                stream.Write(dataToClient, 0, dataToClient.Length);
                
                // close connection
                client.Close();
            }
        }

        private String getClientsObject(NetworkStream stream)
        {
            byte[] data1ToClient = Encoding.ASCII.GetBytes("Received");
            stream.Write(data1ToClient, 0, data1ToClient.Length);
            byte[] objectFromClient = new byte[1024];
            int objectRead = stream.Read(objectFromClient, 0, objectFromClient.Length);
            string objectString = Encoding.ASCII.GetString(objectFromClient, 0, objectRead);
            return objectString;
        }

        
    }
}