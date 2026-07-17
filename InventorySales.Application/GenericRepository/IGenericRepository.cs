using InventorySales.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventorySales.Application.GenericRepository {
    public interface IGenericRepository<T> where T : BaseEntity {
        Task<T?> GetByIdAsync(int id);
        Task<List<T>> GetAllAsync();
        Task AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task<bool> ExistsAsync(int id);
    }
}
