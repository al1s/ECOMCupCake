﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ECOMCupCake.Interfaces;
using ECOMCupCake.Models;
using ECOMCupCake.Models.Interfaces;
using ECOMCupCake.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace ECOMCupCake.Controllers
{
    public class BasketController : Controller
    {
        private readonly IBasket _basket;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IInventory _inventory;

        /// <summary>
        /// Initializes a new instance of the <see cref="BasketController"/> class.
        /// </summary>
        /// <param name="basket">The basket.</param>
        /// <param name="inventory">The inventory.</param>
        /// <param name="userManager">The user manager.</param>
        public BasketController(IBasket basket, IInventory inventory, UserManager<ApplicationUser> userManager)
        {
            _basket = basket;
            _inventory = inventory;
            _userManager = userManager;
        }

        // GET /Basket/Index        
        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public async Task<IActionResult> Index()
        {
            Console.WriteLine("USER IS: " + HttpContext.User.Identity.Name);
            var user = HttpContext.User;
            var userId = _userManager.GetUserId(user);
            IEnumerable<Basket> basket = await _basket.GetAllInBasket(userId);
            return View(basket);
        }

        /// <summary>
        /// Adds the specified pid.
        /// </summary>
        /// <param name="pid">The pid.</param>
        /// <param name="quantity">The quantity.</param>
        /// <param name="returnUrl">The return URL.</param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Add(int pid, int quantity, string returnUrl)
        {
            Product product = await _inventory.GetById(pid);
            if (product != null && quantity > 0 && quantity <= product.Quantity)
            {
                var user = HttpContext.User;
                var userId = _userManager.GetUserId(user);

                Basket basket = await _basket.AddProductAsync(userId, pid, quantity);
                return RedirectToAction("Details", "Products", new { id = pid, slug = product.Slug });

            }

            if (returnUrl != null && returnUrl.Length > 0)
            {
                Redirect(returnUrl);
            }

            return RedirectToAction("Index");
        }

        /// <summary>
        /// Removes the specified pid.
        /// </summary>
        /// <param name="pid">The pid.</param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Remove(int pid)
        {
            await _basket.DeleteProduct(_userManager.GetUserId(HttpContext.User), pid);
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Updates the specified pid.
        /// </summary>
        /// <param name="pid">The pid.</param>
        /// <param name="change">The change.</param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Update(ICollection<BaskeEditViewModel> baskets)
        {
            string userId = _userManager.GetUserId(HttpContext.User);
            
            foreach(var bUpdate in baskets)
            {
                Basket basket = await _basket.GetProductInBasket(userId, bUpdate.ProductID);
                if (basket != null)
                {
                    basket.Quantity = Math.Max(0, bUpdate.Quantity);
                    await _basket.Update(basket);
                }
            }
      
            return RedirectToAction("Index");
        }
    }
}
