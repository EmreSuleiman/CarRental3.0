using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRental3._0.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCarCategoryToEnum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 21, 19, 3, 23, 209, DateTimeKind.Utc).AddTicks(2430), new DateTime(2025, 3, 21, 19, 3, 23, 209, DateTimeKind.Utc).AddTicks(2431) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 21, 19, 3, 23, 209, DateTimeKind.Utc).AddTicks(2472), new DateTime(2025, 3, 21, 19, 3, 23, 209, DateTimeKind.Utc).AddTicks(2473) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 17, 13, 56, 55, 397, DateTimeKind.Utc).AddTicks(3426), new DateTime(2025, 3, 17, 13, 56, 55, 397, DateTimeKind.Utc).AddTicks(3426) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 17, 13, 56, 55, 397, DateTimeKind.Utc).AddTicks(3462), new DateTime(2025, 3, 17, 13, 56, 55, 397, DateTimeKind.Utc).AddTicks(3462) });
        }
    }
}
