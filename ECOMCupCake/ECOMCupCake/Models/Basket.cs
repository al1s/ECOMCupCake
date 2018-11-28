﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECOMCupCake.Models
{
    public class Basket
    {
        public int ID { get; set; }
        public string UserID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public int? OrderID { get; set; }

        // Navigation Properties
        public Product Product { get; set; }
        public Order Order { get; set; }

    }
}
