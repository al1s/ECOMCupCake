using ECOMCupCake.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECOMCupCake.Interfaces
{
    public interface IBasket
    {
        Task AddProductAsync(string UserId, int ProductId, int quantity);
        Task DeleteProduct(string UserId, Basket productInBasket);
        Task<Basket> GetProductInBasket(string UserId, int ProductId);
        Task<IEnumerable<Basket>> GetAllInBasket(string UserId);
        Task Update(string UserId, Basket product);
        bool ProductExistsInBasket(string UserId, int ProductId);
    }
}