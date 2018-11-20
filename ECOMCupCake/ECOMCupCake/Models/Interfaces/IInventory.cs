using ECOMCupCake.Data;
using ECOMCupCake.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECOMCupCake.Models.Interfaces
{
    public interface IInventory
    {
        /// <summary>
        /// Create a given product in a repository 
        /// </summary>
        /// <param name="product">Product to be created</param>
        /// <returns>Async void</returns>
        Task Create(Product product);
        /// <summary>
        /// Get all products in an inventory with pagination
        /// </summary>
        /// <param name="startFrom">Starting element of the returning collection</param>
        /// <param name="recordsToReturn">Number of records to return</param>
        /// <param name="onlyPublished">Return only elements marked as published</param>
        /// <returns>A collection of products</returns>
        Task<PaginatedList<Product>> GetAll(int startFrom = 0, int recordsToReturn = 50, bool onlyPublished = true);
        /// <summary>
        /// Get random products from an inventory
        /// </summary>
        /// <param name="recordsToReturn">Number of records to return</param>
        /// <returns>A collection of products</returns>
        Task<ICollection<Product>> GetRandom(int recordsToReturn);
        /// <summary>
        /// Get product by its ID
        /// </summary>
        /// <param name="id">Id of the product</param>
        /// <returns>Product entity</returns>
        Task<Product> GetById(int? id);
        /// <summary>
        /// Update the product in a repo 
        /// </summary>
        /// <param name="product">Product to update</param>
        /// <returns>Async void</returns>
        Task Update(Product product);
        /// <summary>
        /// Delete the product in a repo 
        /// </summary>
        /// <param name="product">Product to delete</param>
        /// <returns>Async void</returns>
        Task Delete(Product product);
        /// <summary>
        /// Check the existence of the product in a repo
        /// </summary>
        /// <param name="id">Product to search for</param>
        /// <returns>True - the product exists</returns>
        bool EntityExists(int id);
    }
}
