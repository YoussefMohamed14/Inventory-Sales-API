using AutoMapper;
using InventorySales.Application.DTOs.Category;
using InventorySales.Application.Exceptions;
using InventorySales.Application.Interfaces.Repositories;
using InventorySales.Application.Interfaces.Services;
using InventorySales.Application.UnitOfWork;
using InventorySales.Domain.Entities;

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
                throw new NotFoundException(nameof(Category),id);
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
        
        public async Task<CategoryDto> UpdateAsync(int id, UpdateCategoryDto dto) {
            var category = await _categoryRepository.GetByIdAsync(id);

            if (category == null) { throw new NotFoundException(nameof(Category), id); }

            _mapper.Map(dto, category);

            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<CategoryDto>(category);
        }

        public async Task DeleteAsync(int id) {
            var category = await _categoryRepository.GetByIdAsync(id);

            if(category == null) { throw new NotFoundException(nameof(Category),id); }

            if (category.Products.Any()) {
                throw new Exception("Cannot delete category because it contains products.");
            }

            _categoryRepository.Delete(category);

            await _unitOfWork.SaveChangesAsync();
        }
    }
}
