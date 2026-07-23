using FluentValidation;
using InventorySales.Application.DTOs.Supplier;
using InventorySales.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventorySales.Application.Validators.Supplier {
    public class CreateSupplierValidator : AbstractValidator<CreateSupplierDto> {
        public CreateSupplierValidator() {
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
