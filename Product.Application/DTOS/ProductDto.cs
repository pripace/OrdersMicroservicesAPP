﻿namespace Product.Application.DTOS
{
    public class ProductDto
    {
        public string Name { get; set; } 
        public string Description { get; set; } 
        public decimal Price { get; set; }
        public int Stock { get; set; }
    }
}
