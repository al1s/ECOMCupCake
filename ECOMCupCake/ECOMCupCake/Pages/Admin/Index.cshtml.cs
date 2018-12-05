using ECOMCupCake.Models;
using ECOMCupCake.Models.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace ECOMCupCake.Pages
{
    [Authorize(Policy = "AdminOnly")]

    public class IndexModel : PageModel
    {
        private readonly IInventory _inventory;


        public IndexModel(IInventory inventory)
        {
            _inventory = inventory;
        }

        public IList<Product> Product { get; set; }

        /// <summary>
        /// GET endpoint for the main page with all products for admin panel
        /// </summary>
        /// <returns>A page with all products</returns>
        public async Task OnGetAsync()
        {
            var inventory = await _inventory.GetAll(onlyPublished: false);
            Product = inventory.Items.ToList();
        }
    }
}
