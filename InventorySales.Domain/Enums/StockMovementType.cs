using System;
using System.Collections.Generic;
using System.Text;

namespace InventorySales.Domain.Enums {
    public enum StockMovementType {
        InitialStock,
        StockIn,
        Sale,
        CustomerReturn,
        AdjustmentIncrease,
        AdjustmentDecrease,
        Damaged
    }
}
