using InventorySales.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventorySales.Domain.Entities {
    public class Customer : BaseEntity {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public List<Order> Orders { get; set; } = new List<Order>();
    }
}
