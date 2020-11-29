using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Capstone.Models
{
    [Table("MenuItem")]
    public class MenuItem
    {
        public MenuItem()
        {
        }

        [Key]
        [Column(TypeName = "int(10)")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Column(TypeName = "int(10)")]
        public int RestaurantID { get; set; }

        [Column(TypeName = "int(10)")]
        public int CategoryID { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string Name { get; set; }

        [Column(TypeName = "varchar(1000)")]
        public string Description { get; set; }

        [Column(TypeName = "Decimal(10, 2)")]
        public double Price { get; set; }

        [Column(TypeName = "int(10)")]
        public int WaitTimeMins { get; set; }

        [Column(TypeName = "varchar(1000)")]
        public string Ingredients { get; set; }

        [Column(TypeName = "int(10)")]
        public int Calories { get; set; }

        [Column(TypeName = "boolean")]
        public bool Halal { get; set; }

        [Column(TypeName = "varchar(110)")]
        public string ImageName { get; set; }

        [ForeignKey(nameof(CategoryID))]
        [InverseProperty(nameof(Models.Category.MenuItems))]
        public virtual Category Category { get; set; }

        [ForeignKey(nameof(RestaurantID))]
        [InverseProperty(nameof(Models.Restaurant.MenuItems))]
        public virtual Restaurant Restaurant { get; set; }
    }
}
