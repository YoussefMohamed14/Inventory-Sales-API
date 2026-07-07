using System;
using System.Collections.Generic;
using System.Text;

namespace InventorySales.Domain.Common {
    public abstract class BaseEntity {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; } 
    }
}
