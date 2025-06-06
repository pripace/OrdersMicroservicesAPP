﻿namespace Order.Domain.Entities
{
    public class OrderEntity
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal Total { get; set; }
        public List<OrderItem> OrderItems { get; set; }

        public OrderEntity()
        {
            OrderItems = new List<OrderItem>();
        }

        public void CalculateTotal()
        {
            Total = OrderItems.Sum(item => item.Subtotal);
        }
    }

    public class OrderItem
    {
        public int Id { get; set; } 
        public int OrderId { get; set; } 
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal Subtotal => UnitPrice * Quantity;
    }
}
