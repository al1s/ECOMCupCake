using ECOMCupCake.Models;
using ECOMCupCake.Models.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace ECOMCupCake.Pages
{
    [Authorize(Policy = "AdminOnly")]
    public class CreateModel : PageModel
    {
        private readonly IInventory _inventory;

        /// <summary>
        /// Page model
        /// </summary>
        [BindProperty]
        public Product Product { get; set; }

        public CreateModel(IInventory inventory) => _inventory = inventory;

        /// <summary>
        /// GET endpoint for creating product
        /// </summary>
        /// <returns>A blank product page</returns>
        public IActionResult OnGet() => Page();

        /// <summary>
        /// POST endpoint for creating/storing product
        /// </summary>
        /// <returns>Redirect to admin panel</returns>
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            await _inventory.Create(Product);
            return RedirectToPage("./Index");
        }
    }
}