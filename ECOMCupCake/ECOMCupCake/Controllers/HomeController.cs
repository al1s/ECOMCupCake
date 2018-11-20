using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECOMCupCake.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ECOMCupCake.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Gets or sets the inventory Service.
        /// </summary>
        /// <value>
        /// The inventory.
        /// </value>
        private IInventory _inventory { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="HomeController"/> class.
        /// </summary>
        /// <param name="inventory">The inventory.</param>
        public HomeController(IInventory inventory)
        {
            _inventory = inventory;
        }

        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            return View(await _inventory.GetRandom(3));
        }
    }
}