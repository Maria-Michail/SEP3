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
        private DbAccountService accountService;

        public ServerToJava(DbAccountService accountService)
        {
            this.accountService = accountService;
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

                switch (rcv) {
                    case "getAccounts":
                    {
                        List<Account> accounts = await accountService.GetAccountsAcyns();
                        content = JsonSerializer.Serialize(accounts);
                        break;
                    }
                }
                // Sending
                byte[] toSendBytes = System.Text.Encoding.ASCII.GetBytes(content);
                stream.Write(toSendBytes);

                client.Close();
            }
        }

    }
}