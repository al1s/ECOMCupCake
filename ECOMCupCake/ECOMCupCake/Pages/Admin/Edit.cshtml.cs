using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ECOMCupCake.Data;
using ECOMCupCake.Models;
using Microsoft.AspNetCore.Authorization;

namespace ECOMCupCake.Pages
{
    [Authorize(Policy = "AdminOnly")]

    public class EditModel : PageModel
    {
        private readonly ECOMCupCake.Data.StoreDbContext _context;

        public EditModel(ECOMCupCake.Data.StoreDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Product Product { get; set; }

        /// <summary>
        /// GET endpoint for editing product
        /// </summary>
        /// <param name="id">Product ID</param>
        /// <returns>An editable page with product details</returns>
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
        /// POST endpoint to submit product edition results
        /// </summary>
        /// <returns>A redirect to the main page of the admin panel</returns>
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(Product.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        /// <summary>
        /// Check whether product exists in a storage
        /// </summary>
        /// <param name="id">Product id to look for</param>
        /// <returns>Boolean</returns>
        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.ID == id);
        }
    }
}
