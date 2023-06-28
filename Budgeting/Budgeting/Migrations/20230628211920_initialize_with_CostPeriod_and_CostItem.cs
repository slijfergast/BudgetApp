using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Budgeting.Migrations
{
    /// <inheritdoc />
    public partial class initialize_with_CostPeriod_and_CostItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CostPeriods",
                columns: table => new
                {
                    CostPeriodId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CostPeriods", x => x.CostPeriodId);
                });

            migrationBuilder.CreateTable(
                name: "CostItems",
                columns: table => new
                {
                    CostItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cost = table.Column<double>(type: "float", nullable: false),
                    DateOfCost = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsPaid = table.Column<bool>(type: "bit", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CostPeriodId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CostItems", x => x.CostItemId);
                    table.ForeignKey(
                        name: "FK_CostItems_CostPeriods_CostPeriodId",
                        column: x => x.CostPeriodId,
                        principalTable: "CostPeriods",
                        principalColumn: "CostPeriodId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CostItems_CostPeriodId",
                table: "CostItems",
                column: "CostPeriodId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CostItems");

            migrationBuilder.DropTable(
                name: "CostPeriods");
        }
    }
}
