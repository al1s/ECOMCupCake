using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECOMCupCake.Interfaces;
using ECOMCupCake.Models;

namespace ECOMCupCake.Controllers
{
    public class BasketController
    {
        private readonly IBasket _basket;

        public BasketController(IBasket basket)
        {
            _basket = basket;
        }
    }
}
