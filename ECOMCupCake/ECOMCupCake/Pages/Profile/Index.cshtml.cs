﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ECOMCupCake.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECOMCupCake.Pages.Profile
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public ApplicationUser AppUser { get; set; }
        private UserManager<ApplicationUser> _userManager { get; set; }


        public IndexModel(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager; 
        }

        /// <summary>
        /// GET endpoint for the main page of user profile 
        /// </summary>
        /// <returns>A page with all user info</returns>
        public async Task OnGet()
        {
            AppUser = await _userManager.GetUserAsync(HttpContext.User);
        }
    }
}