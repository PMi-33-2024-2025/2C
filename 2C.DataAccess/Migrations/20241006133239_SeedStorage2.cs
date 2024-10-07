using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _2C.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class SeedStorage2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Storages",
                columns: new[] { "Id", "Address" },
                values: new object[] { 2L, "Kyiv" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Storages",
                keyColumn: "Id",
                keyValue: 2L);
        }
    }
}
