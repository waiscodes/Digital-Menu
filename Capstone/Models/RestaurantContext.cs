using System;
using Microsoft.EntityFrameworkCore;

namespace Capstone.Models
{
    public class RestaurantContext : DbContext
    {
        public virtual DbSet<Restaurant> Restaurants { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<MenuItem> MenuItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string connection =
                    "server=127.0.0.1;" +
                    "port=8889;" +
                    "user=root;" +
                    "password=root;" +
                    "database=DigitalMenu;";

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

                entity.Property(e => e.Password)
                      .HasCharSet("utf8mb4")
                      .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.ResLocation)
                      .HasCharSet("utf8mb4")
                      .HasCollation("utf8mb4_general_ci");
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
            });
        }
    }
}
