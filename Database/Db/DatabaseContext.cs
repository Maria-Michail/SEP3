using Microsoft.EntityFrameworkCore;
using Database.Model;
using Model;

namespace Db{
    public class DatabaseContext : DbContext{
        public DbSet<Account> Accounts{get;set;}
        public DbSet<Recipe> Recipes { get; set; }
        
        public DbSet<Ingredient> ExistingIngredients { get; set; } 

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
            //DatebaseName
            optionsBuilder.UseSqlite(@"Data Source = C:\Users\Janni\OneDrive\Skrivebord\SEP3Code\Database\MainDb.db");
        }
    } 
}