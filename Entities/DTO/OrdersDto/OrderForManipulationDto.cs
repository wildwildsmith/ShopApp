using ShopApp.Entities.DTO.OrderItemsDto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShopApp.Entities.DTO.OrdersDto
{
    public abstract class OrderForManipulationDto
    {
        public DateTime OrderDate { get; set; }

        [Required(ErrorMessage = "Order number is a required field.")]
        [MinLength(4)]
        public string OrderNumber { get; set; }

        public IEnumerable<OrderItemForCreationDto> Items { get; set; }
    }
}
