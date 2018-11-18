﻿// <auto-generated />
using ECOMCupCake.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ECOMCupCake.Migrations
{
    [DbContext(typeof(StoreDbContext))]
    [Migration("20181118041403_Merged Product and Inventory Decimal")]
    partial class MergedProductandInventoryDecimal
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.2-rtm-30932")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ECOMCupCake.Models.Product", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("Image");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<decimal>("Price")
                        .HasColumnName("Price")
                        .HasColumnType("DECIMAL(18,4)");

                    b.Property<bool>("Published");

                    b.Property<int>("Quantity");

                    b.Property<string>("Sku");

                    b.HasKey("ID");

                    b.ToTable("Products");

                    b.HasData(
                        new { ID = 1, Description = "Delicious cake is made with fresh pumpkin from local farms and frosted with whipped cream frosting", Image = "https://images.pexels.com/photos/1055271/pexels-photo-1055271.jpeg", Name = "Pumpkin Pie", Price = 5.87m, Published = true, Quantity = 0, Sku = "PP00001" },
                        new { ID = 2, Description = "Delicious cake topped with chocolate, soaked in rum", Image = "https://images.pexels.com/photos/1026123/pexels-photo-1026123.jpeg", Name = "Rum Pie", Price = 8.87m, Published = true, Quantity = 0, Sku = "RP00002" },
                        new { ID = 3, Description = "Vanilla cake with and lavender frosty topping", Image = "https://images.pexels.com/photos/8882/love-heart-purple-dessert.jpg", Name = "Vanilla and Lavender", Price = 7.87m, Published = true, Quantity = 0, Sku = "VL00003" },
                        new { ID = 4, Description = "Vanilla bean cake paired with assorted berries", Image = "https://images.pexels.com/photos/556829/pexels-photo-556829.jpeg", Name = "Berry Cake", Price = 4.87m, Published = true, Quantity = 0, Sku = "BC00004" },
                        new { ID = 5, Description = "Chocolate cake filled with fine crafted milk chocolate", Image = "https://images.pexels.com/photos/360940/pexels-photo-360940.jpeg", Name = "Chocolate Eruption", Price = 9.87m, Published = true, Quantity = 0, Sku = "CE00005" },
                        new { ID = 6, Description = "Cranberry cake filled with cranberries from local farms", Image = "https://images.pexels.com/photos/853006/pexels-photo-853006.jpeg", Name = "Cranberry Cake", Price = 13.87m, Published = true, Quantity = 0, Sku = "CC00006" },
                        new { ID = 7, Description = "Cake designed to surprise, sweet and salty", Image = "https://images.pexels.com/photos/302555/pexels-photo-302555.jpeg", Name = "Cake and Pretzel", Price = 3.87m, Published = true, Quantity = 0, Sku = "CP00007" },
                        new { ID = 8, Description = "Salmon cake baked with love from Seattle", Image = "https://images.pexels.com/photos/1343505/pexels-photo-1343505.jpeg", Name = "Salmon Cake", Price = 23.87m, Published = true, Quantity = 0, Sku = "SC00008" },
                        new { ID = 9, Description = "Peanuts and white chocolate, great taste, great neighbors", Image = "https://images.pexels.com/photos/1028704/pexels-photo-1028704.jpeg", Name = "Peanut Cake", Price = 1.87m, Published = true, Quantity = 0, Sku = "PC00009" },
                        new { ID = 10, Description = "Special Christmas treat", Image = "https://images.pexels.com/photos/6298/snow-winter-sweet-cookies-6298.jpg", Name = "Christmas Cake", Price = 8.87m, Published = true, Quantity = 0, Sku = "CC00010" }
                    );
                });
#pragma warning restore 612, 618
        }
    }
}
