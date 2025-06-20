using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KOLO_2.Migrations
{
    /// <inheritdoc />
    public partial class ChangedMWeight : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Characters",
                keyColumn: "Id",
                keyValue: 1,
                column: "MaxWeight",
                value: 1000);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Characters",
                keyColumn: "Id",
                keyValue: 1,
                column: "MaxWeight",
                value: 13);
        }
    }
}
