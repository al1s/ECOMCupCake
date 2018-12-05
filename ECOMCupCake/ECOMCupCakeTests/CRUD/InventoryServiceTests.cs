using ECOMCupCake.Data;
using ECOMCupCake.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Xunit;

namespace ECOMCupCakeTests.CRUD
{
    public class InventoryServiceTests : IDisposable
    {
        // shareable vars  
        private Product product;
        private DbContextOptions<StoreDbContext> options;

        /// <summary>
        /// Constructor to setup testing environment
        /// </summary>
        public InventoryServiceTests()
        {
            // setup our db context
            options =
            new DbContextOptionsBuilder<StoreDbContext>()
                .UseInMemoryDatabase("productDb")
                .Options;

            product = new Product();
            using (StoreDbContext context = new StoreDbContext(options))
            {
                product.ID = 1;
                product.Name = "MyName";
                product.Description = "MyDescription";
                product.Price = 1M;
                product.Published = true;
                context.Products.Add(product);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Dispose testing env after each test
        /// </summary>
        public void Dispose()
        {
            product = null;
            using (StoreDbContext context = new StoreDbContext(options))
            {

                var entities = context.Products.ToArray<Product>();
                context.Products.RemoveRange(entities);
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
                product.ID = 2;
                product.Name = "MyAnotherName";
                product.Description = "MyAnotherDescription";
                product.Price = 2M;
                product.Published = false;
                context.Products.Add(product);
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
                string expectedName = "MyName";
                var entity = context.Products.FirstOrDefault(x => x.ID == expectedEntityId);
                Assert.Equal(expectedName, entity.Name);
            }
        }

        /// <summary>
        /// Can UPDATE an entity in a table
        /// </summary>
        [Fact]
        public void CanUpdateEntityInDb()
        {
            int existingId = 1;
            string expectedName = "MyNewName";
            using (StoreDbContext context = new StoreDbContext(options))
            {
                var entity = context.Products.FirstOrDefault(x => x.ID == existingId);
                entity.Name = expectedName;
                context.Update(entity);
                context.SaveChanges();
            }

            using (StoreDbContext context = new StoreDbContext(options))
            {
                var entity = context.Products.FirstOrDefault(x => x.ID == existingId );
                Assert.Equal(expectedName, entity.Name);
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
                var entity = context.Products.FirstOrDefault(x => x.ID == existingId);
                context.Remove(entity);
                context.SaveChanges();
            }

            using (StoreDbContext context = new StoreDbContext(options))
            {
                var entityCount = context.Products.Count();
                Assert.Equal(0, entityCount);
            }
        }
    }
}
