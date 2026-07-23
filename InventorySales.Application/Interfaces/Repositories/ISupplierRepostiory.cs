using InventorySales.Application.GenericRepository;
using InventorySales.Domain.Entities;

namespace InventorySales.Application.Interfaces.Repositories {
    public interface ISupplierRepostiory : IGenericRepository<Supplier> {
        Task<bool> ExistsByEmailAsync(string email);
        Task<bool> ExistsByPhoneAsync(string phone);
    }
}
