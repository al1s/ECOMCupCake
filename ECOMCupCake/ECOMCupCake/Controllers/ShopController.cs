using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECOMCupCake.Models;
using ECOMCupCake.Models.Interfaces;
using ECOMCupCake.Models.Services;
using ECOMCupCake.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ECOMCupCake.Controllers
{
    public class ShopController : Controller
    {

        private IInventory _inventory { get; set; }

        public ShopController(IInventory inventory)
        {
            _inventory = inventory;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            var inventories = await _inventory.GetAll((page - 1)* 20, 20);
            return View(new PaginatedList<Product>(inventories, inventories.Count, page, 20));
        }
    }
}