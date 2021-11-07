using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopApp.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopApp.Entities.Configuration
{
    class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasData(
                    new Role{
                        Id = new Guid("e65be26b-11fd-4ea8-982b-16883d63ed71"),
                        Name = "User",
                        NormalizedName = "USER"
                    },
                    new Role{
                        Id = new Guid("2afa9bf6-96e0-4a3c-9f0d-7580c55259b9"),
                        Name = "Admin",
                        NormalizedName = "ADMIN"
                    }
                );
        }
    }
}
