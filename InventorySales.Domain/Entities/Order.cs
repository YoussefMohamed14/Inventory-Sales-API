using InventorySales.Domain.Common;
using InventorySales.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventorySales.Domain.Entities {
    public class Order : BaseEntity {
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public decimal TotalAmount { get; set; }
        public OrderStatus Status { get; set; } = OrderStatus.Pending;
        public string? Notes { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    }
}
