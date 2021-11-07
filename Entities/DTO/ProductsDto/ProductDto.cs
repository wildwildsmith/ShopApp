using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopApp.Entities.DTO.ProductsDto
{
    public class ProductDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Category { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }
    }
}
