using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ShopApp.Entities.Models
{
    public class Product
    {
        public Product()
        {
        }

        public Product(int id, string title, string category, decimal price, string description)
        {
            Id = id;
            Title = title;
            Category = category;
            Price = price;
            Description = description;
        }

        public int Id { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [Required(ErrorMessage = "Title is a required field.")]
        [MaxLength(30, ErrorMessage = "Maximum length for the Title is 30 characters.")]
        public string Title { get; set; }

        [Column(TypeName = "nvarchar(30)")]
        [Required(ErrorMessage = "Category is a required field.")]
        [MaxLength(30, ErrorMessage = "Maximum length for the Category is 30 characters.")]
        public string Category { get; set; }

        [Required(ErrorMessage = "Title is a required field.")]
        [Column(TypeName = "decimal(5,2)")]
        public decimal Price { get; set; }

        [Column(TypeName = "nvarchar(160)")]
        [Required(ErrorMessage = "Description is a required field.")]
        [MaxLength(160, ErrorMessage = "Maximum length for the Description is 160 characters.")]
        public string Description { get; set; }
    }
}
