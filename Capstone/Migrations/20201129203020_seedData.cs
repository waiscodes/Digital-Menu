using Microsoft.EntityFrameworkCore.Migrations;

namespace Capstone.Migrations
{
    public partial class seedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Restaurant",
                columns: new[] { "ID", "Email", "Password", "ResLocation", "ResName", "ResUsername" },
                values: new object[] { -1, "MostlyHarmless@gmail.com", "TrilogyOf5", "At the End of the Universe", "Milliways", "Milliways" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "ID", "Name", "RestaurantID" },
                values: new object[] { -1, "Starters", -1 });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "ID", "Name", "RestaurantID" },
                values: new object[] { -2, "Main Course", -1 });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "ID", "Name", "RestaurantID" },
                values: new object[] { -3, "Dessert", -1 });

            migrationBuilder.InsertData(
                table: "MenuItem",
                columns: new[] { "ID", "Calories", "CategoryID", "Description", "Halal", "ImageName", "Ingredients", "Name", "Price", "RestaurantID", "WaitTimeMins" },
                values: new object[,]
                {
                    { -1, 450, -1, "You don't have to go all the way to the moon for good cheese. Check out our out of this world dip.", true, "Moon-Cheese-Dip.png", "Cheese from out of this world", "Moon Cheese Dip", 7.87m, -1, 4 },
                    { -2, 600, -1, "Fresh from Fighy Joe's... Well, as fresh as Fishy Joe's gets. Cajuan Popcorn Shrimp", true, "Popplers.png", "Cajuan Popcorn Shrimp", "Popplers", 10.99m, -1, 8 },
                    { -3, 1200, -2, "Favoured finger food of Tatooine. Beef Sliders with Caramalized Onions", true, "Bantha-Burgers.png", "Beef Sliders with Caramalized Onions", "Bantha Burgers", 13.85m, -1, 15 },
                    { -4, 450, -2, "Mini pizzas as cheese covered as its Spaceballs namesake", true, "Pizza-the-Hutt.png", "Cheese Pizza", "Pizza the Hutt", 9.85m, -1, 15 },
                    { -5, 1200, -2, "Steak from an Ameglian Major Cow, a cow that wants to be eaten", false, "Ameglian-Steak.png", "Ameglian Major Cow Shoulder", "Ameglian Steak", 55.88m, -1, 30 },
                    { -6, 1200, -3, "Cherry Filled homemade pop tart warm as an enemy's blood.", false, "Klingon-Blood-Pies.png", "Kingon Cherries", "Klingon Blood Pies", 15.88m, -1, 10 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MenuItem",
                keyColumn: "ID",
                keyValue: -6);

            migrationBuilder.DeleteData(
                table: "MenuItem",
                keyColumn: "ID",
                keyValue: -5);

            migrationBuilder.DeleteData(
                table: "MenuItem",
                keyColumn: "ID",
                keyValue: -4);

            migrationBuilder.DeleteData(
                table: "MenuItem",
                keyColumn: "ID",
                keyValue: -3);

            migrationBuilder.DeleteData(
                table: "MenuItem",
                keyColumn: "ID",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "MenuItem",
                keyColumn: "ID",
                keyValue: -1);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "ID",
                keyValue: -3);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "ID",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "ID",
                keyValue: -1);

            migrationBuilder.DeleteData(
                table: "Restaurant",
                keyColumn: "ID",
                keyValue: -1);
        }
    }
}
