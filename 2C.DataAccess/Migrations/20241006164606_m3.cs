using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _2C.DataAccess.Migrations
{
	/// <inheritdoc />
	public partial class m3 : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			/*migrationBuilder.InsertData(
				table: "Roles",
				columns: new[] { "Id", "Name" },
				values: new object[,]
				{
					{ 1, "Admin" },
					{ 2, "User" }
				});*/
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			/*migrationBuilder.DeleteData(
				table: "Roles",
				keyColumn: "Id",
				keyValue: 1);

			migrationBuilder.DeleteData(
				table: "Roles",
				keyColumn: "Id",
				keyValue: 2);*/
		}
	}
}
