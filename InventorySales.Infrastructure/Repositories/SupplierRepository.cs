using InventorySales.Application.Interfaces.Repositories;
using InventorySales.Domain.Entities;
using InventorySales.Infrastructure.Data;
using InventorySales.Infrastructure.GenericRepository;
using Microsoft.EntityFrameworkCore;

namespace InventorySales.Infrastructure.Repositories {
    public class SupplierRepository : GenericRepository<Supplier>, ISupplierRepostiory {
        private readonly AppDbContext _context;
        public SupplierRepository(AppDbContext context) : base(context) {
            _context = context;
        }

        public async Task<bool> ExistsByEmailAsync(string email) {
            return await _context.Suppliers.AnyAsync(s => s.Email.ToLower() == email.ToLower());
        }

        public async Task<bool> ExistsByPhoneAsync(string phone) {
            return await _context.Suppliers.AnyAsync(s => s.Phone == phone);
        }

    }
}
