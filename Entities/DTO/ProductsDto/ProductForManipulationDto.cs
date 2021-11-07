using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShopApp.Entities.DTO.ProductsDto
{
    public abstract class ProductForManipulationDto
    {
        [Required(ErrorMessage = "Title is a required field.")]
        [MaxLength(30, ErrorMessage = "Maximum length for the Title is 30 characters.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Category is a required field.")]
        [MaxLength(30, ErrorMessage = "Maximum length for the Category is 30 characters.")]
        public string Category { get; set; }

        [Required(ErrorMessage = "Title is a required field.")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Description is a required field.")]
        [MaxLength(160, ErrorMessage = "Maximum length for the Description is 160 characters.")]
        public string Description { get; set; }
    }
}
