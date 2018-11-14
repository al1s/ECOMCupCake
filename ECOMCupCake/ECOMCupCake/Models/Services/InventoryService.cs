using ECOMCupCake.Data;
using ECOMCupCake.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
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

        public async Task Create(Inventory inventory)
        {
            _context.Add(inventory);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            Inventory inventory = await _context.Inventories.FindAsync(id);
            _context.Remove(inventory);
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<Inventory>> GetAll()
        {
            return await _context.Inventories.Select(elm => elm).ToListAsync();
        }

        public async Task<Inventory> GetById(int id)
        {
            return await _context.Inventories.FindAsync(id);
        }

        public async Task Update(Inventory inventory)
        {
            _context.Inventories.Update(inventory);
            await _context.SaveChangesAsync();
        }
    }
}
