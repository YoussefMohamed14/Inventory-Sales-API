using InventorySales.Domain.Common;

namespace InventorySales.Domain.Entities {
    public class Supplier : BaseEntity {
        public string Name { get; set; }
        public string Email { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public List<Product> Products { get; set; } = new List<Product>();
    }
}
