using Microsoft.EntityFrameworkCore;
using Database.Model;

namespace Db{
    public class DatabaseContext : DbContext{
        public DbSet<Account> accounts{get;set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
            //DatebaseName
            optionsBuilder.UseSqlite(@"Data Source = /Users/wojtek/RiderProjects/SEP3/Database/MainDb.db");
        }
    } 
}