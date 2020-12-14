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
        private Shop shopToLink = new Shop();

        public ServerToJava()
        {
        }
        
        public async void start(){
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

                byte[] rcvBytes = new byte[1024];
                stream.Read(rcvBytes);
                String rcv = System.Text.Encoding.ASCII.GetString(rcvBytes);
                
                //Get methods
                if (rcv.Contains("get"))
                {
                    if (rcv.Contains("Accounts"))
                    {
                        content = await readerWriterDb.getAccountsAsync();
                    }else if (rcv.Contains("ShopIngredients"))
                    {
                        content = await readerWriterDb.getShopIngredientsAsync();

                    }else if (rcv.Contains("Shops"))
                    {
                        content = await readerWriterDb.getShopsAsync();
                    }else if (rcv.Contains("Ingredients"))
                    {
                        content = await readerWriterDb.getIngredientsAsync();
                    }else if (rcv.Contains("Recipes"))
                    {
                        content = await readerWriterDb.getRecipesAsync();
                    }else if (rcv.Contains("Orders"))
                    {
                        content = await readerWriterDb.getOrdersAsync();
                    }else if (rcv.Contains("Categories"))
                    {
                        content = await readerWriterDb.getCategoriesAsync();
                    }
                 //Add methods    
                }else if (rcv.Contains("add"))
                {
                    string subString = rcv.Substring(3);
                    if (rcv.Contains("ShopIngredient"))
                    {
                        content = await readerWriterDb.addObjectAsync(getClientsObject(stream, "ShopIngredient"), "shopIngredient");
                    }else if (rcv.Contains("Ingredient"))
                    {
                        content = await readerWriterDb.addObjectAsync(getClientsObject(stream, "Ingredient"), "ingredient");
                    }else if (rcv.Contains("Shop"))
                    {
                        content = await readerWriterDb.addObjectAsync(getClientsObject(stream, "Shop"), "shop");
                    }else if (rcv.Contains("Recipe"))
                    {
                        content = await readerWriterDb.addObjectAsync(getClientsObject(stream, "Recipe"),
                            "recipe");
                    }
                 //Remove methods   
                }else if (rcv.Contains("remove"))
                {
                    if (rcv.Contains("ShopIngredient"))
                    {
                        content = await readerWriterDb.removeObjectAsync(getClientsObject(stream, "ShopIngredient"),"shopIngredient");
 
                    }
                    else if (rcv.Contains("Ingredient"))
                    {
                        content = await readerWriterDb.removeObjectAsync(getClientsObject(stream, "Ingredient"), "ingredient");
                    }
                    else if (rcv.Contains("Shop"))
                    {
                        content = await readerWriterDb.removeObjectAsync(getClientsObject(stream, "Shop"),"shop");
                    }
                  //Update methods  
                }else if (rcv.Contains("update"))
                {
                    if (rcv.Contains("Shop"))
                    {
                        content = await readerWriterDb.updateObjectAsync(getClientsObject(stream, "Shop"),"shop");
                    }else if (rcv.Contains("Ingredient"))
                    {
                        content = await readerWriterDb.updateObjectAsync(getClientsObject(stream, "Ingredient"),"ingredient");
                    }
                }else if (rcv.Contains("link"))
                {
                    if (rcv.Contains("ShopIngredientToShop1"))
                    {
                        shopToLink = (Shop) getClientsObject(stream, "Shop");
                        content = "received";
                    }else if (rcv.Contains("ShopIngredientToShop2"))
                    {
                        ShopIngredient shopIngredientToLink =(ShopIngredient) getClientsObject(stream, "ShopIngredient");
                        if (shopToLink != null && shopIngredientToLink != null)
                        {
                            content = await readerWriterDb.linkObjectsAsync(shopIngredientToLink,shopToLink,"ShopIngredientToShop");
                        }
                        else
                        {
                            content = "null error";
                        }
                    }
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
                    Shop objectToReturn = JsonSerializer.Deserialize<Shop>(objectString);
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