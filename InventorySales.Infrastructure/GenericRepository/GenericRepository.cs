using InventorySales.Application.GenericRepository;
using InventorySales.Domain.Common;
using InventorySales.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace InventorySales.Infrastructure.GenericRepository {
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;
        public GenericRepository(AppDbContext context) {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        public async Task<T?> GetByIdAsync(int id) {
            return await _dbSet.FindAsync(id);
        }
        public async Task<List<T>> GetAllAsync() {
            return await _dbSet.ToListAsync();
        }
        public async Task AddAsync(T entity) {
            await _dbSet.AddAsync(entity);
        }
        public void Delete(T entity) {
            _dbSet.Remove(entity);
        }
        public async Task<bool> ExistsAsync(int id) {
            return await _dbSet.AnyAsync(e => e.Id == id);
        }
    }
}
