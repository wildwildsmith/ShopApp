using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopApp.Entities.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace ShopApp.Entities.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        private readonly IWebHostEnvironment env;

        public ProductConfiguration(IWebHostEnvironment env)
        {
            this.env = env;
        }
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            var file = Path.Combine(env.ContentRootPath, "Data/products.json");
            var json = File.ReadAllText(file);
            var products = JsonSerializer.Deserialize<IEnumerable<Product>>(json);

            foreach(var product in products)
            {
                builder.HasData(new Product(product.Id, product.Title, product.Category, product.Price, product.Description));
            }
        }
    }
}
