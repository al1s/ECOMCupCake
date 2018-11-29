using ECOMCupCake.Data;
using ECOMCupCake.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECOMCupCake.Models.Services
{
    public class BasketService : IBasket
    {
        private StoreDbContext _storeDbContext;
        private readonly IEmailSender _emailSender;
        protected readonly IHostingEnvironment _hostingEnvironment;

        /// <summary>
        /// Initializes a new instance of the <see cref="BasketService"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public BasketService(StoreDbContext context, IEmailSender emailSender, IHostingEnvironment hostingEnvironment)
        {
            _storeDbContext = context;
            _emailSender = emailSender;
            _hostingEnvironment = hostingEnvironment;
        }

        /// <summary>
        /// Receipts the template.
        /// </summary>
        /// <param name="order">The order.</param>
        /// <returns></returns>
        private string ReceiptTemplate(Order order)
        {
            string fileContents =
                System.IO.File.ReadAllText(_hostingEnvironment.ContentRootPath + "/wwwroot/EmailTemplates/Receipt.html");
            StringBuilder sb = new StringBuilder();
            sb.Append($"<html><head><title>Cupcake Order</title></head><body><table><td>");
            if(order.Baskets != null) { 
                foreach (var item in order.Baskets)
                {
                    sb.Append($"<tr>{item.Product.Name} x {item.Quantity}     ${Math.Round(item.Quantity * item.Product.Price, 2)}</tr>");
                }
            }
            sb.Append($"<tr></tr><tr><strong>Total: ${Math.Round(order.Total, 2)} </strong></td></table></body></html>");
            return fileContents.Replace("{content}", sb.ToString());
        }
        /// <summary>
        /// Sends the receipt.
        /// </summary>
        /// <param name="order">The order.</param>
        /// <returns></returns>
        public Task SendReceipt(Order order, string email)
        {
            if (order == null || email == null) { return null; }
           
            return _emailSender.SendEmailAsync(email, $"Your Cupcake Order: #{order.ID}", ReceiptTemplate(order));
        }

        /// <summary>
        /// Adds the product asynchronous.
        /// </summary>
        /// <param name="UserId">The user identifier.</param>
        /// <param name="ProductId">The product identifier.</param>
        /// <param name="quantity">The quantity.</param>
        /// <returns></returns>
        public async Task<Basket> AddProductAsync(string UserId, int ProductId, int quantity = 1)
        {
            Basket basket = await GetProductInBasket(UserId, ProductId);
            if (basket != null)
            {
                basket.Quantity += quantity;
            }
            else
            {

                 basket = new Basket()
                {
                    ProductID = ProductId,
                    UserID = UserId,
                    Quantity = quantity
                };

                _storeDbContext.Add(basket);
            }

            try
            {
                await _storeDbContext.SaveChangesAsync();
                return basket;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Deletes the product.
        /// </summary>
        /// <param name="UserId">The user identifier.</param>
        /// <param name="productInBasket">The product in basket.</param>
        /// <returns></returns>
        public async Task DeleteProduct(string userId, int productId, int? orderId = null)
        {
            Basket basket = await GetProductInBasket(userId, productId, orderId);
            _storeDbContext.Baskets.Remove(basket);
            try
            {
                await _storeDbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Gets all in basket.
        /// </summary>
        /// <param name="UserId">The user identifier.</param>
        /// <returns></returns>
        public async Task<IEnumerable<Basket>> GetAllInBasket(string UserId)
        {
            return await _storeDbContext.Baskets.Include(p => p.Product).Where(b => b.UserID == UserId && b.OrderID == null).ToListAsync();
        }

        /// <summary>
        /// Baskets the count.
        /// </summary>
        /// <param name="UserId">The user identifier.</param>
        /// <returns></returns>
        public async Task<int> BasketCount(string UserId)
        {
            return await _storeDbContext.Baskets.Where(b => b.UserID == UserId && b.OrderID == null).SumAsync(x => x.Quantity);
        }

        /// <summary>
        /// Gets the product in basket.
        /// </summary>
        /// <param name="UserId">The user identifier.</param>
        /// <param name="ProductId">The product identifier.</param>
        /// <returns></returns>
        public async Task<Basket> GetProductInBasket(string userId, int productId, int? orderId = null)
        {
            return await _storeDbContext.Baskets.FirstOrDefaultAsync(b => b.UserID == userId && b.ProductID == productId && b.OrderID == orderId);
        }

        /// <summary>
        /// Updates the specified user identifier.
        /// </summary>
        /// <param name="UserId">The user identifier.</param>
        /// <param name="ProductInBasket">The product in basket.</param>
        /// <returns></returns>
        public async Task Update(Basket ProductInBasket)
        {
            _storeDbContext.Baskets.Update(ProductInBasket);
            try
            {
                await _storeDbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Products the exists in basket.
        /// </summary>
        /// <param name="UserId">The user identifier.</param>
        /// <param name="ProductId">The product identifier.</param>
        /// <returns></returns>
        public bool ProductExistsInBasket(string UserId, int ProductId, int ? orderId = null)
        {
            return _storeDbContext.Baskets.Any(b => b.UserID == UserId && b.ProductID == ProductId && b.OrderID == orderId);
        }

        /// <summary>
        /// Creates the order.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        public async Task<Order> CreateOrder(string userId)
        {
            Order order = new Order() { UserID = userId, Total = 0 };
            _storeDbContext.Orders.Add(order);
            await _storeDbContext.SaveChangesAsync();
            decimal total = 0m;
            IEnumerable<Basket> basketItems = await GetAllInBasket(userId);
            foreach(Basket item in basketItems)
            {
                total += item.Product.Price * item.Quantity;
                item.OrderID = order.ID;
                _storeDbContext.Baskets.Update(item);
            }
            order.Total = total;
            _storeDbContext.Orders.Update(order);
            await _storeDbContext.SaveChangesAsync();
            return order;
        }
    }
}
