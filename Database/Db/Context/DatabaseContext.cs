using Microsoft.EntityFrameworkCore;
using Database.Model;
using Model;
using SQLitePCL;
using System.Linq.Expressions;

namespace Db{
    public class DatabaseContext : DbContext{
        public DbSet<Account> accounts{get;set;}
        public DbSet<Ingredient> ingredients { get; set; }
        public DbSet<Recipe> recipes { get; set; }
        public DbSet<ShopIngredient> shopIngredients { get; set; }
        public DbSet<Address> addresses { get; set; }
        
        public DbSet<BankInfo> bankInfos { get; set; }

        public DbSet<AccountAddress> AccountAddresses { get; set; }
        public DbSet<AccountBankInfo> AccountBankInfos { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
            //DatebaseName
            optionsBuilder.UseSqlite(@"Data Source = C:\Users\jtyta\RiderProjects\SEP3v5\Database\MainDb.db");
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<AccountAddress>()
                .HasKey(sc =>
                    new
                    {
                        sc.username,
                        sc.street
                    }
                );
            
            modelBuilder.Entity<AccountAddress>()
                .HasOne(accountAddress => accountAddress.address)
                .WithMany(address => address.AccountAddresses)
                .HasForeignKey(accountAddress => accountAddress.street);

            modelBuilder.Entity<AccountAddress>()
                .HasOne(accountAddress => accountAddress.account)
                .WithMany(account => account.AccountAddresses)
                .HasForeignKey(accountAddress => accountAddress.username);


            
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<AccountBankInfo>()
                .HasKey(sc =>
                    new
                    {
                        sc.username,
                        sc.cardNumber
                    }
                );
            modelBuilder.Entity<AccountBankInfo>()
                .HasOne(accountBankInfo => accountBankInfo.bankInfo)
                .WithMany(bankInfo => bankInfo.AccountBankInfos)
                .HasForeignKey(accountBankInfo => accountBankInfo.cardNumber);

            modelBuilder.Entity<AccountBankInfo>()
                .HasOne(accountBankInfo => accountBankInfo.account)
                .WithMany(account => account.AccountBankInfos)
                .HasForeignKey(accountBankInfo => accountBankInfo.username);

            
           // modelBuilder.Entity<Address>()
               //  .HasKey(c => new { c.street, c.streetNumber });
        }
    } 
}