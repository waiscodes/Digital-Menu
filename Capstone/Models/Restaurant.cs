﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Capstone.Models
{
    [Table("Restaurant")]
    public class Restaurant
    {
        public Restaurant()
        {
            Categories = new HashSet<Category>();
            MenuItems = new HashSet<MenuItem>();
        }

        [Key]
        [Column(TypeName = "int(10)")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Column(TypeName = "varchar(75)")]
        public string ResName { get; set; }

        // Unique name used as handle to go check the menus. /m/{resUsername}
        [Column(TypeName = "varchar(30)")]
        public string ResUsername { get; set; }

        // Unique email, one restaurant per email. No functionality for multiple stores for user yet so it's neccessary
        [Column(TypeName = "varchar(64)")]
        public string Email { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string Password { get; set; }

        [Column(TypeName = "varchar(75)")]
        public string ResLocation { get; set; }

        [InverseProperty(nameof(Category.Restaurant))]
        public virtual ICollection<Category> Categories { get; set; }

        [InverseProperty(nameof(Category.Restaurant))]
        public virtual ICollection<MenuItem> MenuItems { get; set; }
    }
}
