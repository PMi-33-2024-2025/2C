using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace _2C.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class SeedUser3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "LastName", "Name", "Password", "RoleId", "StorageId" },
                values: new object[,]
                {
                    { new Guid("13ae9e21-62ae-4c89-8b48-318b9629714d"), "bohdan@gmail.com", "Ostrovskyi", "Bohdan", "abcd1234", 1, 1L },
                    { new Guid("227a5a5c-98f6-45d5-8628-7b53240695e5"), "andrii@gmail.com", "Shevchenko", "Andrii", "abcd1234", 1, 2L },
                    { new Guid("23c14957-7d7e-47e0-9ca4-7aba886f2c4d"), "pavlo@gmail.com", "Ivanov", "Pavlo", "abcdefgh", 2, 1L },
                    { new Guid("3f69ed69-4757-4875-bbd2-f2925f1ad4ab"), "max@gmail.com", "Doe", "Max", "12345678", 2, 2L }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("13ae9e21-62ae-4c89-8b48-318b9629714d"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("227a5a5c-98f6-45d5-8628-7b53240695e5"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("23c14957-7d7e-47e0-9ca4-7aba886f2c4d"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("3f69ed69-4757-4875-bbd2-f2925f1ad4ab"));
        }
    }
}
