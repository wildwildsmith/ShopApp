using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShopApp.Entities.Configuration;
using ShopApp.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopApp.Data
{
    public class ShopDbContext : IdentityDbContext<User, Role, Guid, 
        IdentityUserClaim<Guid>, UserRole, IdentityUserLogin<Guid>, 
        IdentityRoleClaim<Guid>, IdentityUserToken<Guid>>
    {
        private readonly IWebHostEnvironment env;

        public ShopDbContext(DbContextOptions options, 
            IWebHostEnvironment env) : base(options)
        {
            this.env = env;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new ProductConfiguration(env));
            builder.ApplyConfiguration(new RoleConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new UserRoleConfiguration());
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
