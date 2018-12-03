using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECOMCupCake.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ECOMCupCake.Pages.Profile
{
    [Authorize]
    public class EditModel : PageModel
    {
        [BindProperty]
        public ApplicationUser AppUser { get; set; }
        private UserManager<ApplicationUser> _userManager { get; set; }
        public EditModel(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        /// <summary>
        /// Called when [get asynchronous].
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> OnGetAsync()
        {
            AppUser = await _userManager.GetUserAsync(HttpContext.User);
            if (AppUser == null)
                return NotFound();
            return Page();
        }

        /// <summary>
        /// Called when [post asynchronous].
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();
            ApplicationUser UpdatedUser = await _userManager.GetUserAsync(HttpContext.User);
            UpdatedUser.FirstName = AppUser.FirstName;
            UpdatedUser.LastName = AppUser.LastName;
            UpdatedUser.State = AppUser.State;
            UpdatedUser.ZipCode = AppUser.ZipCode;
            await _userManager.UpdateAsync(UpdatedUser);
            return RedirectToPage("./Index");
        }
    }
}