using ECOMCupCake.Data;
using ECOMCupCake.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Xunit;

namespace ECOMCupCakeTests.CRUD
{
    public class OrderServiceTests : IDisposable
    {
        // shareable vars  
        private Order order;
        private DbContextOptions<StoreDbContext> options;

        /// <summary>
        /// Constructor to setup testing environment
        /// </summary>
        public OrderServiceTests()
        {
            // setup our db context
            options =
            new DbContextOptionsBuilder<StoreDbContext>()
                .UseInMemoryDatabase("productDb")
                .Options;

            order = new Order();
            using (StoreDbContext context = new StoreDbContext(options))
            {
                order.ID = 1;
                order.UserID = "MyUserId";
                order.Address = "MyAddress";
                order.ZipCode = "00001";
                context.Orders.Add(order);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Dispose testing env after each test
        /// </summary>
        public void Dispose()
        {
            order = null;
            using (StoreDbContext context = new StoreDbContext(options))
            {

                var entities = context.Orders.ToArray<Order>();
                context.Orders.RemoveRange(entities);
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
                order.ID = 2;
                order.UserID = "MyNextUserId";
                order.Address = "MyNextAddress";
                order.ZipCode = "00002";
                context.Orders.Add(order);
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
                int expectedEntityId = 1;
                string expectedAddress = "MyAddress";
                var entity = context.Orders.FirstOrDefault(x => x.ID == expectedEntityId);
                Assert.Equal(expectedAddress, entity.Address);
            }
        }

        /// <summary>
        /// Can UPDATE an entity in a table
        /// </summary>
        [Fact]
        public void CanUpdateEntityInDb()
        {
            int existingId = 1;
            string expectedAddress = "MyAddress";
            using (StoreDbContext context = new StoreDbContext(options))
            {
                var entity = context.Orders.FirstOrDefault(x => x.ID == existingId);
                entity.Address = expectedAddress;
                context.Update(entity);
                context.SaveChanges();
            }

            using (StoreDbContext context = new StoreDbContext(options))
            {
                var entity = context.Orders.FirstOrDefault(x => x.ID == existingId);
                Assert.Equal(expectedAddress, entity.Address);
            }
        }

        /// <summary>
        /// Can DELETE an entity in a table
        /// </summary>
        [Fact]
        public void CanDeleteEntityInDb()
        {
            int existingId = 1;
            using (StoreDbContext context = new StoreDbContext(options))
            {
                var entity = context.Orders.FirstOrDefault(x => x.ID == existingId);
                context.Remove(entity);
                context.SaveChanges();
            }

            using (StoreDbContext context = new StoreDbContext(options))
            {
                var entityCount = context.Orders.Count();
                Assert.Equal(0, entityCount);
            }
        }
    }
}
