using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using Model;


namespace WebApi.Networking {
class SocketsToDatabase {
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
    public Object ValidateUser(string username, string password) {
        Console.WriteLine("Starting client..");

        TcpClient client = new TcpClient("127.0.0.1", 2920);

        NetworkStream stream = client.GetStream();

        byte[] dataToServer = Encoding.ASCII.GetBytes("ValidateUser");
        stream.Write(dataToServer, 0, dataToServer.Length);
        byte[] userToBytes = Encoding.ASCII.GetBytes(username);
        byte[] passwordToBytes = Encoding.ASCII.GetBytes(password);
        stream.Write(userToBytes, 0, userToBytes.Length);
        stream.Write(passwordToBytes, 0, passwordToBytes.Length);

        byte[] dataFromServer = new byte[1024];
        int bytesRead = stream.Read(dataFromServer, 0, dataFromServer.Length);
        string response = Encoding.ASCII.GetString(dataFromServer, 0, bytesRead);
        Account request = JsonSerializer.Deserialize<Account>(response);
        Console.WriteLine(request);
        
        stream.Close();
        client.Close();
        return request;
    }
}
}