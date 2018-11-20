using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ECOMCupCake.Migrations
{
    public partial class MergedProductandInventory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inventories");

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Sku = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    Price = table.Column<decimal>(type: "DECIMAL(18,4)", nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    Published = table.Column<bool>(nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ID", "Description", "Image", "Name", "Price", "Published", "Quantity", "Sku" },
                values: new object[,]
                {
                    { 1, "Delicious cake is made with fresh pumpkin from local farms and frosted with whipped cream frosting", "https://images.pexels.com/photos/1055271/pexels-photo-1055271.jpeg", "Pumpkin Pie", 5.87m, true, 0, "PP00001" },
                    { 2, "Delicious cake topped with chocolate, soaked in rum", "https://images.pexels.com/photos/1026123/pexels-photo-1026123.jpeg", "Rum Pie", 8.87m, true, 0, "RP00002" },
                    { 3, "Vanilla cake with and lavender frosty topping", "https://images.pexels.com/photos/8882/love-heart-purple-dessert.jpg", "Vanilla and Lavender", 7.87m, true, 0, "VL00003" },
                    { 4, "Vanilla bean cake paired with assorted berries", "https://images.pexels.com/photos/556829/pexels-photo-556829.jpeg", "Berry Cake", 4.87m, true, 0, "BC00004" },
                    { 5, "Chocolate cake filled with fine crafted milk chocolate", "https://images.pexels.com/photos/360940/pexels-photo-360940.jpeg", "Chocolate Eruption", 9.87m, true, 0, "CE00005" },
                    { 6, "Cranberry cake filled with cranberries from local farms", "https://images.pexels.com/photos/853006/pexels-photo-853006.jpeg", "Cranberry Cake", 13.87m, true, 0, "CC00006" },
                    { 7, "Cake designed to surprise, sweet and salty", "https://images.pexels.com/photos/302555/pexels-photo-302555.jpeg", "Cake and Pretzel", 3.87m, true, 0, "CP00007" },
                    { 8, "Salmon cake baked with love from Seattle", "https://images.pexels.com/photos/1343505/pexels-photo-1343505.jpeg", "Salmon Cake", 23.87m, true, 0, "SC00008" },
                    { 9, "Peanuts and white chocolate, great taste, great neighbors", "https://images.pexels.com/photos/1028704/pexels-photo-1028704.jpeg", "Peanut Cake", 1.87m, true, 0, "PC00009" },
                    { 10, "Special Christmas treat", "https://images.pexels.com/photos/6298/snow-winter-sweet-cookies-6298.jpg", "Christmas Cake", 8.87m, true, 0, "CC00010" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.CreateTable(
                name: "Inventories",
                columns: table => new
                {
                    InventoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Desctiption = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventories", x => x.InventoryId);
                });
        }
    }
}
