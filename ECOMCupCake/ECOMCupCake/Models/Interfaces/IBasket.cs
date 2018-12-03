using ECOMCupCake.Models;
using ECOMCupCake.Models.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECOMCupCake.Interfaces
{
    public interface IBasket
    {
        Task<Basket> AddProductAsync(string userId, int productId, int quantity);
        Task DeleteProduct(string userId, int productId, int? orderId = null);
        Task<Basket> GetProductInBasket(string userId, int productId, int? orderId = null);
        Task<IEnumerable<Basket>> GetAllInBasket(string userId);
        Task Update(Basket product);
        bool ProductExistsInBasket(string userId, int productId, int? orderId = null);
        Task<int> BasketCount(string UserId);
        Task SendReceipt(Order order, string email);
        Task<Order> CreateOrder(string userId,CheckoutViewModel cvm);
        Task<Order> GetOrder(int orderId);
    }
}