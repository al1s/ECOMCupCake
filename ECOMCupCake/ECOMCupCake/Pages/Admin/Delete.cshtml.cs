using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ECOMCupCake.Data;
using ECOMCupCake.Models;
using Microsoft.AspNetCore.Authorization;

namespace ECOMCupCake.Pages
{
    [Authorize(Policy = "AdminOnly")]
    public class DeleteModel : PageModel
    {
        private readonly ECOMCupCake.Data.StoreDbContext _context;

        /// <summary>
        /// Page product model
        /// </summary>
        [BindProperty]
        public Product Product { get; set; }

        public DeleteModel(ECOMCupCake.Data.StoreDbContext context) => _context = context;

        /// <summary>
        /// GET endpoint for deleting product
        /// </summary>
        /// <param name="id">Product ID to delete</param>
        /// <returns>A confirmation page</returns>
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product = await _context.Products.FirstOrDefaultAsync(m => m.ID == id);

            if (Product == null)
            {
                return NotFound();
            }
            return Page();
        }

        /// <summary>
        /// POST endpoint for deletion product
        /// </summary>
        /// <param name="id">Product id to delete</param>
        /// <returns>Redirect to admin panel</returns>
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product = await _context.Products.FindAsync(id);

            if (Product != null)
            {
                _context.Products.Remove(Product);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
