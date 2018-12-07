using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECOMCupCake.Models.Interfaces
{
    public interface IOrder
    {
        /// <summary>
        /// Get a given number of last orders 
        /// </summary>
        /// <param name="numberOfOrders">Number of orders to return</param>
        /// <returns>List of orders</returns>
        Task<List<Order>> GetOrders(int numberOfOrders);

        /// <summary>
        /// Get a given number of last orders for a user
        /// </summary>
        /// <param name="numberOfOrders">Number of orders to return</param>
        /// <param name="userId">A user whom orders to return</param>
        /// <returns>List of orders</returns>
        Task<List<Order>> GetOrders(string userId, int numberOfOrders);
    }
}
