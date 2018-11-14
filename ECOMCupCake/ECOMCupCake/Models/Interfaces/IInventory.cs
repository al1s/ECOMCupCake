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
        Task Create(Inventory inventory);
        Task<ICollection<Inventory>> GetAll();
        Task<Inventory> GetById(int id);
        Task Update(Inventory inventory);
        Task Delete(int id);
    }
}
