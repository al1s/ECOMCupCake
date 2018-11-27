using ECOMCupCake.Models;
using Microsoft.EntityFrameworkCore;


namespace ECOMCupCake.Data
{
    public class StoreDbContext : DbContext
    {
        public StoreDbContext(DbContextOptions<StoreDbContext> options)
            : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<Order> Orders{ get; set; }

 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Basket>().HasKey(b => new { b.UserID, b.ProductID });
            modelBuilder.Entity<Basket>().HasOne(e => e.Order)
                .WithMany(c => c.Baskets);

            modelBuilder.Entity<Product>().HasData(
                new Product() { ID = 1, Sku = "PP00001",Quantity = 1, Name = "Pumpkin Pie", Price = 5.87M, Description = "Delicious cake is made with fresh pumpkin from local farms and frosted with whipped cream frosting", Image = "/images/Products/pexels-photo-1055271.jpeg", Published = true },
                new Product() { ID = 2, Sku = "RP00002", Quantity = 1, Name = "Rum Pie", Price = 8.87M, Description = "Delicious cake topped with chocolate, soaked in rum", Image = "/images/Products/pexels-photo-1026123.jpeg", Published = true },
                new Product() { ID = 3, Sku = "VL00003", Quantity = 1, Name = "Vanilla and Lavender", Price = 7.87M, Description = "Vanilla cake with and lavender frosty topping", Image = "/images/Products/love-heart-purple-dessert.jpg", Published = true },
                new Product() { ID = 4, Sku = "BC00004", Quantity = 1, Name = "Berry Cake", Price = 4.87M, Description = "Vanilla bean cake paired with assorted berries", Image = "/images/Products/pexels-photo-556829.jpeg", Published = true },
                new Product() { ID = 5, Sku = "CE00005", Quantity = 1, Name = "Chocolate Eruption", Price = 9.87M, Description = "Chocolate cake filled with fine crafted milk chocolate", Image = "/images/Products/pexels-photo-360940.jpeg", Published = true },
                new Product() { ID = 6, Sku = "CC00006", Quantity = 1, Name = "Cranberry Cake", Price = 13.87M, Description = "Cranberry cake filled with cranberries from local farms", Image = "/images/Products/pexels-photo-853006.jpeg", Published = true },
                new Product() { ID = 7, Sku = "CP00007", Quantity = 1, Name = "Cake and Pretzel", Price = 3.87M, Description = "Cake designed to surprise, sweet and salty", Image = "/images/Products/pexels-photo-302555.jpeg", Published = true },
                new Product() { ID = 8, Sku = "SC00008", Quantity = 1, Name = "Salmon Cake", Price = 23.87M, Description = "Salmon cake baked with love from Seattle", Image = "/images/Products/pexels-photo-1343505.jpeg", Published = true },
                new Product() { ID = 9, Sku = "PC00009", Quantity = 1, Name = "Peanut Cake", Price = 1.87M, Description = "Peanuts and white chocolate, great taste, great neighbors", Image = "/images/Products/pexels-photo-1028704.jpeg", Published = true },
                new Product() { ID = 10, Sku = "CC00010", Quantity = 1, Name = "Christmas Cake", Price = 8.87M, Description = "Special Christmas treat", Image = "/images/Products/snow-winter-sweet-cookies-6298.jpg", Published = true }
            );
        }
    }
}