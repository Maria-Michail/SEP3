using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Migrations
{
    public partial class initialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "accounts",
                columns: table => new
                {
                    username = table.Column<string>(type: "TEXT", maxLength: 12, nullable: false),
                    password = table.Column<string>(type: "TEXT", maxLength: 12, nullable: false),
                    email = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_accounts", x => x.username);
                });

            migrationBuilder.CreateTable(
                name: "addresses",
                columns: table => new
                {
                    street = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    city = table.Column<string>(type: "TEXT", maxLength: 45, nullable: false),
                    zipCode = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_addresses", x => x.street);
                });

            migrationBuilder.CreateTable(
                name: "bankInfos",
                columns: table => new
                {
                    cardNumber = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    cardHolder = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bankInfos", x => x.cardNumber);
                });

            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    categoryName = table.Column<string>(type: "TEXT", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.categoryName);
                });

            migrationBuilder.CreateTable(
                name: "AccountAddresses",
                columns: table => new
                {
                    username = table.Column<string>(type: "TEXT", nullable: false),
                    street = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountAddresses", x => new { x.username, x.street });
                    table.ForeignKey(
                        name: "FK_AccountAddresses_accounts_username",
                        column: x => x.username,
                        principalTable: "accounts",
                        principalColumn: "username",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccountAddresses_addresses_street",
                        column: x => x.street,
                        principalTable: "addresses",
                        principalColumn: "street",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "shops",
                columns: table => new
                {
                    shopId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    shopName = table.Column<string>(type: "TEXT", maxLength: 25, nullable: false),
                    shopAddressstreet = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shops", x => x.shopId);
                    table.ForeignKey(
                        name: "FK_shops_addresses_shopAddressstreet",
                        column: x => x.shopAddressstreet,
                        principalTable: "addresses",
                        principalColumn: "street",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AccountBankInfos",
                columns: table => new
                {
                    username = table.Column<string>(type: "TEXT", nullable: false),
                    cardNumber = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountBankInfos", x => new { x.username, x.cardNumber });
                    table.ForeignKey(
                        name: "FK_AccountBankInfos_accounts_username",
                        column: x => x.username,
                        principalTable: "accounts",
                        principalColumn: "username",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccountBankInfos_bankInfos_cardNumber",
                        column: x => x.cardNumber,
                        principalTable: "bankInfos",
                        principalColumn: "cardNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "recipes",
                columns: table => new
                {
                    recipeId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    recipeName = table.Column<string>(type: "TEXT", maxLength: 25, nullable: false),
                    description = table.Column<string>(type: "TEXT", nullable: false),
                    instructions = table.Column<string>(type: "TEXT", nullable: false),
                    cookingTime = table.Column<int>(type: "INTEGER", nullable: false),
                    imageName = table.Column<string>(type: "TEXT", nullable: false),
                    categoryName = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_recipes", x => x.recipeId);
                    table.ForeignKey(
                        name: "FK_recipes_categories_categoryName",
                        column: x => x.categoryName,
                        principalTable: "categories",
                        principalColumn: "categoryName",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "shopIngredients",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    price = table.Column<double>(type: "REAL", nullable: false),
                    amount = table.Column<double>(type: "REAL", nullable: false),
                    unitType = table.Column<string>(type: "TEXT", maxLength: 40, nullable: false),
                    shopId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shopIngredients", x => x.id);
                    table.ForeignKey(
                        name: "FK_shopIngredients_shops_shopId",
                        column: x => x.shopId,
                        principalTable: "shops",
                        principalColumn: "shopId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ingredients",
                columns: table => new
                {
                    ingredientId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ingredientName = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    number = table.Column<double>(type: "REAL", nullable: false),
                    unitType = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    recipeId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ingredients", x => x.ingredientId);
                    table.ForeignKey(
                        name: "FK_ingredients_recipes_recipeId",
                        column: x => x.recipeId,
                        principalTable: "recipes",
                        principalColumn: "recipeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RecipeCategories",
                columns: table => new
                {
                    recipeId = table.Column<int>(type: "INTEGER", nullable: false),
                    categoryName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeCategories", x => new { x.categoryName, x.recipeId });
                    table.ForeignKey(
                        name: "FK_RecipeCategories_categories_categoryName",
                        column: x => x.categoryName,
                        principalTable: "categories",
                        principalColumn: "categoryName",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecipeCategories_recipes_recipeId",
                        column: x => x.recipeId,
                        principalTable: "recipes",
                        principalColumn: "recipeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShopVare",
                columns: table => new
                {
                    shopId = table.Column<int>(type: "INTEGER", nullable: false),
                    shopIngredientId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopVare", x => new { x.shopId, x.shopIngredientId });
                    table.ForeignKey(
                        name: "FK_ShopVare_shopIngredients_shopIngredientId",
                        column: x => x.shopIngredientId,
                        principalTable: "shopIngredients",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShopVare_shops_shopId",
                        column: x => x.shopId,
                        principalTable: "shops",
                        principalColumn: "shopId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IngredientRecipes",
                columns: table => new
                {
                    recipeId = table.Column<int>(type: "INTEGER", nullable: false),
                    ingredientId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientRecipes", x => new { x.ingredientId, x.recipeId });
                    table.ForeignKey(
                        name: "FK_IngredientRecipes_ingredients_ingredientId",
                        column: x => x.ingredientId,
                        principalTable: "ingredients",
                        principalColumn: "ingredientId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IngredientRecipes_recipes_recipeId",
                        column: x => x.recipeId,
                        principalTable: "recipes",
                        principalColumn: "recipeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountAddresses_street",
                table: "AccountAddresses",
                column: "street");

            migrationBuilder.CreateIndex(
                name: "IX_AccountBankInfos_cardNumber",
                table: "AccountBankInfos",
                column: "cardNumber");

            migrationBuilder.CreateIndex(
                name: "IX_IngredientRecipes_recipeId",
                table: "IngredientRecipes",
                column: "recipeId");

            migrationBuilder.CreateIndex(
                name: "IX_ingredients_recipeId",
                table: "ingredients",
                column: "recipeId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeCategories_recipeId",
                table: "RecipeCategories",
                column: "recipeId");

            migrationBuilder.CreateIndex(
                name: "IX_recipes_categoryName",
                table: "recipes",
                column: "categoryName");

            migrationBuilder.CreateIndex(
                name: "IX_shopIngredients_shopId",
                table: "shopIngredients",
                column: "shopId");

            migrationBuilder.CreateIndex(
                name: "IX_shops_shopAddressstreet",
                table: "shops",
                column: "shopAddressstreet");

            migrationBuilder.CreateIndex(
                name: "IX_ShopVare_shopIngredientId",
                table: "ShopVare",
                column: "shopIngredientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountAddresses");

            migrationBuilder.DropTable(
                name: "AccountBankInfos");

            migrationBuilder.DropTable(
                name: "IngredientRecipes");

            migrationBuilder.DropTable(
                name: "RecipeCategories");

            migrationBuilder.DropTable(
                name: "ShopVare");

            migrationBuilder.DropTable(
                name: "accounts");

            migrationBuilder.DropTable(
                name: "bankInfos");

            migrationBuilder.DropTable(
                name: "ingredients");

            migrationBuilder.DropTable(
                name: "shopIngredients");

            migrationBuilder.DropTable(
                name: "recipes");

            migrationBuilder.DropTable(
                name: "shops");

            migrationBuilder.DropTable(
                name: "categories");

            migrationBuilder.DropTable(
                name: "addresses");
        }
    }
}
