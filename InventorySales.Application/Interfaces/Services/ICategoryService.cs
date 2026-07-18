using InventorySales.Application.DTOs.Category;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventorySales.Application.Interfaces.Services {
    public interface ICategoryService {
        Task<List<CategoryDto>> GetAllAsync();

        Task<CategoryDto?> GetByIdAsync(int id);

        Task<CategoryDto> CreateAsync(CreateCategoryDto dto);

        Task<CategoryDto> UpdateAsync(int id, UpdateCategoryDto dto);

        Task DeleteAsync(int id);
    }
}
