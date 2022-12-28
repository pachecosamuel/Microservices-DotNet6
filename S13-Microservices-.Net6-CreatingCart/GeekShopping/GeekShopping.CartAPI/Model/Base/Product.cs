﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeekShopping.CartAPI.Model.Base
{
    [Table("product")]
    public class Product
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Column("name")]
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Column("price")]
        [Required]
        [Range(1, 100000)]
        public decimal Price{ get; set; }

        [Column("description")]
        [StringLength(500)]
        public string Description { get; set; }

        [Column("category_name")]
        [StringLength(500)]
        public string CategoryName { get; set; }

        [Column("image_url")]
        [StringLength(500)]
        public string ImageUrl{ get; set; }

        public Product()
        {
            Id= Guid.NewGuid();
        }
    }
}
