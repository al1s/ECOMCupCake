using ECOMCupCake.Data;
using ECOMCupCake.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECOMCupCake.Models.Services
{
    public class InventoryService : IInventory
    {
        private StoreDbContext _context { get; set; }

        public void IInventory(StoreDbContext Context)
        {
            _context = Context;
        }

        public async Task Create(Product product)
        {
            _context.Add(product);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Product product)
        {
            _context.Remove(product);
            await _context.SaveChangesAsync();
        }


        public async Task<ICollection<Product>> GetAll(int startFrom = 0, int recordsToReturn = 50, bool onlyPublished = true)
        {

            if (onlyPublished)
            {
                return await _context.Products
                .Where(inv => inv.Quantity > 0 && inv.Published == true)
                .Skip(startFrom)
                .Take(recordsToReturn)
                .ToListAsync();
            }
            else
            {
                return await _context.Products
                .Where(inv => inv.Quantity > 0)
                .Skip(startFrom)
                .Take(recordsToReturn)
                .ToListAsync();
            }

        }

        public async Task<ICollection<Product>> GetRandom(int recordsToReturn)
        {
            Random rnd = new Random();
            return await _context.Products
                             .Where(inv => inv.Quantity > 0 && inv.Published == true)
                             .OrderBy(inv => rnd.Next())
                             .Take(recordsToReturn)
                             .ToListAsync() ;
        }

        public async Task<Product> GetById(int? id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task Update(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }

        public bool EntityExists(int id)
        {
            return GetById(id) != null;
        }

    }

}
