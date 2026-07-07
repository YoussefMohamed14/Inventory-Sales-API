using InventorySales.Domain.Common;
using InventorySales.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventorySales.Domain.Entities {
    public class StockMovement : BaseEntity {
        public int Quantity { get; set; }
        public StockMovementType MovementType { get; set; }
        public string? Reason { get; set; }
        public DateTime MovementDate { get; set; } = DateTime.Now;
        public string? Notes { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
