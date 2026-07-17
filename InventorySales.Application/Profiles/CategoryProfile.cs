using AutoMapper;
using InventorySales.Application.DTOs.Category;
using InventorySales.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventorySales.Application.Profiles {
    public class CategoryProfile : Profile {
        public CategoryProfile() {
            CreateMap<CreateCategoryDto, Category>();
            CreateMap<UpdateCategoryDto, Category>();
            CreateMap<Category, CategoryDto>();
        }
    }
}
