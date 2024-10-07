using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace _2C.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class SeedProducts_ : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Name", "Price", "Quantity", "StorageId" },
                values: new object[,]
                {
                    { new Guid("27d3fa15-7a6d-4f5a-8436-1f0b2fced642"), "Banana", 40.0, 100000, 1L },
                    { new Guid("883cf1ef-e8f0-46c2-826f-f08a32bfcae6"), "Tomato", 70.0, 40000, 1L },
                    { new Guid("926ca070-af63-4474-8d07-439b5ea17b43"), "Apple", 25.0, 200000, 2L },
                    { new Guid("f25798a4-0111-4070-a872-e5092fedb435"), "Cucumber", 60.0, 250000, 2L }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("27d3fa15-7a6d-4f5a-8436-1f0b2fced642"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("883cf1ef-e8f0-46c2-826f-f08a32bfcae6"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("926ca070-af63-4474-8d07-439b5ea17b43"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("f25798a4-0111-4070-a872-e5092fedb435"));
        }
    }
}
