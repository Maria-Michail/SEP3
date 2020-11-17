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

namespace Server
{
    class Server{

        private IDbService dbService;
        private string content;
        public Server(IDbService dbService){
            this.dbService = dbService;
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
                    case "GetAccounts":{
                        List<Account> accounts = await dbService.GetAccountsAcyns();
                        content = JsonSerializer.Serialize(accounts);
                        Console.WriteLine(content);
                        break;
                    }
                    case "ValidateUser":{
                        byte[] usernameFromClient = new byte[1024];
                        int usernameRead = stream.Read(usernameFromClient, 0, usernameFromClient.Length);
                        string username = Encoding.ASCII.GetString(usernameFromClient, 0, usernameRead);
                        byte[] passwordFromClient = new byte[1024];
                        int passwordRead = stream.Read(passwordFromClient, 0, passwordFromClient.Length);
                        string password = Encoding.ASCII.GetString(passwordFromClient, 0, passwordRead);
                        Account account = await dbService.ValidateUser(username, password);
                        content = JsonSerializer.Serialize(account);
                        Console.WriteLine(content);
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

    }
}