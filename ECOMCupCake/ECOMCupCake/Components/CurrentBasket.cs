using System.Collections.Generic;
using System.Threading.Tasks;
using ECOMCupCake.Interfaces;
using ECOMCupCake.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace ECOMCupCake.Components
{
    public class CurrentBasket : ViewComponent
    {
        private readonly IBasket _basket;
        private readonly UserManager<ApplicationUser> _userManager;

        public CurrentBasket(IBasket basket, UserManager<ApplicationUser> userManager)
        {
            _basket = basket;
            _userManager = userManager;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = HttpContext.User;
            var userId = _userManager.GetUserId(user);
            IEnumerable<Basket> basket = await _basket.GetAllInBasket(userId);
            return View(basket);
        }
    }
}

