using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ECOMCupCake.Migrations
{
    public partial class OrderCreatedDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Orders",
                nullable: false,
            defaultValueSql: "GETUTCDATE()");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Created",
                table: "Orders");
        }
    }
}
