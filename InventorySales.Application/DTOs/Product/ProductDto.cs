using System;
using System.Collections.Generic;
using System.Text;

namespace InventorySales.Application.DTOs.Product {
    public class ProductDto {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string SKU { get; set; }
        public string BarCode { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public int CategoryId { get; set; }
        public int SupplierId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
