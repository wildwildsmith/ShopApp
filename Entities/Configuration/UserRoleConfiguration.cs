using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopApp.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopApp.Entities.Configuration
{
    class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.HasData(
                    new UserRole
                    {
                        RoleId = new Guid("e65be26b-11fd-4ea8-982b-16883d63ed71"),
                        UserId = new Guid("faa4abaf-4098-47f6-ac7a-7429b705518d")
                    },
                    new UserRole
                    {
                        RoleId = new Guid("2afa9bf6-96e0-4a3c-9f0d-7580c55259b9"),
                        UserId = new Guid("7581ea14-9a4a-4b28-bdcf-e5eb32f43e36")
                    }
                );
        }
    }
}
