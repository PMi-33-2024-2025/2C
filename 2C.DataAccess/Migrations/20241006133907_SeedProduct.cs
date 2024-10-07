using Microsoft.EntityFrameworkCore.Migrations;
using System;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace _2C.DataAccess.Migrations
{
	/// <inheritdoc />
	public partial class SeedProduct : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			/*migrationBuilder.DropForeignKey(
                name: "FK_Products_Storages_StorageId1",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_StorageId1",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "StorageId1",
                table: "Products");

            migrationBuilder.AlterColumn<long>(
                name: "StorageId",
                table: "Products",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid");*/

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

			/*migrationBuilder.CreateIndex(
				name: "IX_Products_StorageId",
				table: "Products",
				column: "StorageId");

			migrationBuilder.AddForeignKey(
				name: "FK_Products_Storages_StorageId",
				table: "Products",
				column: "StorageId",
				principalTable: "Storages",
				principalColumn: "Id",
				onDelete: ReferentialAction.Cascade);*/
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			/*migrationBuilder.DropForeignKey(
				name: "FK_Products_Storages_StorageId",
				table: "Products");

			migrationBuilder.DropIndex(
				name: "IX_Products_StorageId",
				table: "Products");*/

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

			/*migrationBuilder.AlterColumn<Guid>(
				name: "StorageId",
				table: "Products",
				type: "uuid",
				nullable: false,
				oldClrType: typeof(long),
				oldType: "bigint");

			migrationBuilder.AddColumn<long>(
				name: "StorageId1",
				table: "Products",
				type: "bigint",
				nullable: false,
				defaultValue: 0L);

			migrationBuilder.CreateIndex(
				name: "IX_Products_StorageId1",
				table: "Products",
				column: "StorageId1");

			migrationBuilder.AddForeignKey(
				name: "FK_Products_Storages_StorageId1",
				table: "Products",
				column: "StorageId1",
				principalTable: "Storages",
				principalColumn: "Id",
				onDelete: ReferentialAction.Cascade);*/
		}
	}
}
