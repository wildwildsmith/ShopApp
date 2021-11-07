using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ShopApp.Entities.Models
{
    public class Order
    {
        [Column("OrderId")]
        public Guid Id { get; set; }

        public DateTime OrderDate { get; set; }

        [Required(ErrorMessage = "Order number is a required field.")]
        public int OrderNumber { get; set; }

        public IEnumerable<OrderItem> Items { get; set; }

        public User User { get; set; }
    }
}
