using System;
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
        public ApplicationUser AppUser;
        private UserManager<ApplicationUser> _userManager { get; set; }


        public IndexModel(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager; 
        }
        public async Task OnGet()
        {
            AppUser = await _userManager.GetUserAsync((ClaimsPrincipal)HttpContext.User);
        }
    }
}