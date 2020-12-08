using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Capstone.Models
{
    [Table("Category")]
    public class Category
    {
        public Category()
        {
            MenuItems = new HashSet<MenuItem>();
        }
        // No functionality for it yet but this was created with the future in mind where users can create their own categories.

        [Key]
        [Column(TypeName = "int(10)")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Column(TypeName = "int(10)")]
        public int RestaurantID { get; set; }

        [Column(TypeName = "varchar(45)")]
        public string Name { get; set; }

        [InverseProperty(nameof(MenuItem.Category))]
        public virtual ICollection<MenuItem> MenuItems { get; set; }

        [ForeignKey(nameof(RestaurantID))]
        [InverseProperty(nameof(Models.Restaurant.Categories))]
        public virtual Restaurant Restaurant { get; set; }
    }
}
