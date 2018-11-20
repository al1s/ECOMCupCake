using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECOMCupCake.Models;
using ECOMCupCake.Models.Interfaces;
using ECOMCupCake.Models.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ECOMCupCake.Controllers
{
    public class InventoryController : Controller
    {
        private IInventory _inventory { get; set; }
        public InventoryController(IInventory inventory)
        {
            _inventory = inventory;
        }
        // GET: /Inventory/Index
        /// <summary>
        /// Get all products from a repo
        /// </summary>
        /// <returns>UI View</returns>
        [Authorize(Policy = "AdminOnly")]
        public async Task<IActionResult> Index()
        {
            var inventories = await _inventory.GetAll();
            return View(inventories.Items);
        }
        // GET: /Inventory/Details/3
        /// <summary>
        /// Get product details from a repo
        /// </summary>
        /// <param name="id">Id of the product to show</param>
        /// <returns>UI View</returns>
        [Authorize(Policy = "AdminOnly")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                NotFound();
            var inventory = await _inventory.GetById(id);
            if (inventory == null)
                NotFound();
            return View(inventory);
        }
        // POST: /Inventory/Delete/3
        /// <summary>
        /// Delete the product from inventory
        /// </summary>
        /// <param name="id">Id of the product to delete</param>
        /// <returns>UI View</returns>
        [HttpPost]
        [Authorize(Policy="AdminOnly")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                NotFound();
            var inventory = await _inventory.GetById(id);
            if (inventory == null)
                NotFound();
            await _inventory.Delete(inventory);
            return RedirectToAction(nameof(Index));
        }
        // GET: /Inventory/Edit/3
        /// <summary>
        /// Edit a product in a repo
        /// </summary>
        /// <param name="id">Id of the product to edit</param>
        /// <returns>UI View</returns>
        [Authorize(Policy="AdminOnly")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                NotFound();
            var inventory = await _inventory.GetById(id);
            if (inventory == null)
                NotFound();
            return View(inventory);
        }
        // POST: /Inventory/Edit/3
        /// <summary>
        /// Save the edited product in a repo
        /// </summary>
        /// <param name="id">Id of the product of an edition</param>
        /// <param name="product">Resulting edited product</param>
        /// <returns>UI View</returns>
        [HttpPost]
        [Authorize(Policy="AdminOnly")]
        public async Task<IActionResult> Edit(int id, Product product)
        {
            if (id != product.ID)
                NotFound();
            if (ModelState.IsValid)
            {
                try
                {
                    await _inventory.Update(product);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_inventory.EntityExists(product.ID))
                        NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }
        // GET: /Inventory/Create
        /// <summary>
        /// Create the product in a repo
        /// </summary>
        /// <returns>UI View</returns>
        [Authorize(Policy="AdminOnly")]
        public IActionResult Create()
        {
            return View(new Product());
        }
        // POST: /Inventory/Create
        /// <summary>
        /// Create the product in a repo
        /// </summary>
        /// <param name="product">Product to be created</param>
        /// <returns>UI View</returns>
        [HttpPost]
        [Authorize(Policy="AdminOnly")]
        public async Task<IActionResult> Create(Product product)
        {
            if (ModelState.IsValid)
            {
                await _inventory.Create(product);
                RedirectToAction(nameof(Details), new { id = product.ID});
            }
            return View(product);
        }
    }
}
