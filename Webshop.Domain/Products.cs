using System;

namespace Webshop.Domain
{
    public class Products
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public int Stock { get; set; }
        public Category Category { get; set; }
    }
}
