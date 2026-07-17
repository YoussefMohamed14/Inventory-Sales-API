using FluentValidation;
using InventorySales.Application.DTOs.Category;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventorySales.Application.Validators.Category {
    public class UpdateCategoryValidator : AbstractValidator<UpdateCategoryDto> {
        public UpdateCategoryValidator() {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Category name is required.")
                .MaximumLength(30).WithMessage("Category name cannot exceed 30 characters.");

            RuleFor(c => c.Description)
                .MaximumLength(200).WithMessage("Description cannot exceed 200 characters.");
        }
    }
}
