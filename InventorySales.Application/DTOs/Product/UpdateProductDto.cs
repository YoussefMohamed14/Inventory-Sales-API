using System;
using System.Collections.Generic;
using System.Text;

namespace InventorySales.Application.DTOs.Product {
    public class UpdateProductDto {
        public string Name { get; set; }
        public string? Description { get; set; }
        public string SKU { get; set; }
        public string BarCode { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public int CategoryId { get; set; }
        public int SupplierId { get; set; }
    }
}
