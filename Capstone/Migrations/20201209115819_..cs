using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Capstone.Migrations
{
    public partial class _ : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Restaurant",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int(10)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ResName = table.Column<string>(type: "varchar(75)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_general_ci"),
                    ResUsername = table.Column<string>(type: "varchar(30)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_general_ci"),
                    Email = table.Column<string>(type: "varchar(64)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_general_ci"),
                    Password = table.Column<string>(type: "varchar(50)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_general_ci"),
                    ResLocation = table.Column<string>(type: "varchar(75)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurant", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int(10)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RestaurantID = table.Column<int>(type: "int(10)", nullable: false),
                    Name = table.Column<string>(type: "varchar(45)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Category_Restaurant",
                        column: x => x.RestaurantID,
                        principalTable: "Restaurant",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MenuItem",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int(10)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RestaurantID = table.Column<int>(type: "int(10)", nullable: false),
                    CategoryID = table.Column<int>(type: "int(10)", nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_general_ci"),
                    Description = table.Column<string>(type: "varchar(1000)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_general_ci"),
                    Price = table.Column<decimal>(type: "Decimal(10, 2)", nullable: false),
                    WaitTimeMins = table.Column<int>(type: "int(10)", nullable: false),
                    Ingredients = table.Column<string>(type: "varchar(1000)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_general_ci"),
                    Calories = table.Column<int>(type: "int(10)", nullable: false),
                    Halal = table.Column<bool>(type: "boolean", nullable: false),
                    ImageName = table.Column<string>(type: "varchar(110)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItem", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MenuItem_Category",
                        column: x => x.CategoryID,
                        principalTable: "Category",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MenuItem_Restaurant",
                        column: x => x.RestaurantID,
                        principalTable: "Restaurant",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Restaurant",
                columns: new[] { "ID", "Email", "Password", "ResLocation", "ResName", "ResUsername" },
                values: new object[] { -1, "dontpanic@gmail.com", "TrilogyOf5", "At the End of the Universe", "Milliways", "Milliways" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "ID", "Name", "RestaurantID" },
                values: new object[,]
                {
                    { -1, "Starters", -1 },
                    { -2, "Main Course", -1 },
                    { -3, "Dessert", -1 },
                    { -4, "Drinks", -1 }
                });

            migrationBuilder.InsertData(
                table: "MenuItem",
                columns: new[] { "ID", "Calories", "CategoryID", "Description", "Halal", "ImageName", "Ingredients", "Name", "Price", "RestaurantID", "WaitTimeMins" },
                values: new object[,]
                {
                    { -1, 450, -1, "You don't have to go all the way to the moon for good cheese. Check out our out of this world dip.", true, "Spring-Rolls.jpg", "Cheese from out of this world", "Spring Rolls", 7.87m, -1, 4 },
                    { -2, 600, -1, "Fresh from Fighy Joe's... Well, as fresh as Fishy Joe's gets. Cajuan Popcorn Shrimp", true, "French-Onion-Soup.jpg", "Cajuan Popcorn Shrimp", "French Onion Soup", 10.99m, -1, 8 },
                    { -3, 1200, -2, "FBeef Sliders with Caramalized Onions", true, "Scrum-Delicious-Burgers.jpg", "Beef Sliders with Caramalized Onions", "Scrum Delicious Burgers", 13.85m, -1, 15 },
                    { -4, 450, -2, "Pizza with pineapples because pineapples belong on a pizza", true, "Pineapple-Pizza.jpg", "Pizza with Pineapple", "Pineapple Pizza", 9.85m, -1, 15 },
                    { -5, 1200, -2, "Steak from an Ameglian Major Cow, a cow that wants to be eaten", false, "Ameglian-Steak.jpg", "Ameglian Major Cow Shoulder", "Ameglian Steak", 55.88m, -1, 30 },
                    { -6, 1200, -3, "Cherry Filled homemade pop tart warm as an enemy's blood.", false, "Klingon-Blood-Pies.jpg", "Kingon Cherries", "Klingon Blood Pies", 15.88m, -1, 10 },
                    { -7, 1200, -4, "It's like having your brains smashed out by a slice of lemon wrapped round a large gold brick", false, "Pan-Galactic-Gargle-Blaster.jpg", "Ol' Janx Spirit, Qualactin Hypermint extract, Zamphuor, Olive", "Pan Galactic Gargle Blaster", 22.88m, -1, 10 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Category_RestaurantID",
                table: "Category",
                column: "RestaurantID");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItem_CategoryID",
                table: "MenuItem",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItem_RestaurantID",
                table: "MenuItem",
                column: "RestaurantID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MenuItem");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Restaurant");
        }
    }
}
