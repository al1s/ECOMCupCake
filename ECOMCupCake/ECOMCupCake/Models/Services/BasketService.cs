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

        public BasketService(StoreDbContext context)
        {
            _storeDbContext = context;
        }

        public async Task<Basket> AddProductAsync(string UserId, int ProductId, int quantity = 1)
        {
            Basket nBasket = new Basket()
            {
                ProductID = ProductId,
                UserID = UserId,
                Quantity = quantity
            };

            _storeDbContext.Add(nBasket);
            try
            {
                await _storeDbContext.SaveChangesAsync();
                return nBasket;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw ex;
            }
        }

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

        public async Task<IEnumerable<Basket>> GetAllInBasket(string UserId)
        {
            return await _storeDbContext.Baskets.Where(b => b.UserID == UserId && b.OrderID == null).ToListAsync();
        }

        public async Task<Basket> GetProductInBasket(string UserId, int ProductId)
        {
            return await _storeDbContext.Baskets.FindAsync(UserId, ProductId);
        }

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

        public bool ProductExistsInBasket(string UserId, int ProductId)
        {
            return _storeDbContext.Baskets.Any(b => b.UserID == UserId && b.ProductID == ProductId);
        }
    }
}
