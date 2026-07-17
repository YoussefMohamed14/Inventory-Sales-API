using AutoMapper;
using InventorySales.Application.DTOs.Category;
using InventorySales.Application.Interfaces.Repositories;
using InventorySales.Application.Interfaces.Services;
using InventorySales.Application.UnitOfWork;
using InventorySales.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace InventorySales.Infrastructure.Services {
    public class CategoryService : ICategoryService {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper, IUnitOfWork unitOfWork) {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<CategoryDto>> GetAllAsync() {
            var categories = await _categoryRepository.GetAllAsync();
            return _mapper.Map<List<CategoryDto>>(categories);
        }

        public async Task<CategoryDto?> GetByIdAsync(int id) {
            var category = await _categoryRepository.GetByIdAsync(id);
            
            if (category == null) {
                throw new Exception("Category not found.");
            }
            
            return _mapper.Map<CategoryDto?>(category);
        }

        public async Task<bool> ExistsByNameAsync(string name) {
            return await _categoryRepository.ExistsByNameAsync(name);
        }
        public async Task<CategoryDto> CreateAsync(CreateCategoryDto dto) {
            if (await _categoryRepository.ExistsByNameAsync(dto.Name)) {
                throw new Exception("Category name already exists.");
            }

            var category = _mapper.Map<Category>(dto);

            await _categoryRepository.AddAsync(category);

            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<CategoryDto>(category);
        }
    }
}
