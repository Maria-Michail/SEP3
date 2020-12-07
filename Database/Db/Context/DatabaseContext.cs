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
        
        public DbSet<Category> categories { get; set; }
        public DbSet<Shop> shops { get; set; }

        public DbSet<AccountAddress> AccountAddresses { get; set; }
        public DbSet<AccountBankInfo> AccountBankInfos { get; set; }
        public DbSet<RecipeCategory> RecipeCategories { get; set; }
        public DbSet<IngredientRecipe> IngredientRecipes { get; set; }
        public DbSet<ShopVare> ShopVares { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
            //DatebaseName

            optionsBuilder.UseSqlite(@"Data Source = /Users/wojtek/RiderProjects/SEP3/Database/MainDb.db");

        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Account and address many-to-many
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


            //account and bankinfo many-to-many
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
            
            
            //Recipe and Category many-to-many
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<RecipeCategory>()
                .HasKey(sc =>
                    new
                    {
                        sc.categoryName,
                        sc.recipeId
                    }
                );
            modelBuilder.Entity<RecipeCategory>()
                .HasOne(recipeCategory => recipeCategory.category)
                .WithMany(category =>category.RecipeCategories)
                .HasForeignKey(recipeCategory => recipeCategory.categoryName);

            modelBuilder.Entity<RecipeCategory>()
                .HasOne(recipeCategory => recipeCategory.recipe)
                .WithMany(recipe => recipe.RecipeCategories)
                .HasForeignKey(recipeCategory => recipeCategory.recipeId);
            
            
            //Recipe and Ingredient many-to-many
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<IngredientRecipe>()
                .HasKey(sc =>
                    new
                    {
                        sc.ingredientId,
                        sc.recipeId
                    }
                );
            modelBuilder.Entity<IngredientRecipe>()
                .HasOne(ingredientRecipe => ingredientRecipe.ingredient)
                .WithMany(ingredient => ingredient.IngredientRecipes)
                .HasForeignKey(recipeCategory => recipeCategory.ingredientId);

            modelBuilder.Entity<IngredientRecipe>()
                .HasOne(ingredientRecipe => ingredientRecipe.recipe)
                .WithMany(recipe => recipe.IngredientRecipes)
                .HasForeignKey(recipeCategory => recipeCategory.recipeId);
            
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ShopVare>()
                .HasKey(sc =>
                    new
                    {
                        sc.shopId,
                        sc.id
                    }
                );
            modelBuilder.Entity<ShopVare>()
                .HasOne(shopVare => shopVare.shop)
                .WithMany(shop => shop.shopVares)
                .HasForeignKey(shopVare => shopVare.shopId);

            modelBuilder.Entity<ShopVare>()
                .HasOne(shopVare => shopVare.shopIngredient)
                .WithMany(shopIngredient => shopIngredient.shopVares)
                .HasForeignKey(shopVare => shopVare.id);
        }
    } 
}