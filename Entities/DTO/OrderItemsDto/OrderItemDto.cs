using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShopApp.Entities.DTO.OrderItemsDto
{
    public class OrderItemDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Product id is a required field.")]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Quantity is a required field.")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Price is a required field.")]
        public decimal UnitPrice { get; set; }

    }
}
