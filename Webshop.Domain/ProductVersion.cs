using System;
using System.Collections.Generic;
using System.Text;

namespace Webshop.Domain
{
    public class ProductVersion
    {
        public int Id { get; set; }
        public int EditionId { get; set; }
        public int ProductId { get; set; }
        public int PriceMod { get; set; }
        public Edition Editions { get; set; }
        public Product Products { get; set; }

    }
}
