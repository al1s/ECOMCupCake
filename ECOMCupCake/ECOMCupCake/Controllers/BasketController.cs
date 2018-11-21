using System.Collections.Generic;
using System.Threading.Tasks;
using ECOMCupCake.Interfaces;
using ECOMCupCake.Models;
using ECOMCupCake.Models.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace ECOMCupCake.Controllers
{
    public class BasketController : Controller
    {
        private readonly IBasket _basket;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IInventory _inventory;

        public BasketController(IBasket basket, IInventory inventory, UserManager<ApplicationUser> userManager)
        {
            _basket = basket;
            _inventory = inventory;
            _userManager = userManager;
        }
        // GET /Basket/Index
        public async Task<IActionResult> Index()
        {
            var user = HttpContext.User;
            var userId = _userManager.GetUserId(user);
            IEnumerable<Basket> basket = await _basket.GetAllInBasket(userId);
            return View(basket);
        }


        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Add(int pid, int quantity, string returnUrl)
        {
            Product product = await _inventory.GetById(pid);
            if(product != null && quantity > 0 && quantity <= product.Quantity)
            {
                var user = HttpContext.User;
                var userId = _userManager.GetUserId(user);

                Basket basket = await _basket.AddProductAsync(userId, pid, quantity);
            }

            return View();
        }
    }
}
