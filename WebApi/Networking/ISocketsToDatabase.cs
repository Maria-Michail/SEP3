using System;
using Database.Model;
using Model;

namespace WebApi.Networking
{
    public interface ISocketsToDatabase
    {
        Object getAccounts();
        Object getAddresses();
        Object getBankInfos();
        Object AddAccount(Register register);
        Object getRecipes();
        Object getIngredients(int id);
        Object getAllIngredients();
        Object getShopIngredients();
        void AddOrder(Order order);
        

    }
}