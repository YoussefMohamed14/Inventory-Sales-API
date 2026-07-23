using InventorySales.Domain.Common;

namespace InventorySales.Domain.Entities {
    public class Product : BaseEntity {
        public string Name { get; set; }
        public string? Description { get; set; }
        public string SKU { get; set; } = string.Empty;
        public string BarCode { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public bool IsActive { get; set; } = true;
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }
        public ICollection<StockMovement> StockMovements { get; set; } = new List<StockMovement>();
        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}