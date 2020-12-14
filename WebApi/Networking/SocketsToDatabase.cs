using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using Database.Model;
using Model;


namespace WebApi.Networking {
class SocketsToDatabase : ISocketsToDatabase{
    public Object getAccounts() {
        Console.WriteLine("Starting client..");

        TcpClient client = new TcpClient("127.0.0.1", 2920);

        NetworkStream stream = client.GetStream();

        byte[] dataToServer = Encoding.ASCII.GetBytes("GetAccounts");
        stream.Write(dataToServer, 0, dataToServer.Length);

        byte[] dataFromServer = new byte[1024];
        int bytesRead = stream.Read(dataFromServer, 0, dataFromServer.Length);
        string response = Encoding.ASCII.GetString(dataFromServer, 0, bytesRead);
        IList<Account> request = JsonSerializer.Deserialize<List<Account>>(response);
        Console.WriteLine(request);
        
        stream.Close();
        client.Close();
        return request;
    }
    public Object getAddresses() {
        Console.WriteLine("Starting client..");

        TcpClient client = new TcpClient("127.0.0.1", 2920);

        NetworkStream stream = client.GetStream();

        byte[] dataToServer = Encoding.ASCII.GetBytes("GetAddresses");
        stream.Write(dataToServer, 0, dataToServer.Length);

        byte[] dataFromServer = new byte[1024];
        int bytesRead = stream.Read(dataFromServer, 0, dataFromServer.Length);
        string response = Encoding.ASCII.GetString(dataFromServer, 0, bytesRead);
        IList<Address> request = JsonSerializer.Deserialize<List<Address>>(response);
        Console.WriteLine(request);
        
        stream.Close();
        client.Close();
        return request;
    }
    public Object getBankInfos() {
        Console.WriteLine("Starting client..");

        TcpClient client = new TcpClient("127.0.0.1", 2920);

        NetworkStream stream = client.GetStream();

        byte[] dataToServer = Encoding.ASCII.GetBytes("GetBankInfos");
        stream.Write(dataToServer, 0, dataToServer.Length);

        byte[] dataFromServer = new byte[1024];
        int bytesRead = stream.Read(dataFromServer, 0, dataFromServer.Length);
        string response = Encoding.ASCII.GetString(dataFromServer, 0, bytesRead);
        IList<BankInfo> request = JsonSerializer.Deserialize<List<BankInfo>>(response);
        Console.WriteLine(request);
        
        stream.Close();
        client.Close();
        return request;
    }

    public Object AddAccount(Register register) {
        Console.WriteLine("Starting client..");

        TcpClient client = new TcpClient("127.0.0.1", 2920);

        NetworkStream stream = client.GetStream();

        byte[] dataToServer = Encoding.ASCII.GetBytes("Register");
        stream.Write(dataToServer, 0, dataToServer.Length);
        
        byte[] messageReceived = new byte[1024];
        int messageRead = stream.Read(messageReceived, 0, messageReceived.Length);
        
        string accountSerialize = JsonSerializer.Serialize(register);
        Console.WriteLine(accountSerialize);
        byte[] accountToServer = Encoding.ASCII.GetBytes(accountSerialize);
        stream.Write(accountToServer, 0, accountToServer.Length);

        byte[] dataFromServer = new byte[1024];
        int bytesRead = stream.Read(dataFromServer, 0, dataFromServer.Length);
        string response = Encoding.ASCII.GetString(dataFromServer, 0, bytesRead);
        Account request = JsonSerializer.Deserialize<Account>(response);
        Console.WriteLine(request);
        
        stream.Close();
        client.Close();
        return request;
    }
    
    public Object getRecipes() {
        Console.WriteLine("Starting client..");

        TcpClient client = new TcpClient("127.0.0.1", 2920);

        NetworkStream stream = client.GetStream();

        byte[] dataToServer = Encoding.ASCII.GetBytes("GetRecipes");
        stream.Write(dataToServer, 0, dataToServer.Length);

        byte[] dataFromServer = new byte[20480];
        int bytesRead = stream.Read(dataFromServer, 0, dataFromServer.Length);
        string response = Encoding.ASCII.GetString(dataFromServer, 0, bytesRead);
        Console.WriteLine(response);
        IList<Recipe> request = JsonSerializer.Deserialize<List<Recipe>>(response);
        Console.WriteLine(request.ToString() + "--> WebApi/Networking/SocketsToDatabase.cs");
        
        stream.Close();
        client.Close();
        return request;
    }
    
    public Object getIngredients(int id) {
        Console.WriteLine("Starting client..");

        TcpClient client = new TcpClient("127.0.0.1", 2920);

        NetworkStream stream = client.GetStream();

        byte[] dataToServer = Encoding.ASCII.GetBytes("GetIngredients");
        stream.Write(dataToServer, 0, dataToServer.Length);
        
        byte[] messageReceived = new byte[1024];
        int messageRead = stream.Read(messageReceived, 0, messageReceived.Length);
        
        string accountSerialize = JsonSerializer.Serialize(id);
        Console.WriteLine(accountSerialize);
        byte[] accountToServer = Encoding.ASCII.GetBytes(accountSerialize);
        stream.Write(accountToServer, 0, accountToServer.Length);

        byte[] dataFromServer = new byte[1024];
        int bytesRead = stream.Read(dataFromServer, 0, dataFromServer.Length);
        string response = Encoding.ASCII.GetString(dataFromServer, 0, bytesRead);
        IList<Ingredient> request = JsonSerializer.Deserialize<List<Ingredient>>(response);
        Console.WriteLine(request);
        
        stream.Close();
        client.Close();
        return request;
    }
    public Object getAllIngredients() {
        Console.WriteLine("Starting client..");

        TcpClient client = new TcpClient("127.0.0.1", 2920);

        NetworkStream stream = client.GetStream();

        byte[] dataToServer = Encoding.ASCII.GetBytes("GetAllIngredients");
        stream.Write(dataToServer, 0, dataToServer.Length);

        byte[] dataFromServer = new byte[1024];
        int bytesRead = stream.Read(dataFromServer, 0, dataFromServer.Length);
        string response = Encoding.ASCII.GetString(dataFromServer, 0, bytesRead);
        IList<Ingredient> request = JsonSerializer.Deserialize<List<Ingredient>>(response);
        Console.WriteLine(request);
        
        stream.Close();
        client.Close();
        return request;
    }
    
    public Object getShopIngredients() {
        Console.WriteLine("Starting client..");

        TcpClient client = new TcpClient("127.0.0.1", 2920);

        NetworkStream stream = client.GetStream();

        byte[] dataToServer = Encoding.ASCII.GetBytes("GetShopIngredients");
        stream.Write(dataToServer, 0, dataToServer.Length);

        byte[] dataFromServer = new byte[1024];
        int bytesRead = stream.Read(dataFromServer, 0, dataFromServer.Length);
        string response = Encoding.ASCII.GetString(dataFromServer, 0, bytesRead);
        IList<ShopIngredient> request = JsonSerializer.Deserialize<List<ShopIngredient>>(response);
        
        stream.Close();
        client.Close();
        return request;
    }
    
    public void AddOrder(Order order) {
        Console.WriteLine("Starting client..");

        TcpClient client = new TcpClient("127.0.0.1", 2920);

        NetworkStream stream = client.GetStream();

        byte[] dataToServer = Encoding.ASCII.GetBytes("Order");
        stream.Write(dataToServer, 0, dataToServer.Length);
        
        byte[] messageReceived = new byte[1024];
        int messageRead = stream.Read(messageReceived, 0, messageReceived.Length);
        
        string accountSerialize = JsonSerializer.Serialize(order);
        Console.WriteLine(accountSerialize);
        byte[] accountToServer = Encoding.ASCII.GetBytes(accountSerialize);
        stream.Write(accountToServer, 0, accountToServer.Length);

        byte[] dataFromServer = new byte[1024];
        int bytesRead = stream.Read(dataFromServer, 0, dataFromServer.Length);
        string response = Encoding.ASCII.GetString(dataFromServer, 0, bytesRead);
        String request = JsonSerializer.Deserialize<String>(response);
        Console.WriteLine(request);
        
        stream.Close();
        client.Close();
    }

    public object getOrders()
    {
        Console.WriteLine("Starting client..");

        TcpClient client = new TcpClient("127.0.0.1", 2920);

        NetworkStream stream = client.GetStream();

        byte[] dataToServer = Encoding.ASCII.GetBytes("GetOrders");
        stream.Write(dataToServer, 0, dataToServer.Length);

        byte[] dataFromServer = new byte[50000];
        int bytesRead = stream.Read(dataFromServer, 0, dataFromServer.Length);
        string response = Encoding.ASCII.GetString(dataFromServer, 0, bytesRead);
        IList<Order> request = JsonSerializer.Deserialize<List<Order>>(response);
        
        stream.Close();
        client.Close();
        return request;
    }
    
}
}