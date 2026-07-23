using AutoMapper;
using InventorySales.Application.DTOs.Supplier;
using InventorySales.Application.Exceptions;
using InventorySales.Application.Interfaces.Repositories;
using InventorySales.Application.Interfaces.Services;
using InventorySales.Application.UnitOfWork;
using InventorySales.Domain.Entities;
using Microsoft.Identity.Client;
using System.Reflection.Metadata;


namespace InventorySales.Infrastructure.Services {
    public class SupplierService : ISupplierService {
        private readonly ISupplierRepostiory _supplierRepostiory;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public SupplierService(ISupplierRepostiory supplierRepostiory, IMapper mapper, IUnitOfWork unitOfWork) {
            _supplierRepostiory = supplierRepostiory;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<SupplierDto>> GetAllAsync() {
            var suppliers = await _supplierRepostiory.GetAllAsync();
            return _mapper.Map<IEnumerable<SupplierDto>>(suppliers);
        }

        public async Task<SupplierDto> GetByIdAsync(int id) {
            var supplier = await _supplierRepostiory.GetByIdAsync(id);

            if (supplier == null) {
                throw new NotFoundException(nameof(Supplier),id);
            }

            return _mapper.Map<SupplierDto>(supplier);
        }

        public async Task<SupplierDto> CreateAsync(CreateSupplierDto dto) {
            if (await _supplierRepostiory.ExistsByEmailAsync(dto.Email)) {
                throw new ConflictException(nameof(Supplier.Email));
            }

            if (await _supplierRepostiory.ExistsByPhoneAsync(dto.Phone)) {
                throw new ConflictException(nameof(Supplier.Phone));
            }

            var supplier = _mapper.Map<Supplier>(dto);

            await _supplierRepostiory.AddAsync(supplier);

            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<SupplierDto>(supplier);
        }

        public async Task UpdateAsync(int id, UpdateSupplierDto dto) {
            var supplier = await _supplierRepostiory.GetByIdAsync(id);
            if (supplier == null) {
                throw new NotFoundException(nameof(Supplier));
            }

            if (supplier.Email != dto.Email && await _supplierRepostiory.ExistsByEmailAsync(dto.Email)) {
                throw new ConflictException(nameof(Supplier.Email));
            }
            
            if (supplier.Phone != dto.Phone && await _supplierRepostiory.ExistsByPhoneAsync(dto.Phone)) {
                throw new ConflictException(nameof(Supplier.Phone));
            }

            _mapper.Map(dto, supplier);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id) {
            var supplier = await _supplierRepostiory.GetByIdAsync(id);
            if (supplier == null) {
                throw new NotFoundException(nameof(Supplier),id);
            }

            _supplierRepostiory.Delete(supplier);

            await _unitOfWork.SaveChangesAsync();
        }
    }
}
