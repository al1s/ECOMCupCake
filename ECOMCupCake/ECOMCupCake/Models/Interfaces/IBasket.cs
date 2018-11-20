using ECOMCupCake.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ECOMCupCake.Controllers
{
    public interface IBasket
    {
        Task AddProduct();
        Task DeleteProduct(int ProductId);
        Task<IActionResult> GetDetails(int ProductId);
        Task<IActionResult> GetAll();
        Task Update(Product product);
    }
}