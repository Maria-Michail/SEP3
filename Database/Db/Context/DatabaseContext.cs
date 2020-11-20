using Microsoft.EntityFrameworkCore;
using Database.Model;
using Model;

namespace Db{
    public class DatabaseContext : DbContext{
        public DbSet<Account> accounts{get;set;}
        public DbSet<Ingredient> ingredients { get; set; }
        public DbSet<Recipe> recipes { get; set; }
        public DbSet<ShopIngredient> shopIngredients { get; set; }
        public DbSet<Address> addresses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
            //DatebaseName
            optionsBuilder.UseSqlite(@"Data Source = C:\Users\Janni\OneDrive\Skrivebord\SEP3\Database\MainDb.db");
        }
    } 
}