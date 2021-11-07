using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopApp.Data.Migrations
{
    public partial class Seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("e65be26b-11fd-4ea8-982b-16883d63ed71"), "77f38d25-7a77-4719-ae3e-82a59c790f3a", "User", "USER" },
                    { new Guid("2afa9bf6-96e0-4a3c-9f0d-7580c55259b9"), "8e865992-27c2-4de1-bd0d-52dd52cf5f12", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "City", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("faa4abaf-4098-47f6-ac7a-7429b705518d"), 0, "Pushkinska, 2a", "Kharkiv", "89bcaeae-dc8b-4e9d-b86c-b69c89592186", "user@mail.com", false, "User", "User", false, null, null, "user", "AQAAAAEAACcQAAAAEAa7IcQi1h3S2nScBcgMcpTNrIqCb5Dm8uC7aClfCy0P0FzpY+sEenNCixwHnKclkw==", null, false, null, false, "user" },
                    { new Guid("7581ea14-9a4a-4b28-bdcf-e5eb32f43e36"), 0, "Pushkinska, 2a", "Kharkiv", "92a75e64-fe4a-437f-ba6e-147610558864", "admin@mail.com", false, "Admin", "Admin", false, null, null, "user", "AQAAAAEAACcQAAAAEGKRtvel+WPwEYYroxQIHrpy+pdeXgG0TXNbo2/8KjqFuyQlHXkhwxlRlETUaNtrbA==", null, false, null, false, "admin" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "Description", "Price", "Title" },
                values: new object[,]
                {
                    { 1, "Jackets", "Take a sophisticated turn in our impeccably tailored classic overcoat. Made from wool infused with stretch for maximum comfort.", 89.99m, "SOLID WOOL COAT" },
                    { 2, "Hoodies", "Show your love of the iconic boy band in this concert souvenir hoodie, it's just like the classic original in a more earth-conscious design.", 50.00m, "BACKSTREET BOYS HOODIE" },
                    { 3, "Sweaters", "Styled from pima cotton with a hint of cashmere, we bring you the must-have turtleneck sweater (a best-seller year after year).", 44.99m, "TURTLENECK SWEATER" },
                    { 4, "Sweaters", "Made from pure organic cotton in an easy fit, our soft zip cardigan is a warm, lightweight versatile layer.", 70.00m, "COLORBLOCK CARDIGAN" },
                    { 5, " T-Shirts", "For the classic rock enthusiast, this throwback concert tee features the Rolling Stones logo from their touring days in the 90s.", 29.99m, "ROLLING STONES T-SHIRT" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId", "RoleId1", "UserId1" },
                values: new object[] { new Guid("e65be26b-11fd-4ea8-982b-16883d63ed71"), new Guid("faa4abaf-4098-47f6-ac7a-7429b705518d"), null, null });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId", "RoleId1", "UserId1" },
                values: new object[] { new Guid("2afa9bf6-96e0-4a3c-9f0d-7580c55259b9"), new Guid("7581ea14-9a4a-4b28-bdcf-e5eb32f43e36"), null, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("2afa9bf6-96e0-4a3c-9f0d-7580c55259b9"), new Guid("7581ea14-9a4a-4b28-bdcf-e5eb32f43e36") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("e65be26b-11fd-4ea8-982b-16883d63ed71"), new Guid("faa4abaf-4098-47f6-ac7a-7429b705518d") });

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2afa9bf6-96e0-4a3c-9f0d-7580c55259b9"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e65be26b-11fd-4ea8-982b-16883d63ed71"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("7581ea14-9a4a-4b28-bdcf-e5eb32f43e36"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("faa4abaf-4098-47f6-ac7a-7429b705518d"));
        }
    }
}
