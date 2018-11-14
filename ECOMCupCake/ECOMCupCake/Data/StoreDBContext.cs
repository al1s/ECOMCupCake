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
    }
}