using InventorySales.Application.Interfaces.Repositories;
using InventorySales.Domain.Entities;
using InventorySales.Infrastructure.Data;
using InventorySales.Infrastructure.GenericRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventorySales.Infrastructure.Repositories {
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository {
        private readonly AppDbContext _context;
        public CategoryRepository(AppDbContext context) : base (context) {
            _context = context;
        }

        public async Task<bool> ExistsByNameAsync(string name) {
            return await _context.Categories.AnyAsync(category => category.Name.ToLower() == name.ToLower());
        }
    }
}
