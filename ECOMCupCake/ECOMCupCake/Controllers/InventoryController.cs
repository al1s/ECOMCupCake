using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECOMCupCake.Models;
using ECOMCupCake.Models.Interfaces;
using ECOMCupCake.Models.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ECOMCupCake.Controllers
{
    public class InventoryController : Controller
    {
        private IInventory _inventory { get; set; }
        public InventoryController(InventoryService inventory)
        {
            _inventory = inventory;
        }
        // GET: /Inventory/Index
        public async Task<IActionResult> Index()
        {
            var inventories = await _inventory.GetAll();
            return View(inventories);
        }
        // GET: /Inventory/Details/3
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
        [HttpPost]
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
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Inventory inventory)
        {
            if (id != inventory.InventoryId)
                NotFound();
            if (ModelState.IsValid)
            {
                try
                {
                    await _inventory.Update(inventory);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_inventory.EntityExists(inventory.InventoryId))
                        NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(inventory);
        }
        // GET: /Inventory/Create
        public IActionResult Create()
        {
            return View(new Inventory());
        }
        // POST: /Inventory/Create
        [HttpPost]
        public async Task<IActionResult> Create(Inventory inventory)
        {
            if (ModelState.IsValid)
            {
                await _inventory.Create(inventory);
                RedirectToAction(nameof(Details), new { id = inventory.InventoryId});
            }
            return View(inventory);
        }
    }
}
