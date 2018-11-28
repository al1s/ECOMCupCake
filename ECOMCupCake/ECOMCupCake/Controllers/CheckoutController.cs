using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ECOMCupCake.Interfaces;
using ECOMCupCake.Models;
using ECOMCupCake.Models.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ECOMCupCake.Controllers
{
    [Authorize]
    public class CheckoutController : Controller
    {
        private readonly IBasket _basket;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IInventory _inventory;

        /// <summary>
        /// Initializes a new instance of the <see cref="CheckoutController"/> class.
        /// </summary>
        /// <param name="basket">The basket.</param>
        /// <param name="inventory">The inventory.</param>
        /// <param name="userManager">The user manager.</param>
        public CheckoutController(IBasket basket, IInventory inventory, UserManager<ApplicationUser> userManager)
        {
            _basket = basket;
            _inventory = inventory;
            _userManager = userManager;
        }
        // GET /Receipt/Index        
        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Receipt()
        {
            var user = HttpContext.User;
            var userId = _userManager.GetUserId(user);
            var email = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email);

            Order order = await _basket.CreateOrder(userId);
            if (email != null && email.Value != null) { 
                await _basket.SendReceipt(order, email.Value);
            }

            IEnumerable<Basket> basket = order.Baskets;
            return View(basket);
        }
    }
}