using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECOMCupCake.Models;
using ECOMCupCake.Models.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;

namespace ECOMCupCake.Pages.Admin
{
    [Authorize(Policy = "AdminOnly")]
    public class OrdersModel : PageModel
    {
        [BindProperty]
        public List<Order> Orders { get; set; }
        private IOrder _order { get; set; }

        public OrdersModel(IOrder order)
        {
            _order = order;
        }

        public async Task OnGetAsync()
        {
            Orders = await _order.GetOrders(10);
        }
    }
}