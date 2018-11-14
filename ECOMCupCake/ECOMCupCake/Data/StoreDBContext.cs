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
        public DbSet<Inventory> Inventories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product() { ID = 1, Sku = "PP00001", Name = "Pumpkin Pie", Price = 5.87M, Description = "Delicious cake is made with fresh pumpkin from local farms and frosted with whipped cream frosting", Image = "https://images.pexels.com/photos/1055271/pexels-photo-1055271.jpeg" },
                new Product() { ID = 2, Sku = "RP00002", Name = "Rum Pie", Price = 8.87M, Description = "Delicious cake topped with chocolate, soaked in rum", Image = "https://images.pexels.com/photos/1026123/pexels-photo-1026123.jpeg" },
                new Product() { ID = 3, Sku = "VL00001", Name = "Vanilla and Lavender", Price = 7.87M, Description = "Vanilla cake with and lavender frosty topping", Image = "https://images.pexels.com/photos/8882/love-heart-purple-dessert.jpg" },
                new Product() { ID = 4, Sku = "BC00001", Name = "Berry Cake", Price = 4.87M, Description = "Vanilla bean cake paired with assorted berries", Image = "https://images.pexels.com/photos/556829/pexels-photo-556829.jpeg" },
                new Product() { ID = 5, Sku = "CE00001", Name = "Chocolate Eruption", Price = 9.87M, Description = "Chocolate cake filled with fine crafted milk chocolate", Image = "https://images.pexels.com/photos/360940/pexels-photo-360940.jpeg" }
            );
        }
    }
}