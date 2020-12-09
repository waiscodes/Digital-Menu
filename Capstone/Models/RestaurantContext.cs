using System;
using Microsoft.EntityFrameworkCore;

namespace Capstone.Models
{
    public class RestaurantContext : DbContext
    {
        public virtual DbSet<Restaurant> Restaurants { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<MenuItem> MenuItems { get; set; }

        /*
        Instructions on Migration:
         This is a Mac and MAMP connection string.
            Make sure to update it to your OS before trying to migrate.
         */
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string connection =
                    "server=127.0.0.1;" +
                    "port=8889;" +
                    "user=root;" +
                    "password=root;" +
                    "database=DontPanic;";

                string version = "5.7.26";

                optionsBuilder.UseMySql(connection, x => x.ServerVersion(version));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Restaurant>(entity =>
            {
                entity.Property(e => e.ResName)
                      .HasCharSet("utf8mb4")
                      .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.ResUsername)
                      .HasCharSet("utf8mb4")
                      .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Email)
                      .HasCharSet("utf8mb4")
                      .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Password)
                      .HasCharSet("utf8mb4")
                      .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.ResLocation)
                      .HasCharSet("utf8mb4")
                      .HasCollation("utf8mb4_general_ci");

                entity.HasData(
                    new Restaurant()
                    {
                        ID = -1,
                        ResName = "Milliways",
                        ResUsername = "Milliways",
                        Email = "dontpanic@gmail.com",
                        Password = "TrilogyOf5",
                        ResLocation = "At the End of the Universe"
                    }
                );
            });


            string CatResFK = "FK_" + nameof(Category) +
                "_" + nameof(Restaurant);
            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.Name)
                      .HasCharSet("utf8mb4")
                      .HasCollation("utf8mb4_general_ci");

                entity.HasOne(thisEntity => thisEntity.Restaurant)
                      .WithMany(parent => parent.Categories)
                      .HasForeignKey(thisEntity => thisEntity.RestaurantID)
                      .OnDelete(DeleteBehavior.Cascade)
                      .HasConstraintName(CatResFK);

                entity.HasData(
                    new Category()
                    {
                        ID = -1,
                        RestaurantID = -1,
                        Name = "Starters"
                    }
                );

                entity.HasData(
                    new Category()
                    {
                        ID = -2,
                        RestaurantID = -1,
                        Name = "Main Course"
                    }
                );

                entity.HasData(
                    new Category()
                    {
                        ID = -3,
                        RestaurantID = -1,
                        Name = "Dessert"
                    }
                );

                entity.HasData(
                    new Category()
                    {
                        ID = -4,
                        RestaurantID = -1,
                        Name = "Drinks"
                    }
                );
            });

            string MenuCatFK = "FK_" + nameof(MenuItem) +
                "_" + nameof(Category);
            string MenuResFK = "FK_" + nameof(MenuItem) +
                "_" + nameof(Restaurant);

            modelBuilder.Entity<MenuItem>(entity =>
            {
                entity.Property(e => e.Name)
                      .HasCharSet("utf8mb4")
                      .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Description)
                      .HasCharSet("utf8mb4")
                      .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Ingredients)
                      .HasCharSet("utf8mb4")
                      .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.ImageName)
                      .HasCharSet("utf8mb4")
                      .HasCollation("utf8mb4_general_ci");

                entity.HasOne(thisEntity => thisEntity.Category)
                      .WithMany(parent => parent.MenuItems)
                      .HasForeignKey(thisEntity => thisEntity.CategoryID)
                      .OnDelete(DeleteBehavior.Cascade)
                      .HasConstraintName(MenuCatFK);

                entity.HasOne(thisEntity => thisEntity.Restaurant)
                      .WithMany(parent => parent.MenuItems)
                      .HasForeignKey(thisEntity => thisEntity.RestaurantID)
                      .OnDelete(DeleteBehavior.Cascade)
                      .HasConstraintName(MenuResFK);

                entity.HasData(
                    new MenuItem()
                    {
                        ID = -1,
                        RestaurantID = -1,
                        CategoryID = -1,
                        Name = "Moon Cheese Dip",
                        Description = "You don't have to go all the way to the moon for good cheese. Check out our out of this world dip.",
                        Price = 7.87,
                        WaitTimeMins = 4,
                        Ingredients = "Cheese from out of this world",
                        Calories = 450,
                        Halal = true,
                        ImageName = "Moon-Cheese-Dip.png"
                    }
                );

                entity.HasData(
                    new MenuItem()
                    {
                        ID = -2,
                        RestaurantID = -1,
                        CategoryID = -1,
                        Name = "Popplers",
                        Description = "Fresh from Fighy Joe's... Well, as fresh as Fishy Joe's gets. Cajuan Popcorn Shrimp",
                        Price = 10.99,
                        WaitTimeMins = 8,
                        Ingredients = "Cajuan Popcorn Shrimp",
                        Calories = 600,
                        Halal = true,
                        ImageName = "Popplers.png"
                    }
                );

                entity.HasData(
                    new MenuItem()
                    {
                        ID = -3,
                        RestaurantID = -1,
                        CategoryID = -2,
                        Name = "Bantha Burgers",
                        Description = "Favoured finger food of Tatooine. Beef Sliders with Caramalized Onions",
                        Price = 13.85,
                        WaitTimeMins = 15,
                        Ingredients = "Beef Sliders with Caramalized Onions",
                        Calories = 1200,
                        Halal = true,
                        ImageName = "Bantha-Burgers.png"
                    }
                );

                entity.HasData(
                    new MenuItem()
                    {
                        ID = -4,
                        RestaurantID = -1,
                        CategoryID = -2,
                        Name = "Pizza the Hutt",
                        Description = "Mini pizzas as cheese covered as its Spaceballs namesake",
                        Price = 9.85,
                        WaitTimeMins = 15,
                        Ingredients = "Cheese Pizza",
                        Calories = 450,
                        Halal = true,
                        ImageName = "Pizza-the-Hutt.png"
                    }
                );

                entity.HasData(
                    new MenuItem()
                    {
                        ID = -5,
                        RestaurantID = -1,
                        CategoryID = -2,
                        Name = "Ameglian Steak",
                        Description = "Steak from an Ameglian Major Cow, a cow that wants to be eaten",
                        Price = 55.88,
                        WaitTimeMins = 30,
                        Ingredients = "Ameglian Major Cow Shoulder",
                        Calories = 1200,
                        Halal = false,
                        ImageName = "Ameglian-Steak.png"
                    }
                );

                entity.HasData(
                    new MenuItem()
                    {
                        ID = -6,
                        RestaurantID = -1,
                        CategoryID = -3,
                        Name = "Klingon Blood Pies",
                        Description = "Cherry Filled homemade pop tart warm as an enemy's blood.",
                        Price = 15.88,
                        WaitTimeMins = 10,
                        Ingredients = "Kingon Cherries",
                        Calories = 1200,
                        Halal = false,
                        ImageName = "Klingon-Blood-Pies.png"
                    }
                );

                entity.HasData(
                    new MenuItem()
                    {
                        ID = -7,
                        RestaurantID = -1,
                        CategoryID = -4,
                        Name = "Pan Galactic Gargle Blaster",
                        Description = "It's like having your brains smashed out by a slice of lemon wrapped round a large gold brick",
                        Price = 22.88,
                        WaitTimeMins = 10,
                        Ingredients = "Ol' Janx Spirit, Qualactin Hypermint extract, Zamphuor, Olive",
                        Calories = 1200,
                        Halal = false,
                        ImageName = "Klingon-Blood-Pies.png"
                    }
                );
            });
        }
    }
}
