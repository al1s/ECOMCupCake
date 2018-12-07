﻿// <auto-generated />
using System;
using ECOMCupCake.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ECOMCupCake.Migrations
{
    [DbContext(typeof(StoreDbContext))]
    [Migration("20181202080535_Order City")]
    partial class OrderCity
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.2-rtm-30932")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ECOMCupCake.Models.Basket", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("OrderID");

                    b.Property<int>("ProductID");

                    b.Property<int>("Quantity");

                    b.Property<string>("UserID");

                    b.HasKey("ID");

                    b.HasIndex("OrderID");

                    b.HasIndex("ProductID");

                    b.ToTable("Baskets");
                });

            modelBuilder.Entity("ECOMCupCake.Models.Order", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<string>("Address2");

                    b.Property<string>("City");

                    b.Property<string>("Country");

                    b.Property<string>("CreditCardNumber");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("State");

                    b.Property<decimal>("Total");

                    b.Property<string>("UserID");

                    b.Property<string>("ZipCode");

                    b.HasKey("ID");

                    b.ToTable("Orders");
                });

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
                        new { ID = 1, Description = "Delicious cake is made with fresh pumpkin from local farms and frosted with whipped cream frosting", Image = "/images/Products/pexels-photo-1055271.jpeg", Name = "Pumpkin Pie", Price = 5.87m, Published = true, Quantity = 1, Sku = "PP00001" },
                        new { ID = 2, Description = "Delicious cake topped with chocolate, soaked in rum", Image = "/images/Products/pexels-photo-1026123.jpeg", Name = "Rum Pie", Price = 8.87m, Published = true, Quantity = 1, Sku = "RP00002" },
                        new { ID = 3, Description = "Vanilla cake with and lavender frosty topping", Image = "/images/Products/love-heart-purple-dessert.jpg", Name = "Vanilla and Lavender", Price = 7.87m, Published = true, Quantity = 1, Sku = "VL00003" },
                        new { ID = 4, Description = "Vanilla bean cake paired with assorted berries", Image = "/images/Products/pexels-photo-556829.jpeg", Name = "Berry Cake", Price = 4.87m, Published = true, Quantity = 1, Sku = "BC00004" },
                        new { ID = 5, Description = "Chocolate cake filled with fine crafted milk chocolate", Image = "/images/Products/pexels-photo-360940.jpeg", Name = "Chocolate Eruption", Price = 9.87m, Published = true, Quantity = 1, Sku = "CE00005" },
                        new { ID = 6, Description = "Cranberry cake filled with cranberries from local farms", Image = "/images/Products/pexels-photo-853006.jpeg", Name = "Cranberry Cake", Price = 13.87m, Published = true, Quantity = 1, Sku = "CC00006" },
                        new { ID = 7, Description = "Cake designed to surprise, sweet and salty", Image = "/images/Products/pexels-photo-302555.jpeg", Name = "Cake and Pretzel", Price = 3.87m, Published = true, Quantity = 1, Sku = "CP00007" },
                        new { ID = 8, Description = "Salmon cake baked with love from Seattle", Image = "/images/Products/pexels-photo-1343505.jpeg", Name = "Salmon Cake", Price = 23.87m, Published = true, Quantity = 1, Sku = "SC00008" },
                        new { ID = 9, Description = "Peanuts and white chocolate, great taste, great neighbors", Image = "/images/Products/pexels-photo-1028704.jpeg", Name = "Peanut Cake", Price = 1.87m, Published = true, Quantity = 1, Sku = "PC00009" },
                        new { ID = 10, Description = "Special Christmas treat", Image = "/images/Products/snow-winter-sweet-cookies-6298.jpg", Name = "Christmas Cake", Price = 8.87m, Published = true, Quantity = 1, Sku = "CC00010" }
                    );
                });

            modelBuilder.Entity("ECOMCupCake.Models.Basket", b =>
                {
                    b.HasOne("ECOMCupCake.Models.Order", "Order")
                        .WithMany("Baskets")
                        .HasForeignKey("OrderID");

                    b.HasOne("ECOMCupCake.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}