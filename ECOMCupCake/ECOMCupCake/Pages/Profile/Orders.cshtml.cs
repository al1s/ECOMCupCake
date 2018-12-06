using ECOMCupCake.Models;
using ECOMCupCake.Models.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECOMCupCake.Pages.Profile
{
    public class OrdersModel : PageModel
    {
        [BindProperty]
        public List<Order> Orders { get; set; }
        private ApplicationUser _user { get; set; }
        private UserManager<ApplicationUser> _userManager { get; set; }
        private IOrder _order { get; set; }

        public OrdersModel(UserManager<ApplicationUser> userManager, IOrder order)
        {
            _order = order;
            _userManager = userManager;
        }

        /// <summary>
        /// GET endpoint with a last 5 orders for the current user
        /// </summary>
        /// <returns>A page with last 5 orders</returns>
        public async Task OnGetAsync()
        {
            _user = await _userManager.GetUserAsync(HttpContext.User);
            Orders = await _order.GetOrders(_user.Id, 5);
        }
    }
}
