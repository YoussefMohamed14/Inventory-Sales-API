using InventorySales.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventorySales.Domain.Entities {
    public class OrderItem : BaseEntity {
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
