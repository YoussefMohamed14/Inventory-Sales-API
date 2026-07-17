using System;
using System.Collections.Generic;
using System.Text;

namespace InventorySales.Application.DTOs.Category {
    public class UpdateCategoryDto {
        public string Name { get; set; }
        public string? Description { get; set; }    
    }
}
