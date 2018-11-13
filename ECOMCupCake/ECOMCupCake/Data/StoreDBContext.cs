using Microsoft.EntityFrameworkCore;
namespace ECOMCupCake.Data
{
    public class StoreDBContext : DbContext
    {
        public StoreDBContext(DbContextOptions<StoreDBContext> options)
            : base(options)
        {
        }
    }
}