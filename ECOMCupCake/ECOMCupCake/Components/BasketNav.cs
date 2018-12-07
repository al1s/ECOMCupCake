using ECOMCupCake.Interfaces;
using ECOMCupCake.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECOMCupCake.Components
{
    public class BasketNav : ViewComponent
    {
        private readonly IBasket _basket;
        private readonly UserManager<ApplicationUser> _userManager;

        /// <summary>
        /// Basket navigation constructor
        /// </summary>
        /// <param name="basket">Basket interface injection</param>
        /// <param name="userManager">UserManager injection</param>
        public BasketNav(IBasket basket, UserManager<ApplicationUser> userManager)
        {
            _basket = basket;
            _userManager = userManager;
        }

        /// <summary>
        /// Build a basket component on page rendering 
        /// </summary>
        /// <returns>View with a data if user is authenticated</returns>
        public async Task<IViewComponentResult> InvokeAsync()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return View(0);
            }

            var userId = _userManager.GetUserId(HttpContext.User);
            return View(await _basket.BasketCount(userId));
        }
    }
}
