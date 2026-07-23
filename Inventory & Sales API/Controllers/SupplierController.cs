using InventorySales.Application.DTOs.Supplier;
using InventorySales.Application.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Inventory___Sales_API.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase {
        private readonly ISupplierService _service;
        public SupplierController(ISupplierService service) {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SupplierDto>>> GetAll() {
            var supplier = await _service.GetAllAsync();
            return Ok(supplier);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<SupplierDto>> GetById(int id) {
            var supplier = await _service.GetByIdAsync(id);
            if (supplier == null) {
                return NotFound();
            }
            return Ok(supplier);
        }

        [HttpPost]
        public async Task<ActionResult<SupplierDto>> Create(CreateSupplierDto dto) {
            var supplier = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById),new {id = supplier.Id},supplier);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id,UpdateSupplierDto dto) {
            var supplier = _service.UpdateAsync(id, dto);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id) {
            var supplier = _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
