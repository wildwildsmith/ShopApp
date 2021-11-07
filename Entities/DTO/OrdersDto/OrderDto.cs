using ShopApp.Entities.DTO.OrderItemsDto;
using ShopApp.Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShopApp.Entities.DTO.OrdersDto
{
    public class OrderDto
    {
        public Guid Id { get; set; }

        public DateTime OrderDate { get; set; }

        public string OrderNumber { get; set; }

        public IEnumerable<OrderItemDto> Items { get; set; }
        public User User { get; set; }
    }
}
