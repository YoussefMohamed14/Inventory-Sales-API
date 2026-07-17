using System;
using System.Collections.Generic;
using System.Text;

namespace InventorySales.Application.UnitOfWork {
    public interface IUnitOfWork {
        Task<int> SaveChangesAsync();
    }
}
