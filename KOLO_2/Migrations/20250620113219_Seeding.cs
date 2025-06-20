using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace KOLO_2.Migrations
{
    /// <inheritdoc />
    public partial class Seeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Backpacks",
                keyColumn: "Id",
                keyValue: 1,
                column: "Amount",
                value: 22);

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "item1");

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Name", "Weight" },
                values: new object[,]
                {
                    { 2, "item2", 11 },
                    { 3, "item3", 5 }
                });

            migrationBuilder.InsertData(
                table: "Titles",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "sth2" });

            migrationBuilder.InsertData(
                table: "Character_Title",
                columns: new[] { "CharacterId", "TitleId", "AcquiredAt" },
                values: new object[] { 1, 2, new DateTime(2000, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Character_Title",
                keyColumns: new[] { "CharacterId", "TitleId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Titles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "Backpacks",
                keyColumn: "Id",
                keyValue: 1,
                column: "Amount",
                value: 14);

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "str_2");
        }
    }
}
