using Microsoft.EntityFrameworkCore;
using Database.Model;

namespace Db{
    public class DatabaseContext : DbContext{
        public DbSet<Account> accounts{get;set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
            //DatebaseName
            optionsBuilder.UseSqlite(@"Data Source = C:\Users\maria\OneDrive\Documents\Rider\SEP3\SEP3\Database\MainDb.db");
        }
    } 
}