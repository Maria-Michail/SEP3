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
                id = 1,
                username = "Jannik",
                password = "12345",
                firstName = "Jannik",
                lastName = "Schwarz-Wolf",
                streetName = "Chr. M. oelgaardsvej",
                houseNumber = "A2",
                postNumber = 8700,
                age = 23
            },
            new Account{
                id = 2,
                username = "Dumi",
                password = "yup",
                firstName = "Dumi",
                lastName = "to lazy to check",
                streetName = "No clue boulevard",
                houseNumber = "666",
                postNumber = 8700,
                age = 98
            },
        };
        accounts = acs.ToList();
    }
}