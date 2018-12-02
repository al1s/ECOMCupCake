using ECOMCupCake.Models;
using ECOMCupCake.Models.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECOMCupCake.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IInventory _inventory;


        public IndexModel(IInventory inventory)
        {
            _inventory = inventory;
        }

        public IList<Product> Product { get; set; }

        public async Task OnGetAsync()
        {
            var inventory = await _inventory.GetAll(onlyPublished: false);
            Product = inventory.Items.ToList();
        }
    }
}
