using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Database.Model;

public class FirstSetup{

    private string accountsFIle = "accounts.json";
    private IList<Account> accounts;

    public FirstSetup(){
        if(!File.Exists(accountsFIle)){
            Seed();
            WriteToAccounts();
        }else{
            string content = File.ReadAllText(accountsFIle);
            accounts = JsonSerializer.Deserialize<List<Account>>(content); 
        }
    }

    public List<Account> GetAccounts(){
        List<Account> tmp = new List<Account>(accounts);
        return tmp;
    }

    private void WriteToAccounts()
    {
        string productAsJson = JsonSerializer.Serialize(accounts);
        File.WriteAllText(accountsFIle,productAsJson);
    }

    private void Seed()
    {
        Account[] acs = {
            new Account{
                username = "Jannik",
                password = "12345",
                email = "Jannik@viauc.dk",
            },
            new Account{
                username = "Dumi",
                password = "yup",
                email = "Dumi@viauc.dk",
            },
        };
        accounts = acs.ToList();
    }
}