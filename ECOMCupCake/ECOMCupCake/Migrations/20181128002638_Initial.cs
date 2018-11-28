using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ECOMCupCake.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserID = table.Column<string>(nullable: true),
                    Total = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.ID);
                });

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

            migrationBuilder.CreateTable(
                name: "Baskets",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserID = table.Column<string>(nullable: true),
                    ProductID = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    OrderID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Baskets", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Baskets_Orders_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Orders",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Baskets_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ID", "Description", "Image", "Name", "Price", "Published", "Quantity", "Sku" },
                values: new object[,]
                {
                    { 1, "Delicious cake is made with fresh pumpkin from local farms and frosted with whipped cream frosting", "/images/Products/pexels-photo-1055271.jpeg", "Pumpkin Pie", 5.87m, true, 1, "PP00001" },
                    { 2, "Delicious cake topped with chocolate, soaked in rum", "/images/Products/pexels-photo-1026123.jpeg", "Rum Pie", 8.87m, true, 1, "RP00002" },
                    { 3, "Vanilla cake with and lavender frosty topping", "/images/Products/love-heart-purple-dessert.jpg", "Vanilla and Lavender", 7.87m, true, 1, "VL00003" },
                    { 4, "Vanilla bean cake paired with assorted berries", "/images/Products/pexels-photo-556829.jpeg", "Berry Cake", 4.87m, true, 1, "BC00004" },
                    { 5, "Chocolate cake filled with fine crafted milk chocolate", "/images/Products/pexels-photo-360940.jpeg", "Chocolate Eruption", 9.87m, true, 1, "CE00005" },
                    { 6, "Cranberry cake filled with cranberries from local farms", "/images/Products/pexels-photo-853006.jpeg", "Cranberry Cake", 13.87m, true, 1, "CC00006" },
                    { 7, "Cake designed to surprise, sweet and salty", "/images/Products/pexels-photo-302555.jpeg", "Cake and Pretzel", 3.87m, true, 1, "CP00007" },
                    { 8, "Salmon cake baked with love from Seattle", "/images/Products/pexels-photo-1343505.jpeg", "Salmon Cake", 23.87m, true, 1, "SC00008" },
                    { 9, "Peanuts and white chocolate, great taste, great neighbors", "/images/Products/pexels-photo-1028704.jpeg", "Peanut Cake", 1.87m, true, 1, "PC00009" },
                    { 10, "Special Christmas treat", "/images/Products/snow-winter-sweet-cookies-6298.jpg", "Christmas Cake", 8.87m, true, 1, "CC00010" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Baskets_OrderID",
                table: "Baskets",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_Baskets_ProductID",
                table: "Baskets",
                column: "ProductID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Baskets");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
