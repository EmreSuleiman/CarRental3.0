using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRental3._0.Migrations
{
    /// <inheritdoc />
    public partial class CategoryCyrilic : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 23, 15, 41, 4, 337, DateTimeKind.Utc).AddTicks(1617), new DateTime(2025, 3, 23, 15, 41, 4, 337, DateTimeKind.Utc).AddTicks(1617) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 23, 15, 41, 4, 337, DateTimeKind.Utc).AddTicks(1618), new DateTime(2025, 3, 23, 15, 41, 4, 337, DateTimeKind.Utc).AddTicks(1619) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 21, 20, 29, 0, 318, DateTimeKind.Utc).AddTicks(5668), new DateTime(2025, 3, 21, 20, 29, 0, 318, DateTimeKind.Utc).AddTicks(5669) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 21, 20, 29, 0, 318, DateTimeKind.Utc).AddTicks(5670), new DateTime(2025, 3, 21, 20, 29, 0, 318, DateTimeKind.Utc).AddTicks(5670) });
        }
    }
}
