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

        private DbService dbService;
        private string content;
        public Server(DbService dbService){
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
                        Console.WriteLine(accounts.Count);
                        content = JsonSerializer.Serialize(accounts);
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