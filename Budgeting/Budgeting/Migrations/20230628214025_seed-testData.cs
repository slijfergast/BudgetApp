using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Budgeting.Migrations
{
    /// <inheritdoc />
    public partial class seedtestData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Note",
                table: "CostItems",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "CostPeriods",
                columns: new[] { "CostPeriodId", "Name" },
                values: new object[] { -1, "test_item" });

            migrationBuilder.InsertData(
                table: "CostItems",
                columns: new[] { "CostItemId", "Cost", "CostPeriodId", "DateOfCost", "IsPaid", "Note" },
                values: new object[,]
                {
                    { -2, 100.0, -1, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null },
                    { -1, 100.0, -1, new DateTime(2023, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CostItems",
                keyColumn: "CostItemId",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "CostItems",
                keyColumn: "CostItemId",
                keyValue: -1);

            migrationBuilder.DeleteData(
                table: "CostPeriods",
                keyColumn: "CostPeriodId",
                keyValue: -1);

            migrationBuilder.AlterColumn<string>(
                name: "Note",
                table: "CostItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
