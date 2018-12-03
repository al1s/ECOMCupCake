using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECOMCupCake.Models;
using ECOMCupCake.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECOMCupCake.Pages.Profile
{
    [Authorize]
    public class PasswordModel : PageModel
    {
        /// <summary>
        /// Gets or sets the change password view model.
        /// </summary>
        /// <value>
        /// The change password view model.
        /// </value>
        [BindProperty]
        public ChangePasswordViewModel ChangePasswordViewModel { get; set; }

        /// <summary>
        /// Gets or sets the status message.
        /// </summary>
        /// <value>
        /// The status message.
        /// </value>
        [TempData]
        public string StatusMessage { get; set; }

        /// <summary>
        /// Gets or sets the user manager.
        /// </summary>
        /// <value>
        /// The user manager.
        /// </value>
        private UserManager<ApplicationUser> _userManager { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PasswordModel"/> class.
        /// </summary>
        /// <param name="userManager">The user manager.</param>
        public PasswordModel(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        /// <summary>
        /// Called when [get asynchronous].
        /// </summary>
        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            var hasPassword = await _userManager.HasPasswordAsync(user);
        
            ChangePasswordViewModel = new ChangePasswordViewModel { StatusMessage = StatusMessage, HasPassword = hasPassword };
            return Page();

        }

        /// <summary>
        /// Called when [post asynchronous].
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ApplicationException">Unable to load user with ID '{_userManager.GetUserId(User)}</exception>
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                throw new ApplicationException($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            var hasPassword = await _userManager.HasPasswordAsync(user);
            ChangePasswordViewModel.HasPassword = hasPassword;

            if (!hasPassword)
            {
                var addPasswordResult = await _userManager.AddPasswordAsync(user, ChangePasswordViewModel.NewPassword);
                if (!addPasswordResult.Succeeded)
                {
                    foreach (var error in addPasswordResult.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                    return Page();

                }
                else
                {
                    StatusMessage = "Your password has been set.";

                }
            }
            else
            {
                var changePasswordResult = await _userManager.ChangePasswordAsync(user, ChangePasswordViewModel.OldPassword, ChangePasswordViewModel.NewPassword);
                if (!changePasswordResult.Succeeded)
                {
                    foreach (var error in changePasswordResult.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                    return Page();
                }
                else
                {
                    StatusMessage = "Your password has been changed.";
                }
            }
        
        
            //await _signInManager.SignInAsync(user, isPersistent: false);

            return RedirectToPage();
        }
    }
}