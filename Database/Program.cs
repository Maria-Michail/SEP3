using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using Database.Model;
using System.Threading.Tasks;
using Db;
using System.Collections.Generic;

namespace Server
{
    class Program
    {
        async static Task Main(string[] args)
        {
            DbService tmp = new DbService();
            Server server = new Server(tmp);
            /*
            FirstSetup setup = new FirstSetup();
            List<Account> accounts = setup.GetAccounts();
            await tmp.saveAccountAsync(accounts[0]);
            await tmp.saveAccountAsync(accounts[1]);
            */
            server.start();
        }
    }
}