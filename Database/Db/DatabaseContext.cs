using Microsoft.EntityFrameworkCore;
using Database.Model;

namespace Db{
    public class DatabaseContext : DbContext{
        public DbSet<Account> accounts{get;set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
            //DatebaseName
            optionsBuilder.UseSqlite(@"Data Source = C:\Users\Janni\OneDrive\Skrivebord\SEP3new-main\Database\MainDb.db");
        }
    } 
}