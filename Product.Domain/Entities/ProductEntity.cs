﻿namespace Product.Domain.Entities
{
    public class ProductEntity
    {
        public int Id { get; set; } 
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public int Stock { get; set; }
    }
}
