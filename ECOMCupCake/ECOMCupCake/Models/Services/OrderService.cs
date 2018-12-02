using ECOMCupCake.Data;
using ECOMCupCake.Interfaces;
using ECOMCupCake.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECOMCupCake.Models.Services
{
    public class OrderService : IOrder
    {
        private StoreDbContext _context { get; set; }
        public OrderService(StoreDbContext context)
        {
            _context = context;
        }
        public async Task<List<Order>> GetOrders(int numberOfOrders = 5)
        {
            return await GetOrders(numberOfOrders, string.Empty);
        }

        public async Task<List<Order>> GetOrders(int numberOfOrders, string userId)
        {
            List<Order> orders;
            if(userId == string.Empty)
            {
                orders = await _context.Orders
                                .OrderByDescending(o => o.ID)
                                .Take(numberOfOrders).ToListAsync();
            }
            orders = await _context.Orders
                            .Where(o => o.UserID == userId)
                            .OrderByDescending(o => o.ID)
                            .Take(numberOfOrders)
                            .ToListAsync();
            foreach (var order in orders)
            {
                _context.Entry(order).Collection(o => o.Baskets).Load();
            }
            return orders;
        }
    }
}
