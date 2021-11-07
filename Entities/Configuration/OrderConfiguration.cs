using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopApp.Data;
using ShopApp.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopApp.Entities.Configuration
{
    public static class OrderConfiguration
    {
        public static async Task SeedOrders(UserManager<User> userManager, ShopDbContext context)
        {
            if(!await context.Orders.AnyAsync())
            {
                var user = await userManager.FindByNameAsync("user");

                var order = new Order
                {
                    Id = Guid.NewGuid(),
                    User = user,
                    Items = new List<OrderItem>
                        {
                            new OrderItem
                            {
                                Product = context.Products.First(),
                                Quantity = 5,
                                UnitPrice = context.Products.First().Price
                            }
                        },
                    OrderDate = DateTime.Now
                };

                await context.Orders.AddRangeAsync(order);
                await context.SaveChangesAsync();
            }
        }
    }
}
