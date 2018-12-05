using ECOMCupCake.Data;
using ECOMCupCake.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Xunit;

namespace ECOMCupCakeTests.CRUD
{
    public class BasketServiceTests : IDisposable
    {
        // shareable vars  
        private Basket basket;
        private DbContextOptions<StoreDbContext> options;

        /// <summary>
        /// Constructor to setup testing environment
        /// </summary>
        public BasketServiceTests()
        {
            // setup our db context
            options =
            new DbContextOptionsBuilder<StoreDbContext>()
                .UseInMemoryDatabase("GetHotelNameFromDb")
                .Options;

            basket = new Basket();
            using (StoreDbContext context = new StoreDbContext(options))
            {
                basket.ID = 1;
                basket.UserID = "MyUserId";
                basket.ProductID = 1;
                context.Baskets.Add(basket);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Dispose testing env after each test
        /// </summary>
        public void Dispose()
        {
            basket = null;
            using (StoreDbContext context = new StoreDbContext(options))
            {

                var entities = context.Baskets.ToArray<Basket>();
                context.Baskets.RemoveRange(entities);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Can CREATE an entity in a table
        /// </summary>
        [Fact]
        public void CanCreateEntityInDb()
        {
            using (StoreDbContext context = new StoreDbContext(options))
            {
                basket.ID = 2;
                basket.UserID = "MyNextUserId";
                basket.ProductID = 2;
                context.Baskets.Add(basket);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Can READ an entity in a table
        /// </summary>
        [Fact]
        public void CanReadEntityFromDb()

        {
            using (StoreDbContext context = new StoreDbContext(options))
            {
                string expectedId = "MyUserId";
                var entity = context.Baskets.FirstOrDefault(x => x.UserID == expectedId);
                Assert.Equal(expectedId, entity.UserID);
            }
        }

        /// <summary>
        /// Can UPDATE an entity in a table
        /// </summary>
        [Fact]
        public void CanUpdateEntityInDb()
        {
            string expectedId = "MyNewId";
            string existingId = "MyUserId";
            using (StoreDbContext context = new StoreDbContext(options))
            {
                var entity = context.Baskets.FirstOrDefault(x => x.UserID == existingId);
                entity.UserID = expectedId;
                context.Update(entity);
                context.SaveChanges();
            }

            using (StoreDbContext context = new StoreDbContext(options))
            {
                var entity = context.Baskets.FirstOrDefault(x => x.UserID == expectedId);
                Assert.Equal(expectedId, entity.UserID);
            }
        }

        /// <summary>
        /// Can DELETE an entity in a table
        /// </summary>
        [Fact]
        public void CanDeleteEntityInDb()
        {
            string existingId = "MyUserId";
            using (StoreDbContext context = new StoreDbContext(options))
            {
                var entity = context.Baskets.FirstOrDefault(x => x.UserID == existingId);
                context.Remove(entity);
                context.SaveChanges();
            }

            using (StoreDbContext context = new StoreDbContext(options))
            {
                var entityCount = context.Baskets.Count();
                Assert.Equal(0, entityCount);
            }
        }
    }
}
