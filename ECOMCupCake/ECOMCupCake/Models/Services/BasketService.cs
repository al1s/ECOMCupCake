using ECOMCupCake.Data;
using ECOMCupCake.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECOMCupCake.Models.Services
{
    public class BasketService : IBasket
    {
        private StoreDbContext _storeDbContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="BasketService"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public BasketService(StoreDbContext context)
        {
            _storeDbContext = context;
        }

        /// <summary>
        /// Adds the product asynchronous.
        /// </summary>
        /// <param name="UserId">The user identifier.</param>
        /// <param name="ProductId">The product identifier.</param>
        /// <param name="quantity">The quantity.</param>
        /// <returns></returns>
        public async Task<Basket> AddProductAsync(string UserId, int ProductId, int quantity = 1)
        {
            Basket basket = await GetProductInBasket(UserId, ProductId);
            if (basket != null)
            {
                basket.Quantity += 1;
            }
            else
            {

                 basket = new Basket()
                {
                    ProductID = ProductId,
                    UserID = UserId,
                    Quantity = quantity
                };

                _storeDbContext.Add(basket);
            }

            try
            {
                await _storeDbContext.SaveChangesAsync();
                return basket;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Deletes the product.
        /// </summary>
        /// <param name="UserId">The user identifier.</param>
        /// <param name="productInBasket">The product in basket.</param>
        /// <returns></returns>
        public async Task DeleteProduct(string UserId, Basket productInBasket)
        {
            _storeDbContext.Baskets.Remove(productInBasket);
            try
            {
                await _storeDbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Gets all in basket.
        /// </summary>
        /// <param name="UserId">The user identifier.</param>
        /// <returns></returns>
        public async Task<IEnumerable<Basket>> GetAllInBasket(string UserId)
        {
            return await _storeDbContext.Baskets.Where(b => b.UserID == UserId && b.OrderID == null).ToListAsync();
        }

        /// <summary>
        /// Gets the product in basket.
        /// </summary>
        /// <param name="UserId">The user identifier.</param>
        /// <param name="ProductId">The product identifier.</param>
        /// <returns></returns>
        public async Task<Basket> GetProductInBasket(string UserId, int ProductId)
        {
            return await _storeDbContext.Baskets.FindAsync(UserId, ProductId);
        }

        /// <summary>
        /// Updates the specified user identifier.
        /// </summary>
        /// <param name="UserId">The user identifier.</param>
        /// <param name="ProductInBasket">The product in basket.</param>
        /// <returns></returns>
        public async Task Update(string UserId, Basket ProductInBasket)
        {
            _storeDbContext.Baskets.Update(ProductInBasket);
            try
            {
                await _storeDbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Products the exists in basket.
        /// </summary>
        /// <param name="UserId">The user identifier.</param>
        /// <param name="ProductId">The product identifier.</param>
        /// <returns></returns>
        public bool ProductExistsInBasket(string UserId, int ProductId)
        {
            return _storeDbContext.Baskets.Any(b => b.UserID == UserId && b.ProductID == ProductId);
        }
    }
}
