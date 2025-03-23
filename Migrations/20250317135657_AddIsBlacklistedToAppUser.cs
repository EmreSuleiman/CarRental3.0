using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRental3._0.Migrations
{
    /// <inheritdoc />
    public partial class AddIsBlacklistedToAppUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsBlacklisted",
                table: "AspNetUsers",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsBlacklisted",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 11, 16, 3, 2, 420, DateTimeKind.Utc).AddTicks(4991), new DateTime(2025, 3, 11, 16, 3, 2, 420, DateTimeKind.Utc).AddTicks(4992) });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "CarId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 11, 16, 3, 2, 420, DateTimeKind.Utc).AddTicks(5023), new DateTime(2025, 3, 11, 16, 3, 2, 420, DateTimeKind.Utc).AddTicks(5023) });
        }
    }
}
