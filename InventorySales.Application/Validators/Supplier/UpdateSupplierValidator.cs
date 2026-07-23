using FluentValidation;
using InventorySales.Application.DTOs.Supplier;

namespace InventorySales.Application.Validators.Supplier {
    public class UpdateSupplierValidator : AbstractValidator<UpdateSupplierDto> {
        public UpdateSupplierValidator() {
            RuleFor(s => s.Name)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(s => s.Email)
                .NotEmpty()
                .EmailAddress()
                .MaximumLength(150);

            RuleFor(s => s.Address)
                .MaximumLength(250);

            RuleFor(s => s.Phone)
                .MaximumLength(20);
        }
    }
}
