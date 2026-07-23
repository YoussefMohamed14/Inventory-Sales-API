using AutoMapper;
using InventorySales.Application.DTOs.Supplier;
using InventorySales.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventorySales.Application.Profiles {
    internal class SupplierProfile : Profile {
        public SupplierProfile() {
            CreateMap<Supplier, SupplierDto>();

            CreateMap<CreateSupplierDto, Supplier>();

            CreateMap<UpdateSupplierDto, Supplier>();
        }
    }
}
