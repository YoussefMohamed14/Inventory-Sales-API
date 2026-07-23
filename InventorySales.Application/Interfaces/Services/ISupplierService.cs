using InventorySales.Application.DTOs.Supplier;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventorySales.Application.Interfaces.Services {
    public interface ISupplierService {
        Task<IEnumerable<SupplierDto>> GetAllAsync();
        Task<SupplierDto> GetByIdAsync(int id);
        Task<SupplierDto> CreateAsync(CreateSupplierDto dto);
        Task UpdateAsync(int id, UpdateSupplierDto dto);
        Task DeleteAsync(int id);
    }
}
