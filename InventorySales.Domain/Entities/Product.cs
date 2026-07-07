using InventorySales.Domain.Common;

namespace InventorySales.Domain.Entities {
    public class Product : BaseEntity {
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public decimal CostPrice { get; set; }
        public int Quantity { get; set; }
        public int MinimumStock { get; set; }
        public bool IsActive { get; set; } = true;
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }
        public List<StockMovement> StockMovements { get; set; } = new List<StockMovement>();
    }
}