using ECOMCupCake.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECOMCupCake.Models.Interfaces
{
    public interface IInventory
    {
        Task Create(Product product);
        Task<ICollection<Product>> GetAll(int startFrom = 0, int recordsToReturn = 50, bool onlyPublished = true);
        Task<ICollection<Product>> GetRandom(int recordsToReturn);
        Task<Product> GetById(int? id);
        Task Update(Product product);
        Task Delete(Product product);
        bool EntityExists(int id);
    }
}
