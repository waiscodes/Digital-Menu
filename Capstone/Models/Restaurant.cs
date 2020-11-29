using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Capstone.Models
{
    [Table("Restaurant")]
    public class Restaurant
    {
        public Restaurant()
        {
        }

        [Key]
        [Column(TypeName = "int(10)")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Column(TypeName = "varchar(75)")]
        public string ResName { get; set; }

        [Column(TypeName = "varchar(30)")]
        public string ResUsername { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string Password { get; set; }

        [Column(TypeName = "varchar(75)")]
        public string ResLocation { get; set; }
    }
}
