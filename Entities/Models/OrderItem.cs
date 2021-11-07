using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ShopApp.Entities.Models
{
    public class OrderItem
    {
        public int Id { get; set; }

        public Product Product { get; set; }

        [Required(ErrorMessage = "Product id is a required field.")]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Quantity is a required field.")]
        public int Quantity { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        [Required(ErrorMessage = "Price is a required field.")]
        public decimal UnitPrice { get; set; }

        public Order Order { get; set; }
    }
}
