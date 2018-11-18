using Microsoft.EntityFrameworkCore.Migrations;

namespace ECOMCupCake.Migrations
{
    public partial class MergedProductandInventoryDecimal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Products",
                type: "DECIMAL(18,4)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Products",
                type: "DECIMAL(18,4",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "DECIMAL(18,4)");
        }
    }
}
