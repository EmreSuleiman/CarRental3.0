using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRental3._0.Migrations
{
    /// <inheritdoc />
    public partial class FixCarIdColumnType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Category",
                table: "Cars",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 1,
                columns: new[] { "Category", "CreatedAt", "UpdatedAt" },
                values: new object[] { 0, new DateTime(2025, 3, 21, 20, 29, 0, 318, DateTimeKind.Utc).AddTicks(5668), new DateTime(2025, 3, 21, 20, 29, 0, 318, DateTimeKind.Utc).AddTicks(5669) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 2,
                columns: new[] { "Category", "CreatedAt", "UpdatedAt" },
                values: new object[] { 1, new DateTime(2025, 3, 21, 20, 29, 0, 318, DateTimeKind.Utc).AddTicks(5670), new DateTime(2025, 3, 21, 20, 29, 0, 318, DateTimeKind.Utc).AddTicks(5670) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Category",
                table: "Cars",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 1,
                columns: new[] { "Category", "CreatedAt", "UpdatedAt" },
                values: new object[] { "Икономични", new DateTime(2025, 3, 21, 19, 3, 23, 209, DateTimeKind.Utc).AddTicks(2430), new DateTime(2025, 3, 21, 19, 3, 23, 209, DateTimeKind.Utc).AddTicks(2431) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 2,
                columns: new[] { "Category", "CreatedAt", "UpdatedAt" },
                values: new object[] { "Икономични", new DateTime(2025, 3, 21, 19, 3, 23, 209, DateTimeKind.Utc).AddTicks(2472), new DateTime(2025, 3, 21, 19, 3, 23, 209, DateTimeKind.Utc).AddTicks(2473) });
        }
    }
}
