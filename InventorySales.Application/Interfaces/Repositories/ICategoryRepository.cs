using InventorySales.Application.GenericRepository;
using InventorySales.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventorySales.Application.Interfaces.Repositories {
    public interface ICategoryRepository : IGenericRepository<Category> {
        Task<bool> ExistsByNameAsync(string name);
    }
}
