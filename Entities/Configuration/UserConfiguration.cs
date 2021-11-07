using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopApp.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopApp.Entities.Configuration
{
    class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            var user = new User
            {
                Id = new Guid("faa4abaf-4098-47f6-ac7a-7429b705518d"),
                UserName = "user",
                NormalizedUserName = "user",
                FirstName = "User",
                LastName = "User",
                Email = "user@mail.com",
                City = "Kharkiv",
                Address = "Pushkinska, 2a"
            };

            var admin = new User
            {
                Id = new Guid("7581ea14-9a4a-4b28-bdcf-e5eb32f43e36"),
                UserName = "admin",
                NormalizedUserName = "admin",
                FirstName = "Admin",
                LastName = "Admin",
                Email = "admin@mail.com",
                City = "Kharkiv",
                Address = "Pushkinska, 2a"
            };

            PasswordHasher<User> hasher = new PasswordHasher<User>();

            user.PasswordHash = hasher.HashPassword(user, "password1");
            admin.PasswordHash = hasher.HashPassword(admin, "password2");

            builder.HasData(user, admin);
        }
    }
}
