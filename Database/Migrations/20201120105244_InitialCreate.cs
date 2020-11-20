using Microsoft.EntityFrameworkCore.Migrations;

namespace Database.Migrations
{
    public partial class InitialCreate : Migration
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
                    streetNumber = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    city = table.Column<string>(type: "TEXT", maxLength: 45, nullable: false),
                    zipCode = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_addresses", x => new { x.street, x.streetNumber });
                });

            migrationBuilder.CreateTable(
                name: "Amount",
                columns: table => new
                {
                    number = table.Column<double>(type: "REAL", nullable: false),
                    unitType = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Amount", x => x.number);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    category = table.Column<string>(type: "TEXT", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.category);
                });

            migrationBuilder.CreateTable(
                name: "shopIngredients",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    price = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shopIngredients", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "recipes",
                columns: table => new
                {
                    name = table.Column<string>(type: "TEXT", maxLength: 25, nullable: false),
                    instructions = table.Column<string>(type: "TEXT", nullable: true),
                    cookingTime = table.Column<double>(type: "REAL", nullable: false),
                    category = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_recipes", x => x.name);
                    table.ForeignKey(
                        name: "FK_recipes_Category_category",
                        column: x => x.category,
                        principalTable: "Category",
                        principalColumn: "category",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ingredients",
                columns: table => new
                {
                    ingredientId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Amountnumber = table.Column<double>(type: "REAL", nullable: true),
                    Recipename = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ingredients", x => x.ingredientId);
                    table.ForeignKey(
                        name: "FK_ingredients_Amount_Amountnumber",
                        column: x => x.Amountnumber,
                        principalTable: "Amount",
                        principalColumn: "number",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ingredients_recipes_Recipename",
                        column: x => x.Recipename,
                        principalTable: "recipes",
                        principalColumn: "name",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ingredients_Amountnumber",
                table: "ingredients",
                column: "Amountnumber");

            migrationBuilder.CreateIndex(
                name: "IX_ingredients_Recipename",
                table: "ingredients",
                column: "Recipename");

            migrationBuilder.CreateIndex(
                name: "IX_recipes_category",
                table: "recipes",
                column: "category");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "accounts");

            migrationBuilder.DropTable(
                name: "addresses");

            migrationBuilder.DropTable(
                name: "ingredients");

            migrationBuilder.DropTable(
                name: "shopIngredients");

            migrationBuilder.DropTable(
                name: "Amount");

            migrationBuilder.DropTable(
                name: "recipes");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
