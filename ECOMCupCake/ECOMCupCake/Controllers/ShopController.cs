using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECOMCupCake.Models.Interfaces;
using ECOMCupCake.Models.Services;
using Microsoft.AspNetCore.Mvc;

namespace ECOMCupCake.Controllers
{
    public class ShopController : Controller
    {

        private IInventory _inventory { get; set; }

        public ShopController(InventoryService inventory)
        {
            _inventory = inventory;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var inventories = await _inventory.GetAll();
            return View(inventories);
        }
    }
}