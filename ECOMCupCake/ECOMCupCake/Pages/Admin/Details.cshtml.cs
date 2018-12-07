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
    public class DetailsModel : PageModel
    {
        private readonly ECOMCupCake.Data.StoreDbContext _context;

        public Product Product { get; set; }

        public DetailsModel(ECOMCupCake.Data.StoreDbContext context) => _context = context;

        /// <summary>
        /// GET endpoint for product details
        /// </summary>
        /// <param name="id">Product id</param>
        /// <returns>Page with product details</returns>
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
    }
}
