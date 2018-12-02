using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECOMCupCake.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ECOMCupCake.Pages.Profile
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public ApplicationUser AppUser { get; set; }
        private UserManager<ApplicationUser> _userManager { get; set; }
        public EditModel(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> OnGetAsync(string userId)
        {
            AppUser = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == userId);
            if (AppUser == null)
                return NotFound();
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            var UpdatedUser = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == AppUser.Id);
            if (!ModelState.IsValid)
                return Page();
            UpdatedUser.SecurityStamp = Guid.NewGuid().ToString();
            UpdatedUser.FirstName = AppUser.FirstName;
            UpdatedUser.LastName = AppUser.LastName;
            UpdatedUser.State = AppUser.State;
            UpdatedUser.ZipCode = AppUser.ZipCode;
            await _userManager.UpdateAsync(UpdatedUser);
            return RedirectToPage("./Index");
        }
    }
}