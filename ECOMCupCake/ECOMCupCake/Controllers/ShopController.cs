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
        /// <summary>
        /// Gets or sets the inventory.
        /// </summary>
        /// <value>
        /// The inventory.
        /// </value>
        private IInventory _inventory { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ShopController"/> class.
        /// </summary>
        /// <param name="inventory">The inventory.</param>
        public ShopController(IInventory inventory)
        {
            _inventory = inventory;
        }

        /// <summary>
        /// Indexes the specified page.
        /// </summary>
        /// <param name="page">The page.</param>
        /// <returns></returns>
        public async Task<IActionResult> Index(int page = 1)
        {
            var inventories = await _inventory.GetAll((page - 1) * 8, 8);
            return View(inventories);
        }
    }
}