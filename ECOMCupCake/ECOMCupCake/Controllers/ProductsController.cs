using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ECOMCupCake.Data;
using ECOMCupCake.Models;
using ECOMCupCake.Models.Interfaces;

namespace ECOMCupCake.Controllers
{
    public class ProductsController : Controller
    {
        /// <summary>
        /// Gets or sets the inventory.
        /// </summary>
        /// <value>
        /// The inventory.
        /// </value>
        private IInventory _inventory { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductsController"/> class.
        /// </summary>
        /// <param name="inventory">The inventory.</param>
        public ProductsController(IInventory inventory)
        {
            _inventory = inventory;
        }

        // GET: Products/Details/5        
        /// <summary>
        /// Detailses the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [Route("product/{slug}/{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ViewData["related"] = await _inventory.GetRandom(3);
            var product = await _inventory.GetById(id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }
        
    }
}
