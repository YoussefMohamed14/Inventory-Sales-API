using InventorySales.Application.UnitOfWork;
using InventorySales.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventorySales.Infrastructure.UnitOfWork {
    public class UnitOfWork : IUnitOfWork {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context) {
            _context = context;
        }

        public async Task<int> SaveChangesAsync() {
            return await _context.SaveChangesAsync();
        }
    }
}
