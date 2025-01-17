﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Webshop.Domain
{
    public class OrderLine
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Amount { get; set; }
        public double Price { get; set; }
        public Product Product { get; set; }
    }
}
